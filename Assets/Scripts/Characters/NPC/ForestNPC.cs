using UnityEngine;
using UnityEngine.UI;

public class ForestNPC : MonoBehaviour, INPC
{
    private bool interactable = false;
    public Dialogue[] dialogue;
    private DialogueManager dialogueManager;
    private ForestTracker treeTracker;
    public GameObject treeTrackerObject;
    public GameObject timelineTrigger;

    public GameObject timerObject;

    public GameObject seedlingHUD;
    public GameObject gameManager;

    private int treesToPlant;

    private bool startOfLevel = true;

    private bool initialised = false;
    public Text showText;


    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        treeTracker = treeTrackerObject.GetComponent<ForestTracker>();
        treesToPlant = treeTracker.treesToPlant;
        interactable = false;
    }

    // Update is called once per frame
    void Update()
    {   // When player walks into the starting npc it should trigger dialogue
        // that freezes the game unti dialogue is finished
        if (startOfLevel && interactable)
        {
            // Initialised means the dialogue has started so if it has started 
            // Keep time scale to 0
            if (initialised)
            {
                Time.timeScale = 0;
            }
            else
            {
                // If dialogue hasnt started and its first time interaction then
                // start the dialogue and set initialised to true
                TriggerDialogue();
                initialised = true;
            }
        }
        // If player presses E it should continue the dialogue
        if (Input.GetKeyDown(KeyCode.E))
        {
            // If in range of NPC and dialogue has not yet started then start
            // the diagloue 
            if (interactable && !initialised)
            {
                TriggerDialogue();
                // Set dialogue to started
                initialised = true;
            }
            // If still in range and dialogue has started then show the next 
            // sentences in the dialogue
            else if (interactable && initialised)
            {
                dialogueManager.DisplayNextSentence();
                // Once dialogue has ended then set time scale to 1
                if (dialogueManager.GetDialogueEnded())
                {
                    Time.timeScale = 1.0f;
                    // Dialogue has ended

                    initialised = false;
                    // Start of level should only gets set to false once as that
                    // dialogue only happens at the start
                    startOfLevel = false;
                }
            }
        }
    }

    public void TriggerDialogue()
    {
        // Introduces the scene
        if (startOfLevel)
        {
            StartCoroutine(dialogueManager.LoadDialogueBox());
            dialogueManager.StartDialogue(dialogue[0]);
            timerObject.GetComponent<Timer>().StartTimer();
            seedlingHUD.SetActive(true);
        }
        // If complete then npc thanks
        else if (treeTracker.CheckIsComplete())
        {
            gameManager.GetComponent<Scoring>().CalculateStageScore("Forest");
            dialogueManager.StartDialogue(dialogue[2]);
            timelineTrigger.GetComponent<TimelineTrigger>().PlayCutScene();
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
        // First sentence talks about rubbish bag task
        dialogue[1].sentences[0] = "You have planted " +
        treeTracker.GetTasks()[0] + "/" + treesToPlant + " Trees";

    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        // If collision is detected then set interactable to true meaning the
        // player can press E to talk to the NpC
        if (Collision.gameObject.tag.Equals("Player"))
        {
            showText.gameObject.SetActive(true);
            interactable = true;
            showText.text = "Press E";
        }
    }

    // If out of range of NPC then the dialogue should automatically end
    private void OnTriggerExit2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("Player"))
        {
            showText.gameObject.SetActive(false);
            interactable = false;
            if (!interactable)
            {
                initialised = false;
                dialogueManager.EndDialogue();
            }
        }
    }

}
