using UnityEngine;
using System.Collections;

public class CollideEffect : MonoBehaviour
{
    public string effectName;

    Vector3 center;

    void Awake()
    {
        var collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            center = collider.bounds.center;
        }
    }

    void OnTriggered(Player b)
    {
        var newObj = ObjectPool.Get(effectName);
        if (newObj != null)
        {
            var effectPos = gameObject.transform.position + center;
            newObj.transform.position = effectPos;
            var fixedObject = newObj.GetComponent<CameraFixedObject>();
            if (fixedObject != null)
            {
                fixedObject.position = effectPos - Camera.main.transform.position;
            }
            var destroyComp = newObj.GetComponent<DestroySelf>();
            if (destroyComp != null)
            {
                var otherObj = gameObject;
                var attachedObj = GetComponent<AttachedObject>();
                if (attachedObj != null)
                    otherObj = attachedObj.parent;
                

                var stageObj = otherObj.GetComponent<StageObject>();
                if (stageObj != null)
                    destroyComp.ScrollSpeed = stageObj.movingSpeed;
            }
        }
    }
}
