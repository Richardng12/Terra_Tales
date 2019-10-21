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
        if (GlobalGameManager.instance.firstPlay)
        {
            tutorialMenu.SetActive(true);
            levelSelectionPanel.SetActive(false);
            GlobalGameManager.instance.firstPlay = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
