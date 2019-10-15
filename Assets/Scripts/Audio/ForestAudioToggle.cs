using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioToggle : MonoBehaviour
{

    public AudioManager audioManager;

    private bool isStart = true;



    public Toggle musicToggle;
    // Start is called before the first frame update
    void Start()
    {
        musicToggle = GetComponent<Toggle>();
        musicToggle.onValueChanged.AddListener(delegate
        {
            ToggleValueChanged(musicToggle);
        });
        audioManager = AudioManager.instance;

         if(AudioManager.musicTicked){
            gameObject.GetComponent<Toggle>().isOn = true;
         }else{
             gameObject.GetComponent<Toggle>().isOn = false;
         }
         isStart = false;
    }

    public void ToggleValueChanged(Toggle change)
    {
        if (!isStart)
        {
            if (AudioManager.musicTicked)
            {
                AudioManager.musicTicked = false;
                Debug.Log("musicTicked false");
            }
            else
            {
                AudioManager.musicTicked = true;
                Debug.Log("musicTicked true");
            }
        }
    }
}
