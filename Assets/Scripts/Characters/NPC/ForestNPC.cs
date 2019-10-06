using UnityEngine;
using UnityEngine.UI;

public class ForestNPC : MonoBehaviour
{
    private bool interactable = false;
    public Dialogue[] dialogue;
    private DialogueManager dialogueManager;
    private ForestTracker forestTracker;
    public GameObject forestTrackerObject;

    private bool startOfLevel = true;

    private bool initialised = false;
    public Text showText;
    // Start is called before the first frame update
    void Start()
    {
        interactable = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interactable && !initialised)
            {
                TriggerDialogue();
                initialised = true;
            }
            else if (interactable && initialised)
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
        }
    }

    void TriggerDialogue()
    {
        //// Introduces the scene
        //if (startOfLevel)
        //{
        //    StartCoroutine(dialogueManager.LoadDialogueBox());
        //    dialogueManager.StartDialogue(dialogue[0]);
        //    startOfLevel = false;
        //}
        //// If complete then npc thanks
        //else if (forestTracker.CheckIsComplete())
        //{
        //    dialogueManager.StartDialogue(dialogue[2]);

        //}
        //// Talks about current state of tasks
        //else
        //{
        //    CreateTaskDialogue();
        //    dialogueManager.StartDialogue(dialogue[1]);
        //}


    }
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("Player"))
        {
            showText.gameObject.SetActive(true);
            interactable = true;
            showText.text = "Press E";
        }
    }

    private void OnTriggerExit2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("Player"))
        {
            showText.gameObject.SetActive(false);
            interactable = false;
        }
    }

}
