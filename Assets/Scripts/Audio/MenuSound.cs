using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    string hoverSound = "HoverSound";
    string clickSound = "ClickSound";
    string MainMenuSound = "MainMenu";

    private void Start()
    {
        if (!AudioManager.mainMenuMusic)
        {
            AudioManager.instance.StopAll();
            AudioManager.instance.Play(MainMenuSound);
        }
    }
    public void OnMouseOver()
    {
        AudioManager.instance.Play(hoverSound);
    }
    public void OnMouseClick()
    {
        AudioManager.instance.Play(clickSound);
    }

}
