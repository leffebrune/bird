using UnityEngine;
using System.Linq;
using System;

public class AvoidObstacle : MonoBehaviour
{
    public float yOffset = 0;

    void Initialize()
    {
    }

    void OnEnterScreen()
    {
        var stageObj = GetComponent<StageObject>();
        if (stageObj == null)
            return;

        if (stageObj.isSegment)
            return;

        var colliderSize = 0.0f;
        var boxcollier = GetComponent<BoxCollider2D>();
        if (boxcollier != null)
        {
            colliderSize = boxcollier.bounds.extents.y;
        }

        var result = Physics2D.RaycastAll(transform.position, Vector2.down, 12.0f).ToList();
        result.AddRange(Physics2D.RaycastAll(new Vector2(stageObj.LeftEnd, 5.0f), Vector2.down, 12.0f));
        result.AddRange(Physics2D.RaycastAll(new Vector2(stageObj.RightEnd, 5.0f), Vector2.down, 12.0f));
        result.Sort((a, b) => a.distance.CompareTo(b.distance));

        for (var i = 0; i < result.Count; i++)
        {
            var r = result[i];
            if (r.collider.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
            {
                Util.SetPos(gameObject, r.point);

                var newY = UnityEngine.Random.Range(r.point.y + yOffset + colliderSize, stageObj.yMax - colliderSize);
                stageObj.gameObject.SetY(newY);
                return;
            }
        }
    }
    
    void Start()
    {
    }
}
