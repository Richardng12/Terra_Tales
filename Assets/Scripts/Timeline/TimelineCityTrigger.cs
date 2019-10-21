using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TimelineCityTrigger : MonoBehaviour
{

    public PlayableDirector timeline;

    public GameObject cityBackgroundFinish;
    public GameObject finishScreen;

    public GameObject cityBackground;

    private GameObject cityNPC;

    private GameObject player;
    public GameObject skipButton;
    
    public GameObject energyBar;
    public GameObject bootsBar;

    public GameObject boot;

    public GameObject bolt;

    public GameObject tileMapFinish;

     private bool isPlaying = false;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (isPlaying)
            {
                StopTimeline();
                skipButton.SetActive(false);
            }
        }
        
    }

   public void PlayCutScene()
    {
        tileMapFinish.SetActive(false);
        boot.SetActive(false);
        bolt.SetActive(false);
        energyBar.SetActive(false);
        bootsBar.SetActive(false);
        skipButton.SetActive(true);
        isPlaying = true;
        player = GameObject.FindWithTag("Player");
        // Sets the player movement to be 0 when the player talks to the npc to 
        // finish the level the animation is also set back to idle by having a 
        // speed of 0
        player.GetComponent<CharacterController>().Move(0, 0);
        player.GetComponent<CharacterAction>().moveAnimator.speed = 0;
        player.GetComponent<CharacterAction>().enabled = false;
        cityNPC = GameObject.FindWithTag("CityNPC");
        cityNPC.GetComponent<CityNPC>().enabled = false;
        cityBackgroundFinish.SetActive(true);
        cityBackground.SetActive(false);
        timeline.Play();
    }

    //Pause the game and display the finish screen once the FINISH cutscene is done playing
    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (timeline == aDirector)
        {
            finishScreen.SetActive(true);
            Time.timeScale = 0f;
            skipButton.SetActive(false);
            AchievementManager.instance.IncrementAchievement(AchievementType.LevelCompletionsCity);
            Publisher.TriggerEvent("FinishCity");
        }
    }

     void StopTimeline(){
        timeline.Stop();
    }

    //Lifecycle methods
    void OnEnable()
    {
        timeline.stopped += OnPlayableDirectorStopped;
    }

    void OnDisable()
    {
        timeline.stopped -= OnPlayableDirectorStopped;
    }

}
