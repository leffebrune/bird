using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIPackage_UpgradeItem : MonoBehaviour
{
    List<GameObject> gauges = new List<GameObject>();
    int gaugeMax;
    Button buttonUpgrade;

    string character;
    string key;

    void Awake()
    {
        buttonUpgrade = Util.Find(gameObject, "ButtonUpgrade").GetComponent<Button>();
    }

    void Clear()
    {
        foreach (var go in gauges)
            GameObject.Destroy(go);
        gauges.Clear();
    }

    public void Set(string title, int _gaugeMax)
    {
        key = title;
        Util.SetText(gameObject, "TextTitle", title);

        Clear();

        var gauge = Util.Find(gameObject, "Gauge");
        const float gaugeSize = 400;

        gaugeMax = _gaugeMax;
        for (var i = 0; i < gaugeMax; i++)
        {
            var item = ObjectPool.Make("UIPackage_UpgradeItemGauge", gauge);
            var rt = item.GetComponent<RectTransform>();

            rt.sizeDelta = new Vector2((gaugeSize / gaugeMax) - 2.0f, rt.sizeDelta.y);
            rt.anchoredPosition = new Vector2((gaugeSize / gaugeMax) * i, 0.0f);
            gauges.Add(item);
        }
    }

    public void SetGauge(string _character, int g)
    {
        character = _character;
        for (var i = 0; i < gaugeMax; i++)
        {
            var img = gauges[i].GetComponent<Image>();
            if (i < g)
                img.color = Color.red;
            else
                img.color = Color.white;
        }

        Util.SetText(gameObject, "TextCount", g.ToString() + " / " + gaugeMax.ToString());

        if (g < gaugeMax)
        {
            buttonUpgrade.interactable = true;
            Util.SetButtonEvent(buttonUpgrade, () =>
            {
                UserData.SetUpgrade(character, key, g);
                SetGauge(character, g + 1);
            });
        }
        else
        {
            buttonUpgrade.interactable = false;
        }
    }

    void Update()
    {
    }
}
