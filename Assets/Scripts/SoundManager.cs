using UnityEngine;
using System.Collections.Generic;

public class SoundManager : Singleton<SoundManager>
{
    AudioSource bgm;

    List<AudioSource> listSounds = new List<AudioSource>();

    void Awake()
    {
        bgm = gameObject.AddComponent<AudioSource>();
        bgm.playOnAwake = false;
    }

    AudioSource FindEmptyChannel()
    {
        foreach (var a in listSounds)
        {
            if (!a.isPlaying)
                return a;
        }
        var obj = new GameObject("S");
        obj.transform.parent = gameObject.transform;
        var sound = obj.AddComponent<AudioSource>();
        sound.playOnAwake = false;
        listSounds.Add(sound);
        return sound;
    }

    public void PlayBGM(string musicName)
    {
        bgm.name = musicName;
        bgm.clip = MusicReference.Instance.Get(musicName);
        bgm.Play();
    }

    public void StopBGM()
    {
        bgm.Stop();
    }

    public void Play(string soundName)
    {
        var a = FindEmptyChannel();
        a.name = soundName;
        a.clip = MusicReference.Instance.Get(soundName);
        a.Play();
    }

}
