using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FirstStartOceanTimeline : MonoBehaviour
{
    public PlayableDirector timeline;
    public GameObject player;

    public GameObject blackFade;

     public GameObject skipButton;

     public GameObject itemHUD;

    public GameObject liveScoreText;

    private bool isPlaying = false;



    // Start is called before the first frame update
    void Start()
    {
        itemHUD.SetActive(false);
         skipButton.SetActive(true);
        isPlaying = true;
        //Cancel player movement during cutscene
        player.GetComponent<CharacterAction>().enabled = false;
        player.GetComponent<ShootWater>().enabled = false;
        blackFade = GameObject.FindGameObjectWithTag("BlackFade");
        StartCoroutine(delayedPlayback());
    }

    // Update is called once per frame
    void Update(){
         if (Input.GetKeyDown(KeyCode.S))
        {
            if (isPlaying)
            {
                StopTimeline();
                skipButton.SetActive(false);
            }
        }
   }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
		//When initial ocean cutscene is finished, set the component to non-active and enable the player movement
        if (timeline == aDirector)
        {
            itemHUD.SetActive(true);
             skipButton.SetActive(false);
            isPlaying = false;
            Debug.Log("blackfade should be disabled");
            blackFade.SetActive(false);
            player.GetComponent<CharacterAction>().enabled = true;
            player.GetComponent<ShootWater>().enabled = true;
            liveScoreText.SetActive(true);
        }

    }

    IEnumerator delayedPlayback(){
         yield return new WaitForSeconds(4f);
         blackFade.GetComponent<DialogueFade>().FadeToDialogue();
    }

     void StopTimeline(){
        timeline.Stop();
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
