using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PerformanceTool : MonoBehaviour
{
    GameObject objectinfo;
    GameObject layerinfo;

    void Awake()
    {
        objectinfo = Util.Find(gameObject, "UI_ObjectPoolInfo");
        layerinfo = Util.Find(gameObject, "UI_LayerController");
    }
    

    public void ToggleChanged(bool b)
    {
        objectinfo.SetActive(b);
        layerinfo.SetActive(b);
    }    
}
