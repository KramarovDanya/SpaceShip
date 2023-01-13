using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicVolume : MonoBehaviour
{
    public AudioMixerGroup Mixer;
    private float musicVolume = 1f;
    void Start()
    {
        Mixer.audioMixer.SetFloat("EffectsVolume", 0);
    }
    

    public void SetVolume(float vol)
    {
        Mixer.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, vol));
    }
}
