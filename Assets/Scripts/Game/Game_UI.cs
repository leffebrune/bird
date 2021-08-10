using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Game_UI : MonoBehaviour
{
    public static Game_UI Instance { get; private set; }

    public GameObject startUI;
    public GameObject playingUI;

    public GameObject transition;
    Material transitionMaterial;
    public Dialog_Result dialogResult;

    UI_HP uiHP;

    Text textScore;
    Text textCoin;

    public bool StartUI
    {
        set
        {
            startUI.SetActive(value);
        }
    }

    public bool PlayingUI
    {
        set
        {
            playingUI.SetActive(value);
        }
    }

    bool transitionDoing;
    
    void Awake()
    {
        Instance = this;

        transitionDoing = false;
        var transitionImg = transition.GetComponent<Image>();
        transitionMaterial = transitionImg.material;
        transition.SetActive(true);

        startUI.SetActive(true);
        playingUI.SetActive(true);

        uiHP = Util.Find(playingUI, "HP").GetComponent<UI_HP>();

        textScore = Util.Find(playingUI, "TextScore").GetComponent<Text>();
        textCoin = Util.Find(playingUI, "TextCoin").GetComponent<Text>();

        dialogResult = Util.Find(gameObject, "Dialog_Result").GetComponent<Dialog_Result>();

        dialogResult.gameObject.SetActive(false);
    }

    void Start()
    {        
        startUI.SetActive(false);
        playingUI.SetActive(false);

        transition.SetActive(false);
    }

    IEnumerator _PerformTransition(Action doSomething)
    {
        transitionDoing = true;
        transition.SetActive(true);
        var progress = 0.0f;
        var speed = 1.0f;
        while (true)
        {
            transitionMaterial.SetFloat("_Progress", progress);
            progress += Time.deltaTime / speed;
            if (progress > 1.0f)
                break;
            yield return new WaitForEndOfFrame();
        }

        progress = 1.0f;
        transitionMaterial.SetFloat("_Progress", progress);
        if (doSomething != null)
            doSomething();
        yield return new WaitForSeconds(1.0f);

        while (true)
        {
            transitionMaterial.SetFloat("_Progress", progress);
            progress -= Time.deltaTime / speed;
            if (progress < 0.0f)
                break;
            yield return new WaitForEndOfFrame();
        }

        progress = 0.0f;
        transitionMaterial.SetFloat("_Progress", progress);

        transition.SetActive(false);
        transitionDoing = false;
    }

    public void PerformTransition(Action doSomething = null)
    {
        if (!transitionDoing)
            StartCoroutine(_PerformTransition(doSomething));
    }

    public void SetScore(float s)
    {
        textScore.text = s.ToString("N0");
    }

    public void SetCoin(float c)
    {
        textCoin.text = c.ToString("N0");
    }


    public void SetMaxHP(float maxhp)
    {
        uiHP.Set(maxhp);
    }

    public void SetHP(float hp)
    {
        uiHP.UpdateHP(hp);
    }
}
