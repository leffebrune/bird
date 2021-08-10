using System;
using UnityEngine;

public class StageLayerInterval : StageLayerBase
{
    public float intervalMin = 0.0f;
    public float intervalMax = 0.0f;

    protected override bool NeedSpawn()
    {
        if (entities.Count == 0)
            return false;

        if (lastObject == null)
            return true;

        if (ScrollSpeed >= 0.0f)
        {
            if (lastObject.RightEnd < ScreenWidth + CameraPos())
                return true;
        }
        else
        {
            if (lastObject.LeftEnd > -ScreenWidth + CameraPos())
                return true;
        }
        return false;
    }

    protected override float GetNextObjectPos(Bounds bound)
    {
        var interval = UnityEngine.Random.Range(intervalMin, intervalMax);
        float xPos;
        if (ScrollSpeed >= 0.0f)
        {
            if (lastObject == null)
                xPos = -ScreenWidth - bound.min.x + CameraPos();
            else
                xPos = (lastObject.RightEnd - bound.min.x) + interval;
        }
        else
        {
            if (lastObject == null)
                xPos = ScreenWidth - bound.min.x + CameraPos();
            else
                xPos = (lastObject.LeftEnd - bound.max.x) - interval;
        }

        return xPos;
    }

    protected override void AdjustSpeed(StageObject sObj, Entity newEntity)
    {
        var pooledObj = sObj.GetComponent<PooledObject>();
        if (pooledObj != null)
        {
            var scale = 1.0f;
            var zOffset = 0.0f;
            if (newEntity.speedOffset > 0.0f)
            {
                var currentSpeedOffset = UnityEngine.Random.Range(0, newEntity.speedOffset);
                scale = Mathf.Lerp(1.0f, 1.2f, currentSpeedOffset / newEntity.speedOffset);
                zOffset = Mathf.Lerp(0.0f, 1.0f, currentSpeedOffset / newEntity.speedOffset);

                sObj.movingSpeed = ScrollSpeed + currentSpeedOffset;
                sObj.gameObject.MoveZ(-zOffset);
                sObj.gameObject.transform.localScale = new Vector3(
                    scale * pooledObj.initialScale.x, 
                    scale * pooledObj.initialScale.y, 
                    1.0f);
            }
        }
    }

    public override void Load(JSONObject jobj)
    {
        LoadBase(jobj);

        JSONUtil.LoadKeyValues(jobj, (key, json) =>
        {
            if (key == "IntervalMin")
                intervalMin = json.n;
            else if (key == "IntervalMax")
                intervalMax = json.n;
        });
    }

}
