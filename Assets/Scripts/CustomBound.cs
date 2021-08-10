using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CustomBound : MonoBehaviour
{
    void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer("CustomBound");
    }
}

