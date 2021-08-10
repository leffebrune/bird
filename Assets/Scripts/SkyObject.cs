using UnityEngine;
using System;
using System.Collections.Generic;

public class SkyObject : MonoBehaviour
{
    Vector3 center;
    float xDist = 6.0f;
    float yDist = 5.0f;

    public float Longitude = 0.0f;
    public float verticalParallaxRatio = 0.0f;

    Renderer[] renderers;
    bool rendererEnable = true;

    void Awake()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    void SetRendererEnable(bool b)
    {
        if (b != rendererEnable)
        {
            rendererEnable = b;
            Array.ForEach(renderers, r => r.enabled = rendererEnable);
        }
    }

    void Update()
    {
        var time = Environment.Instance.CurrentTime + (Longitude / 360);
        while (time > 1.0f)
            time -= 1.0f;
        
        SetRendererEnable((time > 0.4f) || (time < 0.1f));

        var r = (1.0f - time) * Mathf.PI * 2;
        
        var yPos = Mathf.Lerp(0.0f, Camera.main.transform.position.y, verticalParallaxRatio);
        center = new Vector3(Camera.main.transform.position.x, yPos, 99);

        gameObject.transform.position = new Vector3(center.x + Mathf.Cos(r) * xDist, center.y + Mathf.Sin(r) * yDist, 99);
    }
}
