using UnityEngine;

[System.Serializable]
public class AudioItem
{
    public AudioClip clip;
    [Range(0, 1)] public float volume = 1f;
}