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
    public GameObject finishScreen;

    public Text scoreText;
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Plays cutscene once player has finished the forest level
   public void PlayCutScene()
    {

        oceanLevelWall.SetActive(true);
        timeline.Play();

    }

	//Pause the game and display the finish screen once the FINISH cutscene is done playing
    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (timeline == aDirector)
        {
          //  firstStartTimeLine.SetActive(false);
         //   player.GetComponent<CharacterController>().enabled = true;
            scoreText.text = Scoring.oceanScore.ToString();
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