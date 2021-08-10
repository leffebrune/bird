using UnityEngine;
using System.Collections.Generic;

public class StageData 
{
    public struct EntityPrefab
    {
        public string name;
        public float chance;
    }
    public class Entity
    {
        public List<EntityPrefab> prefabs = new List<EntityPrefab>();

        public float intervalMin = 0.0f;
        public float intervalMax = 0.0f;
    }

    public List<string> backgrounds = new List<string>();
    public List<string> decorations = new List<string>();
    public List<Entity> entities = new List<Entity>();

    void LoadSingleEntity(JSONObject jobj)
    {
        if (jobj.type == JSONObject.Type.OBJECT)
        {
            var e = new Entity();
            JSONUtil.LoadKeyValues(jobj, (key2, json) =>
            {
                if (key2 == "Name")
                    JSONUtil.LoadStringSelection(json, ref e.prefabs);
                else if (key2 == "IntervalMin")
                    e.intervalMin = json.n;
                else if (key2 == "IntervalMax")
                    e.intervalMax = json.n;
            });
            entities.Add(e);
        }
    }

    void LoadEntities(JSONObject jobj)
    {
        entities.Clear();

        if (jobj.type == JSONObject.Type.ARRAY)
        {
            foreach (JSONObject j in jobj.list)
            {
                LoadSingleEntity(j);
            }
        }
    }
    
    public void Load(string data)
    {
        JSONUtil.LoadKeyValues(data, (key, json) =>
        {
            if (key == "Background")
            {
                JSONUtil.LoadStringArray(json, ref backgrounds);
            }
            else if (key == "Decoration")
            {
                JSONUtil.LoadStringArray(json, ref decorations);
            }
            else if (key == "Entity")
            {
                LoadEntities(json);
            }            
        });
    }

    JSONObject SaveSingleEntity(Entity e)
    {
        var ret = new JSONObject(JSONObject.Type.OBJECT);
        ret.AddField("Name", JSONUtil.SaveStringSelection(e.prefabs));
        ret.AddField("IntervalMin", e.intervalMin);
        ret.AddField("IntervalMax", e.intervalMax);
        return ret;
    }
    JSONObject SaveEntities()
    {
        var ret = new JSONObject(JSONObject.Type.ARRAY);
        foreach (var e in entities)
            ret.Add(SaveSingleEntity(e));
        return ret;
    }

    public string Save()
    {
        var root = new JSONObject(JSONObject.Type.OBJECT);
        root.AddField("Background", JSONUtil.SaveStringArray(backgrounds));
        root.AddField("Decoration", JSONUtil.SaveStringArray(decorations));
        root.AddField("Entity", SaveEntities());
        return root.ToString(true);
    }
}
