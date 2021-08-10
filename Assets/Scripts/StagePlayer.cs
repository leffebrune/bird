using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StagePlayer : MonoBehaviour
{
    public static StagePlayer Instance;
    public List<StageLayerBase> layers = new List<StageLayerBase>();

    protected List<GameObject> decorations = new List<GameObject>();

    bool _logicPlaying;
    bool _playing;
    bool _inSegment = false;
    float segmentPlayTime = -1.0f;

    protected float lastSegmentFinished = 0.0f;

    public bool LogicPlaying { get { return _logicPlaying; } }
    public bool SegmentPlaying {  get { return _inSegment; } }
    public bool Playing { get { return _playing; } set { _playing = value; } }
    public float ScrollSpeedMultiplier
    {
        set
        {
            foreach (var l in layers)
                l.ScrollSpeedMultiplier = value;
        }
    }

    protected void Awake()
    {
        Instance = this;
        StageSegmentManager.Instance.Load();
    }

    void Start()
    {
        _logicPlaying = false;
        _playing = true;
        LoadStageData();
        StartCoroutine(_StartLogic());
    }

    IEnumerator _StartLogic()
    {
        yield return new WaitForSeconds(3.0f);
        StartLogic();
    }

    protected virtual void OnLoadComplete() { }

    void LoadLayer(JSONObject jobj)
    {
        if (!jobj.IsObject)
            return;

        var _type = jobj["Type"];
        if (_type == null)
            return;

        StageLayerBase l = null;

        if (_type.str == "Interval")
            l = new StageLayerInterval();
        else if (_type.str == "Continuous")
            l = new StageLayerContinuous();
        else if (_type.str == "Logic")
            l = new StageLayerLogic();

        if (l != null)
        {
            l.Load(jobj);
            var newGO = new GameObject(l.Name);
            newGO.transform.parent = gameObject.transform;
            l.gameObject = newGO;
            layers.Add(l);
        }
    }

    public void LoadStageData()
    {
        List<string> decorationPrefabs = new List<string>();
        var t = Resources.Load<TextAsset>("Data/NewStage");
        JSONUtil.LoadKeyValues(t.text, (key, json) =>
        {
            if (key == "Decoration")
            {
                JSONUtil.LoadStringArray(json, ref decorationPrefabs);
            }
            else if (key == "Layers")
            {
                if (json.type == JSONObject.Type.ARRAY)
                {
                    foreach (JSONObject j in json.list)
                    {
                        LoadLayer(j);
                    }
                }
            }
        });
        decorationPrefabs.ForEach(s => decorations.Add(ObjectPool.Get(s, gameObject)));
        OnLoadComplete();
    }

    public void FinishSegment()
    {
        _inSegment = false;
        foreach (var l in layers)
        {
            l.segmentPlaying = false;
            l.spawnDisableTime = 3.0f;
        }

        lastSegmentFinished = Time.time;
    }

    public void StartLogic()
    {
        _logicPlaying = true;
        foreach (var l in layers)
            l.StartLogic();
    }

    public void StopLogic()
    {
        _logicPlaying = false;
        foreach (var l in layers)
            l.StopLogic();
    }

    public void Reset()
    {
        foreach (var l in layers)
            l.Reset();
        InsertSegment("start");
    }


    public void Clear()
    {
        decorations.ForEach(d => ObjectPool.Release(d));
        decorations.Clear();
        // 
        //         bg.ForEach(b => b.Clear());
        //         bg.Clear();

        foreach (var l in layers)
            l.Clear();

        layers.Clear();
        _logicPlaying = false;
    }   

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            InsertRandomSegment();
        }
        if (segmentPlayTime >= 0.0f)
        {
            segmentPlayTime -= Time.deltaTime;
            if (segmentPlayTime < 0.0f)
                FinishSegment();
        }

        foreach (var l in layers)
        {
            if (Playing || l.alwaysMove)
                l.MoveObjects();
            l.SpawnObjects();
            l.VerticalParallax();
        }
    }

    public void InsertSegment(string segmentName)
    {
        if (segmentPlayTime > 0.0f)
            return;

        var segment = StageSegmentManager.Get(segmentName);
        if (segment == null)
            return;

        if (!segment.segmentInfo.ContainsKey("obstacle"))
            return;

        _inSegment = true;

        float startPos = 0.0f;

        foreach (var l in layers)
        {
            if (l.Name == "obstacle")
            {
                float segmentLength = 0.0f;
                l.LoadSegment(segment.segmentInfo["obstacle"], out segmentLength, out startPos);
                segmentPlayTime = segmentLength / l.ScrollSpeed * l.ScrollSpeedMultiplier;
            }
        }

        foreach (var s in segment.segmentInfo)
        {
            if (s.Key == "obstacle")
                continue;

            foreach (var l in layers)
            {
                if (l.Name == s.Key)
                {
                    l.LoadSegmentWithPos(s.Value, startPos);
                    l.segmentPlaying = true;
                    l.spawnDisableTime = -1.0f;
                }
            }
        }
    }

    protected void InsertRandomSegment()
    {
        InsertSegment(StageSegmentManager.GetRandom());
    }

}
