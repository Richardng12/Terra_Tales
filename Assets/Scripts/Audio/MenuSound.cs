using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sounds for the hover button and click button

public class MenuSound : MonoBehaviour
{
    string hoverSound = "HoverSound";
    string clickSound = "ClickSound";
    string MainMenuSound = "MainMenu";

    public void OnMouseOver()
    {
        AudioManager.instance.Play(hoverSound);
    }
    public void OnMouseClick()
    {
        AudioManager.instance.Play(clickSound);
    }

}
