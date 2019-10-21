﻿
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    public static bool initalised = false;
    public static bool mainMenuMusic = true;
    public static bool musicTicked = true;
    int volume = 1;


    public void MusicOn()
    {
        musicTicked = true;
        volume = 1;
        foreach (Sound s in sounds)
        {
            s.setSoundOn();
        }
    }
    public void MusicOff()
    {
        musicTicked = false;
        volume = 0;
        foreach (Sound s in sounds)
        {
            s.setSoundOff();
        }
    }

    private void Update()
    {
  
    }


void Awake()
{
    if (instance == null)
    {
        instance = this;
        // Dont destroy this object when a new scene is loaded
        DontDestroyOnLoad(this);
    }
    else
    {
        if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }
}

private void Start()
{
    foreach (Sound s in sounds)
    {
        GameObject gameSound = new GameObject(s.name);
        gameSound.transform.SetParent(this.transform);
        s.SetSource(gameSound.AddComponent<AudioSource>());
    }
    initalised = true;
    Play("MainMenu");
    mainMenuMusic = true;
}

public void Play(string name)
{
    foreach (Sound s in sounds)
    {
        if (s.name.Equals(name))
        {
            s.Play(volume);
            return;
        }
    }
}

public void StopAll()
{
    foreach (Sound s in sounds)
    {
        s.Stop();
    }
}

public void Stop(string name)
{
    foreach (Sound s in sounds)
    {
        if (s.name.Equals(name))
        {
            s.Stop();
            return;
        }
    }
}

}

