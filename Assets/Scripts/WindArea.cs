using UnityEngine;
using System.Collections;

public class WindArea : LogicObject
{
    public float power = 1.5f;
    public float upward_limit = 2.0f;
    public float downward_limit = -2.0f;
    public float speedAdjust = 0.0f;
    public bool upward = true;

    public string areaEffect = "";

    void Initialize()
    {
        _destroyWhenCollide = false;
        _isObstacle = false;
    }

    void OnTriggered(Player b)
    {
        if (areaEffect != "")
            b.LoopEffect(areaEffect);
    }

    void OnExit(Player b)
    {
        b.StopEffect(areaEffect);
    }

    void OnStay(Player b)
    {
        if (b == null)
            return;

        if (b.ExistBuff("BlockControl"))
            return;

        if (upward)
        {
            if (b.verticalSpeed < downward_limit)
                b.verticalSpeed = downward_limit;
            if (b.verticalSpeed < upward_limit)
                b.verticalSpeed += power * Time.deltaTime;
        }
        else
        {
            if (b.verticalSpeed > upward_limit)
                b.verticalSpeed = upward_limit;
            if (b.verticalSpeed > downward_limit)
                b.verticalSpeed -= power * Time.deltaTime;
        }
        b.additionalSpeed = speedAdjust;
    }
}
