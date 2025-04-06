using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewAudioConfig", menuName = "Audio Config")]
public class AudioConfig : ScriptableObject
{
    public string configId;
    public AudioContentType contentType;
    [TextArea(5, 20)] public string longText;

    public List<AudioItem> dangerousClips = new List<AudioItem>();
    public List<AudioItem> friendlyClips = new List<AudioItem>();
    public List<AudioItem> neutralClips = new List<AudioItem>();
}