using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OceanNPC : MonoBehaviour, INPC
{



    private bool interactable = false;
    public Dialogue[] dialogue;
    private DialogueManager dialogueManager;
    private OceanTracker oceanTracker;
    public GameObject oceanTrackerObject;

    private bool startOfLevel = true;

    private bool initialised = false;
    public Text showText;     // Start is called before the first frame update     void Start()     {
        dialogueManager = FindObjectOfType<DialogueManager>();
        oceanTracker = oceanTrackerObject.GetComponent<OceanTracker>();         interactable = false;     }      // Update is called once per frame     void Update()     {
        if (startOfLevel && interactable)
        {
            TriggerDialogue();
            initialised = true;
        }
         if (Input.GetKeyDown(KeyCode.E))
        {
            if (interactable && !initialised)
            {
                TriggerDialogue();
                initialised = true;
            }
            else if(interactable && initialised)
            {
                dialogueManager.DisplayNextSentence();
                if (dialogueManager.GetDialogueEnded())
                {
                    Time.timeScale = 1.0f;
                    initialised = false;
                }
            }
        }

        if (!interactable)
        {
            interactable = false;
            initialised = false;
            dialogueManager.EndDialogue();
        }     }

    public void TriggerDialogue()
    {
        // Introduces the scene
        if (startOfLevel)
        {
            StartCoroutine(dialogueManager.LoadDialogueBox());
            dialogueManager.StartDialogue(dialogue[0]);
            startOfLevel = false;
        }
        // If complete then npc thanks
        else if (oceanTracker.CheckIsComplete())
        {
            dialogueManager.StartDialogue(dialogue[2]);

        }
        // Talks about current state of tasks
        else
        {
            CreateTaskDialogue();
            dialogueManager.StartDialogue(dialogue[1]);
        }


    }

    public void CreateTaskDialogue()
    {
        // Size will always be 2 with first one saying not finished
        dialogue[1].sentences[0] = "You have collected " +
        oceanTracker.GetTasks()[0] + "/5 Rubbish Bags";

        dialogue[1].sentences[1] = "You have Recycled " +
   oceanTracker.GetTasks()[1] + "/5 Cans"; 
            
            dialogue[1].sentences[2] = "You have Composted " +
    oceanTracker.GetTasks()[2] + "/5 Apple cores";

    }      private void OnTriggerEnter2D(Collider2D Collision)     {         if (Collision.gameObject.tag.Equals("Player")) {             showText.gameObject.SetActive(true);             interactable = true;             showText.text = "Press E";         }     }      private void OnTriggerExit2D(Collider2D Collision)     {         if (Collision.gameObject.tag.Equals("Player"))         {             showText.gameObject.SetActive(false);             interactable = false;         }     } 
}
