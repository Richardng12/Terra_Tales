using System;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {

    public string name;
    public AudioClip clip;
    [Range(0f,1f)]
    public float vol;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop = false;

    [HideInInspector]
    public AudioSource source;

    public void Play() {

        source.volume = vol;
        source.pitch = pitch;
        source.Play();

    }
    public void SetSource(AudioSource source) {

        this.source = source;
        this.source.clip = clip;
        this.loop = loop;
    }
    public void Stop()
    {
        source.Stop();
    }

}
