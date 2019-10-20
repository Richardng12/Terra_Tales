using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class TimelineOceanTrigger : MonoBehaviour
{
    public PlayableDirector timeline;

    public GameObject oceanLevelWall;
    // Start is called before the first frame update

    public GameObject oceanLevelStart;
    public GameObject finishScreen;

    private GameObject player;

    private GameObject oceanNPC;

    public GameObject bins;

    public GameObject spawners;

public TrashScript[] trash;
public OilSpriteController[] oilPuddles;

    public Text scoreText;

    public GameObject skipButton;

    private bool isPlaying = false;

    public GameObject itemHUD;


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
   }

    //Plays cutscene once player has finished the ocean level
   public void PlayCutScene()
    {
        isPlaying = true;
        itemHUD.SetActive(false);
        skipButton.SetActive(true);
        //Disable player movement
        player = GameObject.FindWithTag("Player");
        // Sets the player movement to be 0 when the player talks to the npc to 
        // finish the level the animation is also set back to idle by having a 
        // speed of 0
        player.GetComponent<CharacterController>().Move(0, 0);
        player.GetComponent<CharacterAction>().moveAnimator.speed = 0;
        player.GetComponent<CharacterAction>().enabled = false;

        //Set new background
        oceanNPC = GameObject.FindWithTag("OceanNPC");
        oceanNPC.GetComponent<OceanNPC>().enabled = false;
        oceanLevelWall.SetActive(true);
        oceanLevelStart.SetActive(false);

        //Destroy all trash
        bins.SetActive(false);
        spawners.SetActive(false);

        trash = FindObjectsOfType(typeof(TrashScript)) as TrashScript[];
        oilPuddles = FindObjectsOfType(typeof(OilSpriteController)) as OilSpriteController[];

          foreach (TrashScript t in trash)
        {
            Destroy(t.gameObject);
            Debug.Log("destroy trash");
        }
          foreach (OilSpriteController o in oilPuddles)
        {
            Destroy(o.gameObject);
        }

        
        timeline.Play();

    }

	//Pause the game and display the finish screen once the FINISH cutscene is done playing
    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (timeline == aDirector)
        {
            Debug.Log("finish screen should show");
          //  firstStartTimeLine.SetActive(false);
         //   player.GetComponent<CharacterController>().enabled = true;
            scoreText.text = "Score: " + Scoring.oceanScore.ToString();
            finishScreen.SetActive(true);
            AchievementManager.instance.IncrementAchievement(AchievementType.LevelCompletionsOcean);
            Time.timeScale = 0f;
            skipButton.SetActive(false);
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