using System;
using UnityEngine;

public class StageLayerLogic : StageLayerInterval
{
    protected override bool NeedSpawn()
    {
        if (!logicPlaying)
            return false;

        return base.NeedSpawn();
    }

    protected override float GetNextObjectPos(Bounds bound)
    {
        if (forceSpawn)
        {
            // 첨나오는건 좀 빨리나오게
            var interval = UnityEngine.Random.Range(intervalMin, intervalMax) * 0.2f;
            if (ScrollSpeed >= 0.0f)
                return ScreenWidth - bound.min.x + interval + CameraPos();
            else
                return -ScreenWidth - bound.min.x - interval + CameraPos();
        }
        return base.GetNextObjectPos(bound);
    }

    protected override void AdjustSpeed(StageObject sObj, Entity newEntity)
    {
    }

    protected override void OnStartLogic()
    {
        if (ScrollSpeed >= 0.0f)
        {
            if ((lastObject == null) || (lastObject.xPos < ScreenWidth + CameraPos()))
            {
                forceSpawn = true;
            }
        }
        else
        {
            if ((lastObject == null) || (lastObject.xPos > -ScreenWidth + CameraPos()))
            {
                forceSpawn = true;
            }
        }
        base.OnStartLogic();
    }

    protected override void OnStopLogic()
    {
        foreach (var so in stageObjects)
        {
            ObjectPool.Release(so.gameObject);
        }
        stageObjects.Clear();
        lastObject = null;
    }
}
