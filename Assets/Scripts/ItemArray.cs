using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemArray : MonoBehaviour
{
    public string itemPrefab;

    List<GameObject> pos_items;
    List<GameObject> attachedObjects = new List<GameObject>();

    void Awake()
    {
        pos_items = Util.FindAll_StartsWith(gameObject, "pos");
    }

    void SpawnItems()
    {
        foreach (var pos in pos_items)
        {
            var obj = ObjectPool.Get(itemPrefab, pos);
            if (obj == null)
            {
                Debug.LogErrorFormat("Cannnot find prefab in ItemArray : [{0}]", itemPrefab);
                return;
            }
            obj.transform.localPosition = Vector3.zero;
            var a = obj.MakeComponent<AttachedObject>();
            a.parent = gameObject;
            attachedObjects.Add(obj);
        }
    }
 
    void Initialize()
    {
        attachedObjects.Clear();

        SpawnItems();
    }

    void OnRelease()
    {
        foreach (var obj in attachedObjects)
            ObjectPool.Release(obj);
    }

    void Update()
    {
    }
}
