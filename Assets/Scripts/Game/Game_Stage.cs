using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class Game_Stage : StagePlayer
{
    public static new Game_Stage Instance;

    const float segmentInterval = 20.0f;

    public enum State
    {
        Ready,
        Playing,
        GameOver
    }

    public struct Result
    {
        public float Score;
        public float Coins;
        public float FlyTime;
    }

    public State CurrentState;

    GameObject player = null;
        
    protected new void Awake()
    {
        base.Awake();
        Instance = this;
        CurrentState = State.Ready;

    }

    void Start()
    {

    }

    void OnEnable()
    {
    }                 
    
    new void Clear()
    {
        base.Clear();
    }

    new void Update()
    {
        if (CurrentState == State.Playing)
        {
            if (!SegmentPlaying && (Time.time - lastSegmentFinished) > segmentInterval)
            {
                InsertRandomSegment();
            }
        }

        base.Update();
        if (Playing)
        {
            GameData.Instance.ScrollSpeed = 3.0f;
            Util.MoveX(Camera.main.gameObject, GameData.Instance.ScrollSpeed * Time.deltaTime);
        }
        else
            GameData.Instance.ScrollSpeed = 0.0f;
    }

    protected override void OnLoadComplete()
    {
        foreach (var deco in decorations)
            Environment.Instance.InitializeWithStage(deco);
    }

    public void StartStage()
    {
        CurrentState = State.Playing;
        //SoundManager.Instance.PlayBGM(Util.GetRandom(new string[] { "BGM_DAY_NORMAL", "BGM_DAY_VER_02" }));
        var info = GameData.Instance.GetPlayerInfo(UserData.CurrentCharacter);
        player = ObjectPool.Get(info.Prefab);
        var playerComp = player.GetComponent<Player>();
        if (playerComp != null)
        {
            Game_UI.Instance.SetMaxHP(playerComp.maxHP);
            playerComp.OnHPChange = (v) => 
            {
                Game_UI.Instance.SetHP(v);
                if (v <= 0)
                    CurrentState = State.GameOver;
            };
            playerComp.OnScoreChange = (v) => Game_UI.Instance.SetScore(v);
        }

        StartLogic();
        UserData.Save();
    }

    public Result StopStage()
    {
        var ret = new Result();
        var playerComp = player.GetComponent<Player>();
        if (playerComp != null)
        {
            ret.Score = playerComp.Score;
            ret.FlyTime = playerComp.FlyTime;
        }

        CurrentState = State.Ready;
        ObjectPool.Release(player);
        player = null;
        StopLogic();

        return ret;
    }
}
