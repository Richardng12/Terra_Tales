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
        if (timeline == aDirector)
        {
            firstStartTimeLine.SetActive(false);
            player.GetComponent<CharacterController>().enabled = true;

        }
    }


    void OnEnable()
    {
        timeline.stopped += OnPlayableDirectorStopped;
    }

    void OnDisable()
    {
        timeline.stopped -= OnPlayableDirectorStopped;
    }
}
