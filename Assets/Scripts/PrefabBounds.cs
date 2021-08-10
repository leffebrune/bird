using UnityEngine;
using System.Collections.Generic;
using System;

public class PrefabBounds : Singleton<PrefabBounds>
{
    Dictionary<string, Bounds> prefabBounds = new Dictionary<string, Bounds>();

    public static void Calculate(string prefabName, GameObject obj)
    {
        if (!Instance.prefabBounds.ContainsKey(prefabName))
            Instance._Calculate(prefabName, obj);
    }

    public static Bounds Get(string prefabName)
    {
        if (Instance.prefabBounds.ContainsKey(prefabName))
            return Instance.prefabBounds[prefabName];
        return new Bounds(Vector3.zero, Vector3.zero);
    }

    Bounds GetBound(GameObject obj)
    {
        var sr = obj.GetComponent<SpriteRenderer>();
        if ((sr != null) && (sr.enabled))
            return sr.bounds;

        var col = obj.GetComponent<Collider2D>();
        if (col != null)
            return col.bounds;

        var r = obj.GetComponent<Renderer>();
        if (r != null)
            return r.bounds;

        sr = obj.GetComponentInChildren<SpriteRenderer>();
        if ((sr != null) && (sr.enabled))
            return sr.bounds;

        return new Bounds(Vector3.zero, Vector3.zero);
    }

    void CalculateChild(GameObject obj, ref Bounds _bound)
    {
        _bound.Encapsulate(GetBound(obj));
        foreach (Transform child in obj.transform)
        {
            CalculateChild(child.gameObject, ref _bound);
        }
    }
    
    void _Calculate(string prefabName, GameObject obj)
    {
        var _customBound = GetComponentInChildren<CustomBound>();
        if (_customBound != null)
        {
            var col = _customBound.GetComponent<BoxCollider2D>();
            prefabBounds[prefabName] = col.bounds;
            return;
        }

        var _bound = new Bounds(Vector3.zero, Vector3.zero);
        CalculateChild(obj, ref _bound);

        prefabBounds[prefabName] = _bound;
    }

//     public float Get(string prefab)
//     {
//         if (prefabWidths.ContainsKey(prefab))
//             return prefabWidths[prefab];
// 
//         return 5.0f;
//     }    
}
