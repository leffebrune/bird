using UnityEngine;
using System.Collections.Generic;

public class StageObject : MonoBehaviour
{
    public Bounds bound;
    public float movingSpeed;
    public bool isInitialized = false;
    public float yMax;
    public bool isSegment = false;

    public float xPos
    {
        get { return transform.position.x; }
    }

    public float LeftEnd
    {
        get { return transform.position.x + bound.min.x; }
    }

    public float RightEnd
    {
        get { return transform.position.x + bound.max.x; }
    }

    public void SetParam(Bounds _bounds, float speed, float _yMax, bool _isSegment = false)
    {
        isSegment = _isSegment;
        bound = _bounds;
        movingSpeed = speed;
        yMax = _yMax;
        isInitialized = false;
    }

    public void StickTo(StageObject other)
    {
        Util.SetZ(gameObject, other.gameObject);
        movingSpeed = other.movingSpeed;
    }

}

public abstract class StageLayerBase
{
    protected const float ScreenWidth = 12.0f;

    public struct Entity
    {
        public string prefab;
        public float chance;
        public float yMin;
        public float yMax;
        public float speedOffset;
    }

    public int ActiveCount { get { return stageObjects.Count; } }
    public bool Active { get { return _active; } }

    public string Name;
    public float BaseDepth = 0.0f;
    float ParallaxRatio = 0.0f;
    public bool alwaysMove = false;
    public float ScrollSpeed = 0.0f;
    public float ScrollSpeedMultiplier = 1.0f;
    public GameObject gameObject = null;

    protected Vector2 defaultY;
    protected float defaultSpeedOffset;

    public List<Entity> entities = new List<Entity>();
    protected List<StageObject> stageObjects = new List<StageObject>();
    protected StageObject lastObject = null;

    public bool logicPlaying = false;
    public bool segmentPlaying = false;
    public float spawnDisableTime = -1.0f;
    protected bool forceSpawn = false;
    protected bool _active = true;

    public abstract void Load(JSONObject jobj);

    protected abstract bool NeedSpawn();
    protected abstract float GetNextObjectPos(Bounds bound);

    protected virtual void AdjustSpeed(StageObject obj, Entity newEntity)
    {
    }

    protected virtual void OnStartLogic()
    {
    }
    protected virtual void OnStopLogic()
    {
    }

    bool SpawnNewObject()
    {
        Entity newEntity = new Entity();
        if (!GetNextObject(ref newEntity))
            return false;

        var obj = ObjectPool.Get(newEntity.prefab, gameObject);
        if (obj == null)
            return false;

        var bound = PrefabBounds.Get(newEntity.prefab);
        float xPos = GetNextObjectPos(bound);
        float yPos = Random.Range(newEntity.yMin, newEntity.yMax);
        float zPos = BaseDepth;

        obj.SetLocalPos(xPos, yPos, zPos);

        var stageObject = obj.MakeComponent<StageObject>();
        //obj.MakeComponent<SetSortingOrderAlpha>();

        stageObject.SetParam(bound, ScrollSpeed, newEntity.yMax);
        AdjustSpeed(stageObject, newEntity);

        lastObject = stageObject;
        stageObjects.Add(lastObject);
        return true;
    }

    public void LoadSegment(List<StageSegment.Item> items, out float length, out float startPos)
    {
        var localPos = 0.0f;
        if (lastObject == null)                 
            localPos = -ScreenWidth + CameraPos();
        else
            localPos = lastObject.RightEnd;

        length = LoadSegmentWithPos(items, localPos);
        startPos = localPos;
    }

    public float LoadSegmentWithPos(List<StageSegment.Item> items, float startPos)
    {
        RemoveAfter(startPos);

        var farPos = 0.0f;

        foreach (var i in items)
        {
            var obj = ObjectPool.Get(i.prefab, gameObject);
            if (obj == null)
                continue;

            obj.SetLocalPos(startPos + i.position.x, i.position.y, BaseDepth);
            var stageObject = obj.MakeComponent<StageObject>();
            var bound = PrefabBounds.Get(i.prefab);
            stageObject.SetParam(bound, ScrollSpeed, 5.0f, true);
            stageObjects.Add(stageObject);

            if (i.position.x + bound.max.x > farPos)
            {
                farPos = i.position.x + bound.max.x;
                lastObject = stageObject;
            }
        }
        return farPos;
    }

    protected float CameraPos()
    {
        return Camera.main.transform.position.x;
    }

    protected bool GetNextObject(ref Entity e)
    {
        var sum = 0.0f;
        entities.ForEach(c => sum += c.chance);
        var r = Random.Range(0.0f, sum);
        var sum2 = 0.0f;
        for (var i = 0; i < entities.Count; i++)
        {
            sum2 += entities[i].chance;
            if (r < sum2)
            {
                e = entities[i];
                return true;
            }
        }
        return false;
    }
    
