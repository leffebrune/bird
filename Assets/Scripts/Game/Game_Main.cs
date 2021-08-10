using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Collections;

public class Game_Main : MonoBehaviour
{
    public static Game_Main Instance { get; private set; }

    public enum State
    {
        Start,
        Ready,
        Playing
    }

    StateMachine<State> sm = new StateMachine<State>();
    GameObject upperSkyObject = null;

    bool openingSequenceDone = true;

	void Awake()
    {
        UserData.Load();
        StageSegmentManager.Instance.Load();
        Instance = this;

        sm.AddState(State.Start,
            (prev, param) =>
            {
                Game_Stage.Instance.Playing = false;
                upperSkyObject = ObjectPool.Make("background_day_upper", null);
            }, 
            () =>
            {
                if (sm.StateElapsed() > 1.0f)
                {
                    Game_Stage.Instance.LoadStageData();
                    sm.Enter(State.Ready);
                }
            },
            null);

        sm.AddState(State.Ready,
            (prev, param) =>
            {
                Game_Stage.Instance.Playing = false;
                Game_Stage.Instance.Reset();
                if (openingSequenceDone)
                    Game_UI.Instance.StartUI = true;
                else
                    StartCoroutine(OpeningSequence());
            },
            null,
            (next) =>
            {
                Game_UI.Instance.StartUI = false;
                Game_Stage.Instance.Playing = true;
            });

        sm.AddState(State.Playing,
            (prev, param) =>
            {
                Game_UI.Instance.PlayingUI = true;
                Game_Stage.Instance.StartStage();
            },
            null,
            (next) =>
            {
                Game_UI.Instance.PlayingUI = false;
            });

    }

    void SetCameraY(float y)
    {
        var camPos = Camera.main.transform.position;
        camPos.y = y;
        Camera.main.transform.position = camPos;
    }

    IEnumerator OpeningSequence()
    {
        var cy = 20.0f;
        while (cy >= 0)
        {
            SetCameraY(cy);
            cy -= Time.deltaTime * 2.0f;
                
            yield return new WaitForEndOfFrame();
        }
        SetCameraY(0);
        openingSequenceDone = true;
        Destroy(upperSkyObject);
        Game_UI.Instance.StartUI = true;
    }

    void Start()
    {
        sm.Enter(State.Start);   
    }

    void Update()
    {
        sm.OnUpdate();

        if (Game_Stage.Instance.CurrentState == Game_Stage.State.GameOver)
            ResetStage();
    }

    public void StartStage()
    {
        sm.Enter(State.Playing);
    }

    public void ResetStage()
    {
        var result = Game_Stage.Instance.StopStage();
        UserData.Coin += (int)result.Coins;
        Game_UI.Instance.PerformTransition(() =>
        {
            sm.Enter(State.Ready);
            Game_UI.Instance.dialogResult.Show(result);
        });
    }

    public void EnterState(State s)
    {
        sm.Enter(s);
    }

    public void PauseStage()
    {
        if (Time.timeScale > 0.0f)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;
    }
}
