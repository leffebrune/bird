using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SegmentView : MonoBehaviour
{
    GameObject viewRoot;
    void Start()
    {
        var objects = GameObject.FindObjectsOfType<GameObject>();
        var layers = new List<GameObject>();
        Array.ForEach(objects, (go) =>
        {
            if (go.GetComponent<Environment>() != null)
                return;
            if (go.GetComponent<Camera>() != null)
                return;

            if (go.transform.parent == null)
                layers.Add(go);
        });

        foreach (var go in layers)
        {
            Destroy(go);
        }

        viewRoot = new GameObject("viewRoot");
    }

    public void ResetView()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}