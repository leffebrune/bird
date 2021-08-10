using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;

public static class EditorUtil
{
    public static void HorizontalLine()
    {
        GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(2));
    }

    public static void HorziontalLineWithSpace()
    {
        HorizontalLine();
        EditorGUILayout.Space();
    }

//     [MenuItem("Tools/Reset Sound Reference")]
//     static public void ResetSoundReference()
//     {        
//         DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "/Sounds");
//         FileInfo[] info = dir.GetFiles("*.ogg");
//         MusicReference.Instance.clips.Clear();
//         foreach (FileInfo f in info)
//         {
//             WWW www = new WWW("file://" + f.FullName);
//             AudioClip myAudioClip = www.audioClip;
//             AudioClip clip = www.GetAudioClip(false);
//             string[] parts = f.FullName.Split('\\');
//             clip.name = parts[parts.Length - 1];
//             MusicReference.Instance.clips.Add(clip);
//         }
//     }

}