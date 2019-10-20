using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelChecker : MonoBehaviour
{
    public Button oceanButton;

    public Button forestButton;
    private void OnEnable()
    {
        if(GlobalGameManager.instance.forestUnlocked == false)
        {
            forestButton.interactable = false;
        }
        if(GlobalGameManager.instance.oceanUnlocked == false)
        {
            oceanButton.interactable = false;
        }
    }
}
