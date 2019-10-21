using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTutorial : MonoBehaviour
{
    public GameObject tutorialMenu;
    public GameObject levelSelectionPanel;

    // Start is called before the first frame update
    void Start()
    {
        // If its the first time the player is playing ask user to play tutorial
        if (!GlobalGameManager.instance.firstPlay)
        {
            tutorialMenu.SetActive(true);
            levelSelectionPanel.SetActive(false);
            GlobalGameManager.instance.firstPlay = true;
        }
    }
}
