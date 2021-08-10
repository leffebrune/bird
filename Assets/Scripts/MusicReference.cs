using UnityEngine;
using System.Collections.Generic;

public class MusicReference : MonoBehaviour
{
    public static MusicReference Instance;

    public List<AudioClip> clips;

    void Awake()
    {
        Instance = this;
    }

    public AudioClip Get(string name)
    {
        foreach (var c in clips)
        {
            if (c.name == name)
                return c;
        }
        return null;
    }
}
