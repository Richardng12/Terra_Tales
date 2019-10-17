using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class FirstStartForestTimeline : MonoBehaviour
{
    public PlayableDirector timeline;
    public GameObject firstStartTimeLine;
    public GameObject player;
    public GameObject[] objects;
    public GameObject blackFade;

    public GameObject skipButton;

    private bool isPlaying = false;

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

    // Start is called before the first frame update
    void Start()
    {
        skipButton.SetActive(true);
        isPlaying = true;
        //Cancel player movement and shooting during cutscene
        player.GetComponent<CharacterAction>().enabled = false;
        player.GetComponent<ShootWater>().enabled = false;
        blackFade = GameObject.FindGameObjectWithTag("BlackFade");

        StartCoroutine(delayedPlayback());
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
            firstStartTimeLine.SetActive(false);
            // Re enable the movement and shooting once cutscene has ended
            player.GetComponent<CharacterAction>().enabled = true;
            player.GetComponent<ShootWater>().enabled = true;
            skipButton.SetActive(false);
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
