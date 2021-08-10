using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    void Play(string name)
    {
        SoundManager.Instance.Play(name);
    }
}
