using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    AudioManager audioManager;
    string hoverSound = "HoverSound";
    string clickSound = "ClickSound";
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
                audioManager.StopAll();
                audioManager.Play(MainMenuSound);
            }
        }
    }

    public void OnMouseOver()
    {
        audioManager.Play(hoverSound);
    }
    public void OnMouseClick()
    {
        audioManager.Play(clickSound);
    }
}
