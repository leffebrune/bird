using UnityEngine;
using UnityEditor;

public class GameTools
{
    const string menuName = "Tools";
    [MenuItem(menuName + "/Reset Setttings")] 
    public static void ResetSettings()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();            
    }

    [MenuItem(menuName + "/Segment Capture")]
    public static void CaptureSegment()
    {
        SegmentCapture.Capture();
    }

    [MenuItem(menuName + "/Segment Load")]
    public static void LoadSegment()
    {
        SegmentCapture.Load();
    }

    [MenuItem(menuName + "/Segment Clear")]
    public static void ClearSegment()
    {
        SegmentCapture.Reset();
    }
}