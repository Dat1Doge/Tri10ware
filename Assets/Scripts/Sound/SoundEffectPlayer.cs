using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    private AudioSource audSource;

    void Awake() {
        audSource = GetComponent<AudioSource>();
    }

    public void PlaySound(SoundEffect sfx) {
        audSource.time = sfx.start;
        audSource.PlayOneShot(sfx.soundClip,sfx.volume);
    }
}
