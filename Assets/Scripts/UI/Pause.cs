using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pause : MonoBehaviour 
{
    public GameObject pauseMenu;
    public Button resumeButton;
    private bool paused;
     void Start () {
		Button btn = GetComponent<Button>();
		resumeButton.onClick.AddListener(ContinueGame);
	}

    void Update()
    {
        Time.timeScale = 0;
        //PauseGame();
        //   Debug.Log("ewe");
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
        Debug.Log("escape pressed");
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
    private void PauseGame()
    {
        paused = true;
        Time.timeScale = 0;
        Debug.Log(Time.timeScale);
        pauseMenu.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    } 
    private void ContinueGame()
    {
        paused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        //enable the scripts again
    }
}