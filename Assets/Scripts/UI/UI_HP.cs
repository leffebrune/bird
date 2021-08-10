using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class UI_HP : MonoBehaviour
{
    public float HP_per_Section;

    public float ItemSpacing = 100;

    float MaxHP;
    List<UIPackage_HPItem> items = new List<UIPackage_HPItem>();
    
    public void Set(float maxHP)
    {
        Clear();
        MaxHP = maxHP;
        int sections = Mathf.CeilToInt(MaxHP / HP_per_Section);

        for (var i = 0; i < sections; i++)
        {
            var item = ObjectPool.Make("UIPackage_HPItem", gameObject);
            item.transform.localPosition = new Vector3(i * ItemSpacing, 0, 0);
            items.Add(item.GetComponent<UIPackage_HPItem>());
        }
    }

    public void UpdateHP(float hp)
    {
        int section = Mathf.CeilToInt(hp / HP_per_Section) - 1;
        for (var i = 0; i < items.Count; i++)
        {
            var item = items[i];
            if (i < section)
            {
                item.Set(1.0f);
            }
            else if ((i > section) || (section < 0))
            {
                item.Set(0.0f);
            }
            else 
            {
                item.Set((hp - (section * HP_per_Section)) / HP_per_Section);
            }
        }
    }

    public void Clear()
    {
        foreach (var item in items)
            Destroy(item.gameObject);
        items.Clear();
    }
}
