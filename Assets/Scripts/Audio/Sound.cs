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

    public bool loop;

    [HideInInspector]
    public AudioSource source;



    public void Play() {

        source.volume = vol;
        source.pitch = pitch;
        source.loop = loop;
        source.Play();

    }
    public void SetSource(AudioSource source) {

        this.source = source;
        this.source.clip = clip;
        this.source.loop = loop;
    }
    public void Stop()
    {
        source.Stop();
    }

    public void setSoundOff(){
        source.volume = 0;
    }

    public void setSoundOn(){
        source.volume = vol;
    }

}
