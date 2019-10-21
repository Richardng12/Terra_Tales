
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

    // If music is turned on set the volume to normal (1) and for each sound
    // Set the sounds back on if current playing
    public void MusicOn()
    {
        musicTicked = true;
        volume = 1;
        foreach (Sound s in sounds)
        {
            s.setSoundOn();
        }
    }
    // If music is turned off set the volume off (0) and for each sound
    // Set the sounds off if current playing
    public void MusicOff()
    {
        musicTicked = false;
        volume = 0;
        foreach (Sound s in sounds)
        {
            s.setSoundOff();
        }
    }


void Awake()
{
        // Creates the singleton
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
        // Retrieves all the sounds in the components and sets the source of each
        // sound to have a volume and pitch indicated in the gameobject
    foreach (Sound s in sounds)
    {
        GameObject gameSound = new GameObject(s.name);
        gameSound.transform.SetParent(this.transform);
        s.SetSource(gameSound.AddComponent<AudioSource>());
    }
    initalised = true;
        // Plays main menu music
    Play("MainMenu");
    mainMenuMusic = true;
}

    // Plays a specific music using the string inputted
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

    // Stops all music that is currently playing
public void StopAll()
{
    foreach (Sound s in sounds)
    {
        s.Stop();
    }
}
    // Stops a specified music 
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

