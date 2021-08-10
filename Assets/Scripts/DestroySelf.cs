using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour
{
    public float lifetime = 1.0f;

    float createdTime = 0.0f;
    float _scrollSpeed = 0.0f;

    public float ScrollSpeed { set { _scrollSpeed = value; } }

    void OnEnable()
    {
        createdTime = Time.time;
    }

    void Update()
    {
        gameObject.MoveX((GameData.Instance.ScrollSpeed - _scrollSpeed) * Time.deltaTime);

        if (Time.time > createdTime + lifetime)
            ObjectPool.Release(gameObject);
    }
}
