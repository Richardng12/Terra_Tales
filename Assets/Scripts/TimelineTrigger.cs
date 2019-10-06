using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    public PlayableDirector timeline;
    // Start is called before the first frame update
    void Start()
    {
        //timeline = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag.Equals("Player"))
        {
            timeline.Play();
            Debug.Log("hi");
        }
    }
}