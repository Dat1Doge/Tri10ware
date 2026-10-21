using UnityEngine;

[CreateAssetMenu(fileName = "SoundEffect", menuName = "Scriptable Objects/SoundEffect")]
public class SoundEffect : ScriptableObject
{
    public AudioClip soundClip;
    public float volume;
    public float start;
}
