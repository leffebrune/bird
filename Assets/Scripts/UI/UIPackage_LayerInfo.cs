using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPackage_LayerInfo : MonoBehaviour
{
    Text textLabel;
    Text textCount;
    StageLayerBase stageLayer;

    void Awake()
    {
        textLabel = Util.Find(gameObject, "Label").GetComponent<Text>();
        textCount = Util.Find(gameObject, "TextCount").GetComponent<Text>();
    }

    public void Set(StageLayerBase _layer)
    {
        stageLayer = _layer;
        textLabel.text = stageLayer.Name;
    }

    public void ToggleChanged(bool b)
    {
        if (stageLayer != null)
            stageLayer.SetActive(b);
    }

    void Update()
    {
        if (stageLayer != null)
            textCount.text = string.Format("Count = {0}", stageLayer.ActiveCount);
    }
}
