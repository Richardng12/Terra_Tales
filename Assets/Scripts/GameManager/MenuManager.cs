﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    AudioManager audioManager;
    string MainMenuSound = "MainMenu";

    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;
        if(audioManager == null)
        {
            Debug.Log("NO AUDIO MANAGER FOUND");
        }
        else
        {
            if (AudioManager.initalised)
            {
                // If main menu music isnt playing then it should stop all current
                // music and play main menu music
                if (!AudioManager.mainMenuMusic)
                {
                    audioManager.StopAll();
                    audioManager.Play(MainMenuSound);
                    AudioManager.mainMenuMusic = true;
                }
            }
        }
    }
}
