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

    //Plays cutscene once player has finished the ocean level
   public void PlayCutScene()
    {
        //Disable player movement
        player = GameObject.FindWithTag("Player");
        player.GetComponent<CharacterController>().enabled = false;
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