using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;

[CustomEditor(typeof(StageEditor))]
public class StageEditorTool : Editor
{
    //List<bool> foldouts = new List<bool>();

    void DrawList(ref List<string> list)
    {
        var removeIndex = -1;
        for (var i = 0; i < list.Count; i++)
        {
            var b = list[i];
            EditorGUILayout.BeginHorizontal();
            list[i] = EditorGUILayout.TextField(b);
            if (GUILayout.Button("-", GUILayout.ExpandWidth(false)))
            {
                if (EditorUtility.DisplayDialog("Remove Item", "are you sure remove " + b + "?", "OK", "NO"))
                    removeIndex = i;
            }
            EditorGUILayout.EndHorizontal();
        }
        if (removeIndex >= 0)
            list.RemoveAt(removeIndex);

        if (GUILayout.Button("Add New Item"))
            list.Add("");
    }

    void DrawPrefabList(ref List<StageData.EntityPrefab> list)
    {
        var removeIndex = -1;
        for (var i = 0; i < list.Count; i++)
        {
            var b = list[i];
            EditorGUILayout.BeginHorizontal();
            b.name = EditorGUILayout.TextField(b.name);
            b.chance = Convert.ToSingle(EditorGUILayout.TextField(b.chance.ToString()));
            list[i] = b;
            if (GUILayout.Button("-", GUILayout.ExpandWidth(false)))
            {
                if (EditorUtility.DisplayDialog("Remove Item", "are you sure remove " + b.name + "?", "OK", "NO"))
                    removeIndex = i;
            }
            EditorGUILayout.EndHorizontal();
        }
        if (removeIndex >= 0)
            list.RemoveAt(removeIndex);

        if (GUILayout.Button("Add New Item"))
            list.Add(new StageData.EntityPrefab() { name = "", chance = 100 });
    }
    
    public override void OnInspectorGUI()
    {
//         if (!Application.isPlaying)
//             return;
// 
//         StageEditor editor = (StageEditor)target;
// 
//         if (editor.isPlaying)
//         {
//             if (GUILayout.Button("STOP"))
//                 editor.Stop();
//             return;
//         }
// 
//         var bigFont = new GUIStyle();
//         bigFont.fontSize = 15;
//         // 배경리스트 
//         GUILayout.Label("Background", bigFont);
//         DrawList(ref editor.Data.backgrounds);
//         EditorUtil.HorziontalLineWithSpace();
// 
//         ///////////////////////////////////////////////////////
//         // 데코레이션 리스트 
//         GUILayout.Label("Decoration", bigFont);
//         DrawList(ref editor.Data.decorations);
//         EditorUtil.HorziontalLineWithSpace();
// 
//         ///////////////////////////////////////////////////////
//         // 엔티티 리스트 
//         GUILayout.Label("Entities", bigFont);
//         EditorUtil.HorziontalLineWithSpace();
// 
//         if (foldouts.Count != editor.Data.entities.Count)
//             foldouts.Resize(editor.Data.entities.Count);
// 
//         var removeEntityIndex = -1;
//         for (var i = 0; i < editor.Data.entities.Count; i++)
//         {
//             var b = editor.Data.entities[i];
//             var title = "";
//             if (b.prefabs.Count > 0)
//                 title = b.prefabs[0].name;
//             foldouts[i] = EditorGUILayout.Foldout(foldouts[i], title);
//             if (foldouts[i])
//             {
//                 if (GUILayout.Button("Remove this entity", GUILayout.ExpandWidth(false)))
//                 {
//                     if (EditorUtility.DisplayDialog("Remove Item", "are you sure remove this?", "OK", "NO"))
//                         removeEntityIndex = i;
//                 }
// 
//                 EditorUtil.HorizontalLine();
//                 GUILayout.Label("prefabs");
//                 EditorGUILayout.Space();
//                 DrawPrefabList(ref b.prefabs);
//                 var _min = EditorGUILayout.TextField("Interval Min : ", b.intervalMin.ToString());
//                 b.intervalMin = Convert.ToSingle(_min);
//                 var _max = EditorGUILayout.TextField("Interval Max : ", b.intervalMax.ToString());
//                 b.intervalMax = Convert.ToSingle(_max);
//             }
//         }
//         if (removeEntityIndex >= 0)
//             editor.Data.entities.RemoveAt(removeEntityIndex);
// 
//         EditorUtil.HorziontalLineWithSpace();
// 
//         if (GUILayout.Button("Add new Entity"))
//         {
//             editor.Data.entities.Add(new StageData.Entity());
//         }
//         EditorUtil.HorziontalLineWithSpace();
//         if (GUILayout.Button("SAVE"))
//         {
//             var str = editor.Data.Save();
//             Debug.Log(Application.dataPath);
//             var file = File.Create(Application.dataPath + "/Resources/Data/TestStage.json");
//             var writer = new StreamWriter(file);
//             writer.WriteLine(str);
//             writer.Close();
//             file.Close();
//         }
//         EditorUtil.HorziontalLineWithSpace();
//         if (GUILayout.Button("PLAY"))
//         {
//             editor.Play();
//         }
     }
}