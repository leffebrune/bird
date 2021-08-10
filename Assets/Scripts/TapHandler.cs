using UnityEngine;
using System.Linq;
using System;
using UnityEngine.EventSystems;

public class TapHandler : MonoBehaviour, IPointerDownHandler
{
    public Action handler = null;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (handler != null)
            handler();
    }
}
