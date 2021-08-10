using UnityEngine;
using System.Linq;
using System;
using System.Collections.Generic;

public class Window : MonoBehaviour
{
    MeshRenderer mr;
    bool _enabled = false;
    bool Enable
    {
        get
        {
            return _enabled;
        }
        set
        {
            if (_enabled != value)
            {
                mr.enabled = value;
                _enabled = value;
            }
        }
    }

    void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        Enable = false;
    }

    bool ShouldLightOn()
    {
        return (Environment.Instance.CurrentTime < 0.2f) || (Environment.Instance.CurrentTime > 0.8f);
    }

    void Update()
    {
        if (!Enable)
        {
            if (ShouldLightOn())
            {
                var windowColor = UnityEngine.Random.Range(0, 5);
                mr.sharedMaterial = WindowMaterials.Get(windowColor);
                mr.sortingOrder = windowColor + 10;
                Enable = true;
            }
        }
        else
        {
            if (!ShouldLightOn())
                Enable = false;
        }
    }    
}
