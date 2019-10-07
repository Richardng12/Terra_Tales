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
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag.Equals("Player"))
        {
            greenScene.SetActive(true);
            timeline.Play();
            Debug.Log("hi");
        }
    }
}