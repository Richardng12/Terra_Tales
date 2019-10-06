using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{

    public DialogueTrigger dialogueTrigger;
    public DialogueManager dialogueManager;
    public bool done = false;
    public bool initialised = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (initialised)
            {
                dialogueManager.DisplayNextSentence();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("Player"))
        {
            if (!done)
            {
                dialogueTrigger.TriggerDialogue();
                initialised = true;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("Player"))
        {
            done = true;
        }
    }
}
