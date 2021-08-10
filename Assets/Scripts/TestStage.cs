using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class TestStage : StagePlayer
{
    GameObject player;
        
    protected new void Awake()
    {
        base.Awake();
        Instance = this;
	}

    void Start()
    {

    }

    void OnEnable()
    {
        
    }                 
    
    public void StartStage(string playerName)
    {
        Camera.main.transform.position = new Vector3(0, 0, -10);

        LoadStageData();
        StartLogic();

        player = ObjectPool.Get(playerName, gameObject);
        StartCoroutine(ScrollStart());
    }      

    IEnumerator ScrollStart()
    {
        ScrollSpeedMultiplier = 0.0f;
        yield return new WaitForSeconds(2.0f);
        var _multiplier = 0.0f;
        while (true)
        {
            _multiplier += Time.deltaTime * 0.5f;
            if (_multiplier > 1.0f)
            {
                _multiplier = 1.0f;
                break;
            }

            ScrollSpeedMultiplier = _multiplier;
            yield return new WaitForEndOfFrame();
        }
        ScrollSpeedMultiplier = 1.0f;
    }
    
    new void Clear()
    {
        base.Clear();

        SoundManager.Instance.StopBGM();
        ObjectPool.Release(player);
    }

    new void Update()
    {
        base.Update();
        Util.MoveX(Camera.main.gameObject, GameData.Instance.ScrollSpeed * Time.deltaTime);
    }

    public void OnPlayStart()
    {
        SoundManager.Instance.PlayBGM(Util.GetRandom(new string[]{"BGM_DAY_NORMAL", "BGM_DAY_VER_02" }));
    }
}
