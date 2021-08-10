using UnityEngine;
using System.Collections;

public class Item_Coin : LogicObject
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

        //b.Coin += amount;
        SoundManager.Instance.Play(Util.GetRandom(new string[] {
            "SFX_GET_ITEM_01", "SFX_GET_ITEM_02", "SFX_GET_ITEM_03" }));
    }
}
