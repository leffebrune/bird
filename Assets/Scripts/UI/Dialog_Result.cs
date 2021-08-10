using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Dialog_Result : MonoBehaviour
{
    void Awake()
    {
        var items = GameData.Instance.Players;

        Util.SetText(gameObject, "TextTitle", "Result");
    }

    public void Show(Game_Stage.Result result)
    {
        gameObject.SetActive(true);
        Util.SetText(gameObject, "TextScore", string.Format("Score : {0}", result.Score));
        Util.SetText(gameObject, "TextCoins", string.Format("Coins : {0}", result.Coins));
        Util.SetText(gameObject, "TextFlyTime", string.Format("FlyTime : {0}", result.FlyTime));
    }
}
