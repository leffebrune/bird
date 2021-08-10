using UnityEngine;
using System;
using System.Collections.Generic;

public class StageSegment
{
    public struct Item
    {
        public string prefab;
        public Vector2 position;
    }

    public string Name;

    public Dictionary<string, List<Item>> segmentInfo = new Dictionary<string, List<Item>>();
    
    public void Load(string name)
    {
        Name = name;
        var path = "Data/Segments/" + name;
        var t = Resources.Load<TextAsset>(path);
        if (t == null)
            return;
        JSONUtil.LoadKeyValues(t.text, (key, json) =>
        {
            var segments = new List<Item>();

            foreach (JSONObject j in json.list)
            {
                if (j.type == JSONObject.Type.OBJECT)
                {
                    var _prefab = JSONUtil.GetStringValue(j, "Prefab");
                    var _x = JSONUtil.GetFloatValue(j, "X");
                    var _y = JSONUtil.GetFloatValue(j, "Y");
                    segments.Add(new Item() { prefab = _prefab, position = new Vector2(_x, _y) });
                }
            }
            
            segmentInfo[key] = segments;
        });
    }    
}