    protected void LoadBase(JSONObject jobj)
    {
        entities.Clear();
        Name = JSONUtil.GetStringValue(jobj, "Name");
        BaseDepth = JSONUtil.GetFloatValue(jobj, "Depth");
        ScrollSpeed = JSONUtil.GetFloatValue(jobj, "Speed");

        defaultY = JSONUtil.GetVector2(jobj, "Y-Pos");
        defaultSpeedOffset = JSONUtil.GetFloatValue(jobj, "SpeedOffset");

        ParallaxRatio = JSONUtil.GetFloatValue(jobj, "ParallaxRatio");
        alwaysMove = JSONUtil.GetBooleanValue(jobj, "AlwaysMove");

        var _entity = jobj["Entities"];
        if (_entity == null)
            return;

        JSONUtil.LoadKeyValues(_entity, (key, json) =>
        {
            var e = new Entity();
            e.prefab = key;
            e.yMin = defaultY.x;
            e.yMax = defaultY.y;
            e.speedOffset = defaultSpeedOffset;
            JSONUtil.LoadKeyValues(json, (key2, json2) =>
            {
                if (key2 == "Chance")
                    e.chance = json2.n;
                else if (key2 == "Y-Pos")
                {
                    if (json2.IsArray)
                    {
                        if (json2.list.Count >= 2)
                        {
                            e.yMin = json2.list[0].n;
                            e.yMax = json2.list[1].n;
                        }
                    }
                }
                else if (key2 == "SpeedOffset")
                    e.speedOffset = json2.n;
            });
            entities.Add(e);
        });
    }

    public void Reset()
    {
        foreach (var so in stageObjects)
        {
            ObjectPool.Release(so.gameObject);
        }
        stageObjects.Clear();
        lastObject = null;
    }

    public void Clear()
    {
        Reset();
        Object.Destroy(gameObject);
    }

    public void MoveObjects()
    {
        var removeIdx = -1;

        for (var i = 0; i < stageObjects.Count; i++)
        {
            var so = stageObjects[i];

            UnityEngine.Profiling.Profiler.BeginSample("update");
            so.gameObject.MoveX((GameData.Instance.ScrollSpeed - (so.movingSpeed * ScrollSpeedMultiplier)) * Time.deltaTime);

            UnityEngine.Profiling.Profiler.EndSample();

            bool needInitialize = false;

            if (ScrollSpeed >= 0.0f)
            {
                if (!so.isInitialized && (so.LeftEnd < ScreenWidth + CameraPos() - 2.0f))
                    needInitialize = true;
                if (so.RightEnd < -ScreenWidth + CameraPos())
                    removeIdx = i;
            }
            else
            {
                if (!so.isInitialized && (so.RightEnd > -ScreenWidth + CameraPos() + 2.0f))
                    needInitialize = true;
                if (so.LeftEnd > ScreenWidth + CameraPos())
                    removeIdx = i;
            }

            if (needInitialize)
            {
                so.gameObject.SendMessage("OnEnterScreen", SendMessageOptions.DontRequireReceiver);
                so.isInitialized = true;
            }
        }

        if (removeIdx != -1)
        {
            var removedObj = stageObjects[removeIdx];
            ObjectPool.Release(removedObj.gameObject);
            stageObjects.RemoveAt(removeIdx);

            if (removedObj.gameObject == lastObject.gameObject)
            {
                var newLastObjIndex = -1;
                if (ScrollSpeed > 0.0f)
                {
                    var maxX = float.MinValue;
                    for (var i = 0; i < stageObjects.Count; i++)
                    {
                        var so = stageObjects[i];
                        if (so.xPos > maxX)
                        {
                            maxX = so.xPos;
                            newLastObjIndex = i;
                        }
                    }
                }
                else
                {
                    var minX = float.MaxValue;
                    for (var i = 0; i < stageObjects.Count; i++)
                    {
                        var so = stageObjects[i];
                        if (so.xPos < minX)
                        {
                            minX = so.xPos;
                            newLastObjIndex = i;
                        }
                    }
                }
                if (newLastObjIndex != -1)
                    lastObject = stageObjects[newLastObjIndex];
                else
                    lastObject = null;
            }
        }
    }
    
    public void SpawnObjects()
    {
        if (segmentPlaying)
            return;

        if (spawnDisableTime > 0.0f)
        {
            spawnDisableTime -= Time.deltaTime;
            return;
        }

        while (NeedSpawn() || forceSpawn)
        {
            if (!SpawnNewObject())
                break;
            forceSpawn = false;
        }
    }

    public void VerticalParallax()
    {
        var pr = Mathf.Clamp01(ParallaxRatio);
        gameObject.SetPosXY(gameObject.transform.position.x, Mathf.Lerp(0.0f, Camera.main.transform.position.y, pr));
    }

    public void StartLogic()
    {
        if (!logicPlaying)
        {
            logicPlaying = true;
            OnStartLogic();
        }
    }

    public void StopLogic()
    {
        if (logicPlaying)
        {
            logicPlaying = false;
            OnStopLogic();
        }
    }

    public void SetActive(bool b)
    {
        _active = b;
        foreach (var so in stageObjects)
        {
            so.gameObject.SetActive(b);
        }
    }

    public void RemoveAfter(float xPos)
    {
        for (var i = 0; i < stageObjects.Count; i++)
        {
            var so = stageObjects[i];
            if (so.xPos > xPos)
            {
                so.gameObject.SetPosXY(-100, 0);
            }
        }
    }
}
