using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CustomEditor(typeof(AudioConfig))]
public class AudioConfigEditor : Editor
{
    private bool showList = false;
    private bool showText = false;

    public override void OnInspectorGUI()
    {
        AudioConfig config = (AudioConfig)target;

        
        config.configId = EditorGUILayout.TextField("Config ID", config.configId);
        config.contentType = (AudioContentType)EditorGUILayout.EnumPopup("Content Type", config.contentType);

        
        GUILayout.BeginHorizontal();
        if (GUILayout.Button(showList ? "Hide List" : "Show List"))
        {
            showList = !showList;
            showText = false;
        }
        if (GUILayout.Button(showText ? "Hide Text" : "Show Text"))
        {
            showText = !showText;
            showList = false;
        }
        if (GUILayout.Button("Hide All"))
        {
            showList = false;
            showText = false;
        }
        GUILayout.EndHorizontal();

       
        if (showList)
        {
            EditorGUILayout.Space();
            ShowAudioList(GetCurrentList(config));
        }

        
        if (showText)
        {
            EditorGUILayout.Space();
            config.longText = EditorGUILayout.TextArea(config.longText, GUILayout.Height(100));
        }

        if (GUI.changed) EditorUtility.SetDirty(config);
    }

    private List<AudioItem> GetCurrentList(AudioConfig config)
    {
        switch (config.contentType)
        {
            case AudioContentType.Dangerous: return config.dangerousClips;
            case AudioContentType.Friendly: return config.friendlyClips;
            case AudioContentType.Neutral: return config.neutralClips;
            default: return new List<AudioItem>();
        }
    }

    private void ShowAudioList(List<AudioItem> list)
    {
        EditorGUILayout.LabelField($"{((AudioConfig)target).contentType} Clips", EditorStyles.boldLabel);

        for (int i = 0; i < list.Count; i++)
        {
            EditorGUILayout.BeginVertical("Box");
            list[i].clip = (AudioClip)EditorGUILayout.ObjectField("Clip", list[i].clip, typeof(AudioClip), false);
            list[i].volume = EditorGUILayout.Slider("Volume", list[i].volume, 0, 1);
            EditorGUILayout.EndVertical();
        }
    }
}