using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FirstStartTimeLine : MonoBehaviour
{
    public PlayableDirector timeline;
    public GameObject firstStartTimeLine;

    public Transform[] fires;
    // Start is called before the first frame update
    void Start()
    {
        fires = GetComponentsInChildren<Transform>();
        foreach (Transform fire in fires)
        {
  
        }
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
