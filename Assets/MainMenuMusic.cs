using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{

    string MainMenuSound = "MainMenu";
    // Start is called before the first frame update
    void Start()
    {
        if (!AudioManager.mainMenuMusic)
        {
            AudioManager.instance.StopAll();
            AudioManager.instance.Play(MainMenuSound);
            AudioManager.mainMenuMusic = true;
        }
    }
}
