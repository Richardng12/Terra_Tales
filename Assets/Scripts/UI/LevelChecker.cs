using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelChecker : MonoBehaviour
{
    public Button oceanButton;
    public Image oceanLockImage;

    public Button forestButton;
    public Image forestLockImage;

    private void OnEnable()
    {
        // checks if stages are unlocked and enables or disables the buttons and displays locked images
        if(GlobalGameManager.instance.forestUnlocked == false)
        {
            DisableButton(forestButton);
            forestLockImage.enabled = true;
        }
        else
        {
            EnableButton(forestButton);
            forestLockImage.enabled = false;
        }
        if(GlobalGameManager.instance.oceanUnlocked == false)
        {
            DisableButton(oceanButton);
            oceanLockImage.enabled = true;
        }
        else
        {
            EnableButton(oceanButton);
            oceanLockImage.enabled = false;
        }
    }


    // function that disables all on hover scripts in hover
    private void DisableButton(Button button)
    {
        button.interactable = false;
        foreach (var variable in button.GetComponents<ChangeColorOnHover>())
        {
            variable.enabled = false;
        }
    }

    private void EnableButton(Button button)
    {
        button.interactable = true;
        foreach (var variable in button.GetComponents<ChangeColorOnHover>())
        {
            variable.enabled = true;
        }
    }
}
