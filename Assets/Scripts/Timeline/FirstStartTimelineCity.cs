using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class FirstStartTimelineCity : MonoBehaviour
{

    public PlayableDirector timeline;
    public GameObject player;
    public GameObject blackFade;

    public GameObject skipButton;

    public GameObject energyBar;
    public GameObject bootsBar;

    public GameObject boot;

    public GameObject bolt;

    private bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        boot.SetActive(false);
        bolt.SetActive(false);
        energyBar.SetActive(false);
        bootsBar.SetActive(false);
        skipButton.SetActive(true);
        isPlaying = true;
        //Cancel player movement and shooting during cutscene
        player.GetComponent<CharacterAction>().enabled = false;
        player.GetComponent<ShootWater>().enabled = false;
        blackFade = GameObject.FindGameObjectWithTag("BlackFade");

        StartCoroutine(delayedPlayback());
    }

    // Update is called once per frame
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
      void StopTimeline(){
        timeline.Stop();
    }
void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
		//When initial forest cutscene is finished, set the component to non-active and enable the player movement
        if (timeline == aDirector)
        {
            blackFade.SetActive(false);
            // Re enable the movement and shooting once cutscene has ended
            player.GetComponent<CharacterAction>().enabled = true;
            player.GetComponent<ShootWater>().enabled = true;
            skipButton.SetActive(false);
               boot.SetActive(true);
                bolt.SetActive(true);
                energyBar.SetActive(true);
                bootsBar.SetActive(true);
        }
    }

    IEnumerator delayedPlayback(){
         yield return new WaitForSeconds(4f);
         blackFade.GetComponent<DialogueFade>().FadeToDialogue();
    }

	//Lifecycle methods that get called once cutscene is finished
    void OnEnable()
    {
        timeline.stopped += OnPlayableDirectorStopped;
    }

    void OnDisable()
    {
        timeline.stopped -= OnPlayableDirectorStopped;
    }
}

