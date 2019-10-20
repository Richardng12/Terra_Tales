using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pause : MonoBehaviour 
{
    public GameObject pauseMenu;
    public Button resumeButton;
    private bool paused;
    readonly string mainMenuSound = "MainMenu";

    //Upon start, get the Resume button component and reference ContinueGame() method with it
    void Start () {
		Button btn = GetComponent<Button>();
		resumeButton.onClick.AddListener(ContinueGame);
	}

    void Update()
    {
        //PauseGame();
        //   Debug.Log("ewe");
		//If the player presses escape, look at current game state, if its not paused - pause, if it is paused, unpause.
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (!paused) 
            {
                PauseGame();
            }
           else 
            {
                 ContinueGame();   
            }
        } 
     }
	 //Method to call that pauses the game and freezes the time.
    private void PauseGame()
    {
        paused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    } 
	//Method that represents the continue game state
    public void ContinueGame()
    {
        paused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        //enable the scripts again
    }

    public void ExitButtonPressed()
    {
        AudioManager.instance.StopAll();
        AudioManager.instance.Play(mainMenuSound);
    }
}