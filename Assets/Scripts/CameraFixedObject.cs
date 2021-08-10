using UnityEngine;
using System.Collections;

public class CameraFixedObject : MonoBehaviour
{
    public Vector2 position;
    public float verticalParallaxRatio = 0.0f;

    void SetPosition(Vector2 pos)
    {
        position = pos;
    }

    void Update()
    {
        var yPos = Mathf.Lerp(0.0f, Camera.main.transform.position.y, verticalParallaxRatio);
        transform.position = new Vector3(
            Camera.main.transform.position.x + position.x,
            yPos + position.y, 
            transform.position.z);
    }
}
