using UnityEngine;
using System.Collections;

public class Item_Mail : LogicObject
{
    public float amount = 10;

    void Initialize()
    {
        _destroyWhenCollide = true;
        _isObstacle = false;
    }

    void OnTriggered(Player b)
    {
        if (b == null)
            return;

        b.Score += amount;
        SoundManager.Instance.Play(Util.GetRandom(new string[] {
            "SFX_GET_ITEM_01", "SFX_GET_ITEM_02", "SFX_GET_ITEM_03" }));
    }
}
