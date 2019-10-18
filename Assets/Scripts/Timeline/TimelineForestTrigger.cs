using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class TimelineForestTrigger : MonoBehaviour
{
    public PlayableDirector timeline;
    public GameObject greenScene;
    // Start is called before the first frame update

    public GameObject forestLevelFinishWall;
    public GameObject finishScreen;

    public GameObject forestLevelWall;

    private GameObject forestNPC;

    private GameObject player;
    public Text scoreText;

    public GameObject skipButton;
    
    public GameObject seedlingHUD;

     private bool isPlaying = false;

   void Update(){
         if (Input.GetKeyDown(KeyCode.S))
        {
            if (isPlaying)
            {
                StopTimeline();
                skipButton.SetActive(false);
                Debug.Log("should stop timeline");
            }
        }
        if(Input.GetKeyDown(KeyCode.J)){
            PlayCutScene();
        }
   }

    void Start()
    {
        //timeline = GetComponent<PlayableDirector>();
    }

    //Plays cutscene once player has finished the forest level
    public void PlayCutScene()
    {
        seedlingHUD.SetActive(false);
        skipButton.SetActive(true);
        isPlaying = true;
        player = GameObject.FindWithTag("Player");
        // Sets the player movement to be 0 when the player talks to the npc to 
        // finish the level the animation is also set back to idle by having a 
        // speed of 0
        player.GetComponent<CharacterController>().Move(0, 0);
        player.GetComponent<CharacterAction>().moveAnimator.speed = 0;
        player.GetComponent<CharacterAction>().enabled = false;
        forestNPC = GameObject.FindWithTag("ForestNPC");
        forestNPC.GetComponent<ForestNPC>().enabled = false;
        greenScene.SetActive(true);
        forestLevelFinishWall.SetActive(true);
        forestLevelWall.SetActive(false);
        timeline.Play();

    }

    //Pause the game and display the finish screen once the FINISH cutscene is done playing
    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (timeline == aDirector)
        {
            //  firstStartTimeLine.SetActive(false);
            //   player.GetComponent<CharacterController>().enabled = true;
            Debug.Log("finish screen should display");
            scoreText.text = Scoring.forestScore.ToString();
            finishScreen.SetActive(true);
            Time.timeScale = 0f;
            skipButton.SetActive(false);
            AchievementManager.instance.IncrementAchievement(AchievementType.LevelCompletionsForest);
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
