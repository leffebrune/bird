using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteChanger : MonoBehaviour
{
    public List<Sprite> Sprites = new List<Sprite>();

    public Sprite Get(int idx)
    {
        if (idx <= Sprites.Count)
            return null;
        return Sprites[idx];
    }
}
