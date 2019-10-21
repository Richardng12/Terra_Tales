using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTutorial : MonoBehaviour
{
    public GameObject tutorialMenu;
    // Start is called before the first frame update
    void Start()
    {
        if (GlobalGameManager.instance.firstPlay)
        {
            tutorialMenu.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
