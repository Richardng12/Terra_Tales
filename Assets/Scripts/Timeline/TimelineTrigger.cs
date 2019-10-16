using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
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
    void Start()
    {
        //timeline = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Plays cutscene once player has finished the forest level
   public void PlayCutScene()
    {
        player = GameObject.FindWithTag("Player");
        player.GetComponent<CharacterController>().enabled = false;
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
        }
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