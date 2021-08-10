using UnityEngine;
using System.Collections;

public class ImpactField : MonoBehaviour
{
    void OnTriggered(Player b)
    {
        b.verticalSpeed = -3.0f;
        b.AddBuff("BlockControl", 0.3f);
    }

    void OnStay(Player b)
    {
        b.verticalSpeed = -3.0f;
        b.AddBuff("BlockControl", 0.3f);
    }

    void Start()
    {
    }
}
