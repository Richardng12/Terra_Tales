using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    public PlayableDirector timeline;
    public GameObject greenScene;
    // Start is called before the first frame update
    void Start()
    {
        //timeline = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //TODO upon player completion
   public void PlayCutScene()
    {
        greenScene.SetActive(true);
        timeline.Play();

    }
}