using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    public AudioSource MusicaDeFundo;
    public AudioSource AudioSFX;
    // Start is called before the first frame update
    void Start() {

    }
    public void VolumeMusical(float value) {
        MusicaDeFundo.volume = value;
    }

    public void PlaySFX(AudioClip clip) {
        AudioSFX.clip = clip;
        AudioSFX.Play();
    }
    
}
