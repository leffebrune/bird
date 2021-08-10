using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SegmentCapture
{
    static readonly string[] logicLayers = { "balloon", "postcard", "thundercloud", "wind" };

    public static List<GameObject> GetLayersObject()
    {
        List<GameObject> ret = new List<GameObject>();

        var objects = GameObject.FindObjectsOfType<GameObject>();
        Array.ForEach(objects, (go) =>
        {
            if (go.GetComponent<Environment>() != null)
                return;
            if (go.GetComponent<Camera>() != null)
                return;

            if (go.transform.parent == null)
                ret.Add(go);
        });


        var _l = ret;
        foreach (var ll in logicLayers)
        {
            var finded = false;
            foreach (var l in _l)
            {
                if (l.name == ll)
                {
                    finded = true;
                    break;
                }
            }

            if (!finded)
            {
                var go = new GameObject(ll);
                ret.Add(go);
            }
        }

        return ret;
    }

    public static void Capture()
    {
        var path = EditorUtility.SaveFilePanel("Save segment", "Assets/Resources/Data/Segments", "segment.json", "json");
        if (path.Length == 0)
            return;

        var layers = GetLayersObject();

        var json = new JSONObject(JSONObject.Type.OBJECT);

        foreach (var l in layers)
        {
            var layer = new JSONObject(JSONObject.Type.ARRAY);
            foreach (Transform t in l.transform)
            {
                var prefab = PrefabUtility.GetPrefabParent(t.gameObject);
                if (prefab == null)
                    return;

                var layerItem = new JSONObject(JSONObject.Type.OBJECT);
                layerItem.AddField("Prefab", prefab.name);
                layerItem.AddField("X", t.position.x);
                layerItem.AddField("Y", t.position.y);
                layer.Add(layerItem);
            }

            json.AddField(l.name, layer);
        }

        var result = json.Print(true);

        System.IO.File.WriteAllText(path, result, System.Text.Encoding.UTF8);
    }

    public static void Load()
    {
        var path = EditorUtility.OpenFilePanel("load segment", "Assets/Resources/Data/Segments", "json");
        if (path.Length == 0)
            return;

        var fileName = System.IO.Path.GetFileNameWithoutExtension(path);

        var segment = new StageSegment();
        segment.Load(fileName);

        var layers = Reset();

        foreach (var seg in segment.segmentInfo)
        {
            GameObject layer = null;
            foreach (var l in layers)
            {
                if (l.name == seg.Key)
                {
                    layer = l;
                    break;
                }
            }

            if (layer == null)
                continue;
            
            foreach (var item in seg.Value)
            {
                var prefab = Resources.Load<GameObject>("Prefabs/" + item.prefab);
                var go = PrefabUtility.InstantiatePrefab(prefab) as GameObject;

                go.transform.SetParent(layer.transform);
                go.transform.position = item.position;
            }
        }
    }

    public static List<GameObject> Reset()
    {
        var layers = GetLayersObject();

        foreach (var go in layers)
        {
            var list = new List<GameObject>();
            foreach (Transform c in go.transform)
            {
                list.Add(c.gameObject);
            }
            list.ForEach(g => GameObject.DestroyImmediate(g));
        }
        return layers;
    }
}