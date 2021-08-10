using System.Collections.Generic;
using System;
using UnityEngine;

public class JSONUtil
{
    public static void LoadDictionary<V>(string str, ref Dictionary<string, V> target, Func<JSONObject, V> parseValue)
    {
        var json = new JSONObject(str);
        LoadDictionary(json, ref target, parseValue);
    }

    public static void LoadDictionary<V>(JSONObject json, ref Dictionary<string, V> target, Func<JSONObject, V> parseValue)
    {
        if (json == null)
            return;

        target.Clear();

        if (json.type == JSONObject.Type.OBJECT)
        {
            for (var i = 0; i < json.list.Count; i++)
            {
                var key = json.keys[i];
                var value = parseValue(json.list[i]);
                target[key] = value;
            }
        }
    }

    public static JSONObject GetChild(JSONObject jobj, string key)
    {
        return jobj[key];
    }

    public static bool GetBooleanValue(JSONObject jobj, string key)
    {
        var v = jobj[key];
        if (v == null)
            return false;

        return (v.n > 0.0f);
    }

    public static float GetFloatValue(JSONObject jobj, string key)
    {
        var v = jobj[key];
        if (v == null)
            return 0.0f;
        return v.n;
    }

    public static string GetStringValue(JSONObject jobj, string key)
    {
        var v = jobj[key];
        if (v == null)
            return string.Empty;
        return v.str;
    }

    public static Vector2 GetVector2(JSONObject jobj, string key)
    {
        var v = jobj[key];
        if (v == null)
            return Vector2.zero;

        if (v.IsArray)
        {
            if (v.list.Count >= 2)
            {
                var x = v.list[0].n;
                var y = v.list[1].n;
                return new Vector2(x, y);
            }
        }
        return Vector2.zero;
    }

    public static void LoadKeyValues(string str, Action<string, JSONObject> callback)
    {
        var json = new JSONObject(str);
        LoadKeyValues(json, callback);
    }

    public static void LoadKeyValues(JSONObject jobj, Action<string, JSONObject> callback)
    {
        if (jobj.type == JSONObject.Type.OBJECT)
        {
            for (var i = 0; i < jobj.list.Count; i++)
            {
                callback(jobj.keys[i], jobj.list[i]);
            }
        }
    }
        
    public static JSONObject SaveKeyValues<T>(Dictionary<string, T> items, Func<T, JSONObject> callback)
    {
        var json = new JSONObject(JSONObject.Type.OBJECT);
        foreach (var s in items)
        {
            json.AddField(s.Key, callback(s.Value));
        }
        return json;
    }
        
    public static JSONObject SaveIntDictionary(Dictionary<string, int> items)
    {
        var json = new JSONObject(JSONObject.Type.OBJECT);
        foreach (var s in items)
        {
            json.AddField(s.Key, s.Value);
        }
        return json;
    }

    public static void LoadFloatArray(JSONObject jobj, ref List<float> output)
    {
        output.Clear();
        if (jobj.type == JSONObject.Type.NUMBER)
            output.Add(jobj.n);
        else if (jobj.type == JSONObject.Type.ARRAY)
        {
            foreach (JSONObject j in jobj.list)
            {
                if (j.type == JSONObject.Type.NUMBER)
                    output.Add(j.n);
            }
        }
    }

    public static void LoadStringArray(JSONObject jobj, ref List<string> output)
    {
        output.Clear();
        if (jobj.type == JSONObject.Type.STRING)
            output.Add(jobj.str);
        else if (jobj.type == JSONObject.Type.ARRAY)
        {
            foreach (JSONObject j in jobj.list)
            {
                if (j.type == JSONObject.Type.STRING)
                    output.Add(j.str);
            }
        }
    }

    public static void LoadStringSelection(JSONObject jobj, ref List<StageData.EntityPrefab> output)
    {
        output.Clear(); 
        if (jobj.type == JSONObject.Type.OBJECT)
        {
            for (var i = 0; i < jobj.list.Count; i++)
            {
                if (jobj.list[i].type == JSONObject.Type.NUMBER)
                    output.Add(new StageData.EntityPrefab() { name = jobj.keys[i], chance = jobj.list[i].n });
            }
        }
    }

    public static JSONObject SaveStringArray(List<string> input)
    {
        var ret = new JSONObject(JSONObject.Type.ARRAY);
        foreach (var s in input)
        {
            ret.Add(s);
        }
        return ret;
    }

    public static JSONObject SaveStringSelection(List<StageData.EntityPrefab> input)
    {
        var ret = new JSONObject(JSONObject.Type.OBJECT);
        foreach (var s in input)
        {
            ret.AddField(s.name, s.chance);
        }
        return ret;
    }
}