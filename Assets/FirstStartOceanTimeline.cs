using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FirstStartOceanTimeline : MonoBehaviour
{
    public PlayableDirector timeline1;
    public GameObject player;

    public GameObject blackFade;

   // public float blackFadeTime;

    // Start is called before the first frame update
    void Start()
    {
        //Cancel player movement during cutscene
        player = GameObject.FindWithTag("Player");
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<CharacterAction>().enabled = false;
        blackFade = GameObject.FindGameObjectWithTag("BlackFade");
        StartCoroutine(delayedPlayback());
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
		//When initial ocean cutscene is finished, set the component to non-active and enable the player movement
        if (timeline1 == aDirector)
        {
            Debug.Log("blackfade should be disabled");
            blackFade.SetActive(false);
            player.GetComponent<CharacterController>().enabled = true;
            player.GetComponent<CharacterAction>().enabled = true;
        }

    }

    IEnumerator delayedPlayback(){
         yield return new WaitForSeconds(4f);
         blackFade.GetComponent<DialogueFade>().FadeToDialogue();
    }

	//Lifecycle methods that get called once cutscene is finished
    void OnEnable()
    {
        timeline1.stopped += OnPlayableDirectorStopped;
    }

    void OnDisable()
    {
        timeline1.stopped -= OnPlayableDirectorStopped;
    }
}
