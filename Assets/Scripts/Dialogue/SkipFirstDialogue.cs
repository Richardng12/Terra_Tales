using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipFirstDialogue : MonoBehaviour
{
    public GameObject firstTimePlay;
    public GameObject levelSelectionMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GlobalGameManager.instance.firstPlay && firstTimePlay.activeInHierarchy){
            firstTimePlay.SetActive(false);
            levelSelectionMenu.SetActive(true);
        }
    }
}
