using System;
using UnityEngine;

public class StageLayerContinuous : StageLayerBase
{
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
        float xPos;
        if (ScrollSpeed >= 0.0f)
        {
            if (lastObject == null)
                xPos = -ScreenWidth - bound.min.x + CameraPos();
            else
                xPos = lastObject.RightEnd - bound.min.x;
        }
        else
        {
            if (lastObject == null)
                xPos = ScreenWidth - bound.min.x + CameraPos();
            else
                xPos = lastObject.LeftEnd - bound.max.x;
        }

        return xPos;
    }


    public override void Load(JSONObject jobj)
    {
        LoadBase(jobj);
    }
}
