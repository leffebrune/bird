using UnityEngine;
using System.Collections.Generic;

public class StageSegmentManager : Singleton<StageSegmentManager>
{
    Dictionary<string, StageSegment> data = new Dictionary<string, StageSegment>();
    List<string> keys = new List<string>();

    public void Load()
    {
        var t = Resources.Load<TextAsset>("Data/SegmentsInfo");
        JSONUtil.LoadKeyValues(t.text, (key, json) =>
        {
            var segment = new StageSegment();

            segment.Load(key);

            data[key] = segment;

            if (key != "start")
                keys.Add(key);
        });
    }

    public static StageSegment Get(string name)
    {
        StageSegment result;
        Instance.data.TryGetValue(name, out result);
        return result;
    }

    public static string GetRandom()
    {
        return Instance.keys[Random.Range(0, Instance.keys.Count)];
    }
}
