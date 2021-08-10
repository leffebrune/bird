using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    enum States
    {
        Idle,
        Upward,
        Damaged,
    }

    public struct Buff
    {
        public string name;
        public float remain;
    }

    struct LoopEffectInfo
    {
        public string name;
        public GameObject effect;
    }

    const float xPos = -6.0f;

    public string damagedEffect;

    Animator[] animators;
    float _score;
    float _time;
    bool playing = false;
    float lastTaptime = 0.0f;
    Vector2 localPos;
    List<GameObject> triggered = new List<GameObject>();

    StateMachine<States> sm = new StateMachine<States>();

    [HideInInspector]
    public float verticalSpeed = 0.0f;
    [HideInInspector]
    public float additionalSpeed = 0.0f;

    public float maxHP = 1000.0f;
    float currentHP;

    Action<float> _onScoreChange = null;
    Action<float> _onHPChange = null;

    List<LoopEffectInfo> loopEffects = new List<LoopEffectInfo>();
    List<Buff> buffs = new List<Buff>();

    TrailRenderer trailRenderer = null;

    public Action<float> OnScoreChange
    {
        set
        {
            _onScoreChange = value;
            if (_onScoreChange != null)
                _onScoreChange(_score);
        }
    }

    public Action<float> OnHPChange
    {
        set
        {
            _onHPChange = value;
            if (_onHPChange != null)
                _onHPChange(currentHP);
        }
    }

    public float Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            if (_onScoreChange != null)
                _onScoreChange(_score);
        }
    }
    public float FlyTime
    {
        get
        {
            return _time;
        }
        set
        {
            _time = value;
            //UI.Instance.SetTime(value)
        }
    }

    public float HP
    {
        get
        {
            return currentHP;
        }
        set
        {
            currentHP = value;
            currentHP = Mathf.Clamp(currentHP, 0.0f, maxHP);
            if (_onHPChange != null)
                _onHPChange(currentHP);
        }
    }

    void Awake()
    {
        animators = GetComponentsInChildren<Animator>();
        trailRenderer = GetComponentInChildren<TrailRenderer>();

        sm.AddState(States.Idle,
            (prev, param) =>
            {
                if (prev != States.Upward)
                    PlayAnimation("idle");
            });

        sm.AddState(States.Upward,
            (prev, param) =>
            {
                PlayAnimation("upward");
                sm.Reserve(States.Idle, 0.5f);
            },
            null,
            null);

        sm.AddState(States.Damaged,
            (prev, param) =>
            {
                HP -= 100;
                PlayEffect(damagedEffect);                
                PlayAnimation("damaged");
            },
            () =>
            {
                if (sm.StateElapsed() > 3.0f)
                    sm.Enter(States.Idle);

                if (Mathf.Abs(verticalSpeed) < 0.1f)
                {
                    verticalSpeed = 0.0f;
                    return;
                }

                var accel = 2.0f;
                if (verticalSpeed < 0)
                {
                    verticalSpeed += accel * Time.deltaTime;
                    if (verticalSpeed > 0.0f)
                        verticalSpeed = 0.0f;
                }
                else
                {
                    verticalSpeed -= accel * Time.deltaTime;
                    if (verticalSpeed < 0.0f)
                        verticalSpeed = 0.0f;
                }
            },
            null,
            null);

        sm.SetEventHandler((id, param) =>
        {
            if (ExistBuff("BlockControl"))
                return;

            if (id == "short_tap")
            {
                if (verticalSpeed < 0)
                    verticalSpeed = 3.0f;
                else
                    verticalSpeed += 3.0f;

                sm.Enter(States.Upward);
            }
            else if (id == "glide_start")
            {
                //sm.Enter(States.Glide);
            }
        });
    }

    void PlayAnimation(string name)
    {
        Array.ForEach(animators, a => a.CrossFadeInFixedTime(name, 0.1f, 0));
    }

    void Initialize()
    {
        StartCoroutine(ResetPlayer());
    }

    bool isLongTap()
    {
        return Time.time - lastTaptime > 0.3f;
    }

    void Clear()
    {
        triggered.Clear();
        playing = false;
        transform.position = new Vector3(xPos, 1, 0);
        StopAllCoroutines();

        foreach (var l in loopEffects)
            ObjectPool.Release(l.effect);
        loopEffects.Clear();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastTaptime = Time.time;
        }

        if (playing == false)
        {
            SetPosition();
            return;
        }

        if (Input.GetMouseButtonUp(0) && !isLongTap())
            sm.SendEvent("short_tap");

        if (sm.GetCurrent() != States.Damaged)
        {
            verticalSpeed -= 9 * Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
            sm.SendEvent("glide_start");
        if (Input.GetMouseButtonUp(0))
            sm.SendEvent("glide_end");

        FlyTime += Time.deltaTime;

        if (HP <= 0)
            Clear();

        sm.OnUpdate();

        additionalSpeed = 0.0f;
        triggered.RemoveAll(obj => { return !obj.activeSelf; });
        triggered.ForEach(obj => obj.SendMessage("OnStay", this, SendMessageOptions.DontRequireReceiver));

        verticalSpeed = Mathf.Clamp(verticalSpeed, -5, 6);

        localPos.x = xPos;
        localPos.y += (verticalSpeed + additionalSpeed) * Time.deltaTime;
        SetPosition();

        foreach (var l in loopEffects)
            l.effect.SendMessage("SetPosition", localPos, SendMessageOptions.DontRequireReceiver);

        UpdateBuff();
    }

    IEnumerator Entering()
    {
        trailRenderer.emitting = false;
        trailRenderer.Clear();
        var startPos = new Vector3(-9, 4, 0);
        var targetPos = new Vector3(xPos, 1.5f, 0);
        var startTime = Time.time;
        var elapsed = Time.time - startTime;
        while (elapsed < 2.0f)
        {
            localPos = Vector3.Lerp(startPos, targetPos, (elapsed / 2.0f));
            yield return new WaitForEndOfFrame();
            elapsed = Time.time - startTime;
            if (elapsed > 0.3f)
                trailRenderer.emitting = true;
        }
    }

    IEnumerator ResetPlayer()
    {
        HP = maxHP;
        sm.Enter(States.Idle);
        playing = false;
        verticalSpeed = 0;
        StartCoroutine(Entering());
        Score = 0;
        FlyTime = 0;
        //UI.Instance.SetScore(Score);
        yield return new WaitForSeconds(3.0f);
        playing = true;
    }

    void SetPosition()
    {
        Vector3 p = new Vector3(localPos.x, localPos.y, 0.0f);
        p.x += Camera.main.transform.position.x;
        p.y += Camera.main.transform.position.y;
        transform.position = p;
    }

    void PlaySound()
    {

    }

    bool CheckCollide(LogicObject s, GameObject other)
    {
        if (s == null)
            return (other.gameObject.GetComponent<CommonObstacle>() != null);

        return s.isObstacle;
    }

    void Bounce(GameObject other)
    {
        if (other.transform.position.y < gameObject.transform.position.y)
            verticalSpeed = 3.0f;
        else
            verticalSpeed = -3.0f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {        
        var s = other.gameObject.GetComponent<LogicObject>();

        if (CheckCollide(s, other.gameObject))
        {
            Bounce(other.gameObject);
            if (sm.GetCurrent() != States.Damaged)
                sm.Enter(States.Damaged);
        }

        other.gameObject.SendMessage("OnTriggered", this, SendMessageOptions.DontRequireReceiver);

        if (s == null)
            return;

        if (s.destroyWhenCollide)
        {
            var p = other.gameObject.transform.position;
            p.x = -100;
            other.gameObject.transform.position = p;
        }
        else
        {
            triggered.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var s = other.gameObject.GetComponent<LogicObject>();
        if (s == null)
            return;

        other.gameObject.SendMessage("OnExit", this, SendMessageOptions.DontRequireReceiver);

        triggered.Remove(other.gameObject);
    }

    public void PlayEffect(string name)
    {
        var effect = ObjectPool.Get(name);
        if (effect != null)
        effect.SendMessage("SetPosition", localPos, SendMessageOptions.DontRequireReceiver);
    }

    public void LoopEffect(string name)
    {
        foreach (var l in loopEffects)
        {
            if (l.name == name)
                return;
        }
        var effect = ObjectPool.Get(name);
        if (effect != null)
            loopEffects.Add(new LoopEffectInfo() { name = name, effect = effect });
    }

    public void StopEffect(string name)
    {
        loopEffects.RemoveAll((l) =>
        {
            if (l.name == name)
            {
                ObjectPool.Release(l.effect);
                return true;
            }
            return false;
        });
    }

    public void AddBuff(string name, float lifeTime)
    {
        for (var i = 0; i < buffs.Count; i++)
        {
            var b = buffs[i];
            if (b.name == name)
            {
                b.remain = lifeTime;
                buffs[i] = b;
                return;
            }
        }
        buffs.Add(new Buff() { name = name, remain = lifeTime });
    }

    public bool ExistBuff(string name)
    {
        for (var i = 0; i < buffs.Count; i++)
        {
            if (buffs[i].name == name)
                return true;
        }
        return false;
    }

    void UpdateBuff()
    {
        for (var i = 0; i < buffs.Count; i++)
        {
            var b = buffs[i];
            b.remain -= Time.deltaTime;
            buffs[i] = b;
        }

        buffs.RemoveAll((b) => (b.remain < 0.0f));
    }
}

