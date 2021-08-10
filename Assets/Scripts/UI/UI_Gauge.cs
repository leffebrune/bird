using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Gauge : MonoBehaviour
{
    RectTransform gauge;

    float width;
    public float GaugeMax = 100;
    float _current = 0;

    public float Current
    {
        get { return _current; }
        set { Set(value); }
    }

    void Init()
    {
        gauge = Util.Find(gameObject, "Gauge").GetComponent<RectTransform>();

        var rect = gameObject.GetComponent<RectTransform>();
        width = rect.sizeDelta.x;
    }

    void Awake()
    {
        Init();
        Set(0);
    }
    
    public void Set(float v)
    {
        if (gauge == null)
            Init();
        _current = v;
        gauge.sizeDelta = new Vector2((_current / GaugeMax) * width, gauge.sizeDelta.y);
    }
}
