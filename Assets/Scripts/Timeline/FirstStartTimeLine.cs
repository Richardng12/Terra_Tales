using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FirstStartTimeLine : MonoBehaviour
{
    public PlayableDirector timeline;
    public GameObject firstStartTimeLine;
    public GameObject player;
    public GameObject[] objects;
    // Start is called before the first frame update
    void Start()
    {
        //Cancel player movement during cutscene
        player = GameObject.FindWithTag("Player");
        player.GetComponent<CharacterController>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
		//When initial forest cutscene is finished, set the component to non-active and enable the player movement
        if (timeline == aDirector)
        {
            firstStartTimeLine.SetActive(false);
            player.GetComponent<CharacterController>().enabled = true;

        }
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
