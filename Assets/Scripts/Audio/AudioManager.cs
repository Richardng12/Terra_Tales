
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    public static bool initalised = false;

    private void Update()
    {

    }

    void Awake() {
        if(instance == null)
        {
            instance = this;
            // Dont destroy this object when a new scene is loaded
            DontDestroyOnLoad(this);
        }
        else
        {
            if(instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void Start()
    {
        foreach(Sound s in sounds)
        {
            GameObject gameSound = new GameObject(s.name);
            gameSound.transform.SetParent(this.transform);
            s.SetSource(gameSound.AddComponent<AudioSource>());
        }
        initalised = true;
        Play("MainMenu");
    }

    public void Play(string name)
    {            
        foreach(Sound s in sounds){
            if (s.name.Equals(name))
            {
                s.Play();
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
