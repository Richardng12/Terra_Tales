using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioToggle : MonoBehaviour
{

    public AudioManager audioManager;
    public Image volumeOn;
    public Image volumeOff;
    public Image button;
    private bool isStart = true;


    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;
        // When pause menu is shown it checks the current status of the sound
        // toggle to check what picture it should show
         if(AudioManager.musicTicked){
            volumeOn.enabled = true;
            volumeOff.enabled = false;

        }
        else
        {
            volumeOn.enabled = false;
            volumeOff.enabled = true;
        }
         isStart = false;
    }

    // If toggle is clicked change the picture and set the volume correspondingly
    public void ToggleValueChanged()
    {

        if (!isStart)
        {
            // Turns off music
            if (AudioManager.musicTicked)
            {
                AudioManager.instance.MusicOff();
                volumeOn.enabled = false;
                volumeOff.enabled = true;
            }
            // Turns music back on
            else
            {
                AudioManager.instance.MusicOn();
                volumeOn.enabled = true;
                volumeOff.enabled = false;
            }
        }
    }
}
