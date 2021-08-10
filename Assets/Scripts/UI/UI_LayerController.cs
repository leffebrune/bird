using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class UI_LayerController : MonoBehaviour
{
    public StagePlayer player;

    GameObject panel;
    List<UIPackage_LayerInfo> packages = new List<UIPackage_LayerInfo>();

    bool initialized = false;

    void Awake()
    {
        panel = Util.Find(gameObject, "ScrollPanel");
    }

    void Init()
    {
        packages.Clear();
        var prefab = Resources.Load("UI_Prefabs/UIPackage_LayerInfo");
        var packageHeight = 70.0f;
        foreach (var l in player.layers)
        {
            var obj = Instantiate(prefab) as GameObject;
            var package = obj.GetComponent<UIPackage_LayerInfo>();
            package.Set(l);
            packageHeight = obj.GetComponent<RectTransform>().sizeDelta.y;

            obj.transform.SetParent(panel.transform);
            packages.Add(package);            
        }

        var rectPanel = panel.GetComponent<RectTransform>();
        var sd = rectPanel.sizeDelta;
        sd.y = player.layers.Count * packageHeight;
        rectPanel.sizeDelta = sd;
    }

    void Update()
    {
        if (!initialized)
        {
            if (player.layers.Count > 0)
            {
                initialized = true;
                Init();
            }
        }
    }
}
