using UnityEngine;
using System.Linq;
using System;

public class SetSortingOrderAlpha : MonoBehaviour
{
    void Awake()
    {
        var children = gameObject.GetComponentsInChildren<SpriteRenderer>();
        
        foreach (var sr in children)
        {
            var mname = sr.sharedMaterial.name.ToLower();
            if (mname.Contains("alpha"))
                sr.sortingOrder = 2;
            else
                sr.sortingOrder = 0;
        }
    }
}
