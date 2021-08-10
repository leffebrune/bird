using UnityEngine;
using System.Linq;
using System;
using UnityEngine.EventSystems;

public class TapToClose : TapHandler
{
    void Awake()
    {
        handler = () => gameObject.SetActive(false);
    }
}
