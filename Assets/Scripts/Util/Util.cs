using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public static class Util
{
    static void _FindAll(GameObject obj, ref List<GameObject> result, Func<Transform, bool> filter)
    {
        foreach (Transform child in obj.transform)
        {
            if (filter(child))
                result.Add(child.gameObject);
            _FindAll(child.gameObject, ref result, filter);
        }
    }

    static GameObject _Find(GameObject obj, Func<Transform, bool> filter)
    {
        foreach (Transform child in obj.transform)
        {
            if (filter(child))
                return child.gameObject;
            var ret = _Find(child.gameObject, filter);
            if (ret != null)
                return ret;
        }
        return null;
    }

    public static void GetChildren(GameObject parent, out List<GameObject> children)
    {
        children = new List<GameObject>();
        foreach (Transform child in parent.transform)
            children.Add(child.gameObject);
    }

    public static GameObject Find(GameObject obj, string name)
    {
        var ret = _Find(obj, (t) => { return t.name == name; });
        if (ret == null)
            Debug.LogFormat("Failed to find : {0}", name);
        return ret;
    }

    public static List<GameObject> FindAll_StartsWith(GameObject obj, string prefix)
    {
        var result = new List<GameObject>();
         _FindAll(obj, ref result, (t) => { return t.name.StartsWith(prefix); });
        return result;
    }

    public static void SetPos(GameObject obj, Vector2 pos)
    {
        var p = obj.transform.position;
        p.x = pos.x;
        p.y = pos.y;
        obj.transform.position = p;
    }
    
    public static void SetZ(GameObject obj, GameObject other)
    {
        var p = obj.transform.position;
        p.z = other.gameObject.transform.position.z;
        obj.transform.position = p;
    }

    public static string GetRandom(List<StageData.EntityPrefab> e)
    {
        var sum = 0.0f;
        e.ForEach(c => sum += c.chance);
        var r = Random.Range(0.0f, sum);
        var sum2 = 0.0f;
        for (var i = 0; i < e.Count; i++)
        {
            sum2 += e[i].chance;
            if (r < sum2)
                return e[i].name;
        }
        return string.Empty;
    }

    public static T GetRandom<T>(T[] candidates, float[] chances)
    {
        if (candidates.Length != chances.Length)
            return default(T);

        var sum = 0.0f;
        Array.ForEach(chances, c => sum += c);
        var r = Random.Range(0.0f, sum);
        var sum2 = 0.0f;
        for (var i = 0; i < candidates.Length; i++)
        {
            sum2 += chances[i];
            if (r <= sum2)
                return candidates[i];
        }
        return default(T);
    }

    public static T GetRandom<T>(T[] candidates)
    {
        var idx = Random.Range(0, candidates.Length);
        return candidates[idx];
    }

    public static bool Probablity(float chance)
    {
        return (Random.Range(0.0f, 100.0f) < chance);
    }

    public static float GetSpriteWidth(GameObject obj)
    {
        var sr = obj.GetComponent<SpriteRenderer>();
        if (sr == null)
            return 1.0f;
        if (sr.sprite == null)
            return 1.0f;
        return sr.sprite.bounds.size.x;
    }

    ////////////////////////////////////////////////////////////////////////////

    public static void Resize<T>(this List<T> list, int size)
    {
        if (size > list.Count)
            while (size - list.Count > 0)
                list.Add(default(T));
        else if (size < list.Count)
            while (list.Count - size > 0)
                list.RemoveAt(list.Count - 1);
    }

    /////////////////////////////////////////////////////////////////////////////

    public static void SetPos(this GameObject obj, float x, float y, float z)
    {
        obj.transform.position = new Vector3(x, y, z);
    }

    public static void SetLocalPos(this GameObject obj, float x, float y, float z)
    {
        obj.transform.localPosition = new Vector3(x, y, z);
    }

    public static void SetPosXY(this GameObject obj, float x, float y)
    {
        var p = obj.transform.position;
        p.x = x;
        p.y = y;
        obj.transform.position = p;
    }

    public static void MoveXY(this GameObject obj, float x, float y)
    {
        var p = obj.transform.position;
        p.x += x;
        p.y += y;
        obj.transform.position = p;
    }

    public static void MoveX(this GameObject obj, float amount)
    {
        var p = obj.transform.position;
        p.x += amount;
        obj.transform.position = p;
    }

    public static void MoveZ(this GameObject obj, float amount)
    {
        var p = obj.transform.position;
        p.z += amount;
        obj.transform.position = p;
    }

    public static void SetY(this GameObject obj, float y)
    {
        var p = obj.transform.position;
        p.y = y;
        obj.transform.position = p;
    }


    /////////////////////////////////////////////////////////////////////////////////

    public static T MakeComponent<T>(this GameObject obj) where T : MonoBehaviour
    {
        var ret = obj.GetComponent<T>();
        if (ret == null)
            ret = obj.AddComponent<T>();
        return ret;
    }

    //////////////////////////////////////////////////////////////////////////////////

    public static void SetText(GameObject obj, string text)
    {
        var _text = obj.GetComponent<Text>();
        if (_text != null)
            _text.text = text;
    }

    public static void SetText(GameObject obj, string childName, string text)
    {
        var child = Find(obj, childName);
        if (child != null)
            SetText(child, text);
    }

    public static void SetButtonEvent(Button btn, UnityAction _action)
    {
        if (btn != null)
            btn.onClick.AddListener(_action);
    }

    public static void SetButtonEvent(GameObject obj, UnityAction _action)
    {
        var button = obj.GetComponent<Button>();
        SetButtonEvent(button, _action);
    }

    public static void SetButtonEvent(GameObject obj, string childName, UnityAction _action)
    {
        var child = Find(obj, childName);
        if (child != null)
            SetButtonEvent(child, _action);
    }

    public static void DeployPackages(GameObject parent, string package, List<string> items, Action<GameObject, string> handler)
    {
        var width = 100.0f;
        foreach (var item in items)
        {
            var obj = ObjectPool.Make(package, parent);
            width = obj.GetComponent<RectTransform>().sizeDelta.x;
            handler(obj, item);
        }

        var rect = parent.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(width * items.Count, rect.sizeDelta.y);
    }

    /////////////////////////////////////////////////////////////////////////////////////////

    public static GameObject Instantiate(string name)
    {
        var obj = Resources.Load<GameObject>(name);
        GameObject ret = GameObject.Instantiate(obj) as GameObject;
        return ret;
    }
}
