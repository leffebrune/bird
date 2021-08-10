using UnityEngine;
using System.Linq;
using System;

public class SetSortingOrder : MonoBehaviour
{
    public string objectPrefix = "";
    public int sortingOrder;

    void Awake()
    {
        var children = Util.FindAll_StartsWith(gameObject, objectPrefix);
        foreach (var go in children)
        {
            var mr = go.GetComponent<MeshRenderer>();
            if (mr != null)
                mr.sortingOrder = sortingOrder;
        }
    }
}
