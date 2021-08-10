using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_ObjectPoolInfo : MonoBehaviour
{
    Text textActivated;
    Text textReserved;

    void Awake()
    {
        textActivated = Util.Find(gameObject, "Activated").GetComponent<Text>();
        textReserved = Util.Find(gameObject, "Reserved").GetComponent<Text>();
    }

    void Update()
    {
        textActivated.text = string.Format("Activated : {0}", ObjectPool.ActiveCount);
        textReserved.text = string.Format("Reserved : {0}", ObjectPool.ReservedCount);
    }
}
