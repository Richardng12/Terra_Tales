using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityNPC : MonoBehaviour, INPC
{

     private bool interactable = false;
    public Dialogue[] dialogue;
    private DialogueManager dialogueManager;

      public GameObject gameManager;

    public GameObject dialogueBox;

 public GameObject cityTrackerObject;
    public GameObject timerObject;
       public GameObject energyBar;
       public GameObject bootsBar;

       public GameObject timelineTrigger;

    private CityTracker cityTracker;
       public GameObject boot;

       public GameObject bolt;
 private bool startOfLevel = true;

    private bool initialised = false;
    public Text showText;

    public GameObject liveScoreText;

    // Start is called before the first frame update
    void Start()
    {
            cityTracker = cityTrackerObject.GetComponent<CityTracker>();
         dialogueManager = FindObjectOfType<DialogueManager>();
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

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (interactable)
            {
                EndDialogueCity();
            }
        }

        // If player presses E it should continue the dialogue
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckDialogueLogic();
        }
    }
    public void CheckDialogueLogic()
    {
        dialogueBox.SetActive(true);
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
                  boot.SetActive(true);
                  bolt.SetActive(true);
        energyBar.SetActive(true);
        bootsBar.SetActive(true);
                Time.timeScale = 1.0f;
                // Dialogue has ended

                initialised = false;
                // Start of level should only gets set to false once as that
                // dialogue only happens at the start
                startOfLevel = false;
            }
        }
        }


         public void TriggerDialogue()
    {
        boot.SetActive(false);
        bolt.SetActive(false);
        energyBar.SetActive(false);
        bootsBar.SetActive(false);
        // Introduces the scene
        if (startOfLevel)
        {
            StartCoroutine(dialogueManager.LoadDialogueBox());
            dialogueManager.StartDialogue(dialogue[0]);
            timerObject.GetComponent<Timer>().StartTimer();
          //  seedlingHUD.SetActive(true);
            liveScoreText.SetActive(true);
        }
        //If complete then npc thanks
        else if (cityTracker.isCompleted)
        {
            Debug.Log("citytracker is completed");
          //  gameManager.GetComponent<Scoring>().CalculateStageScore("Forest");
            dialogueManager.StartDialogue(dialogue[2]);
            timelineTrigger.GetComponent<TimelineCityTrigger>().PlayCutScene();
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
        dialogue[1].sentences[0] = "Help me turn off the lights!!";

    }

     public void EndDialogueCity(){

        dialogueBox.SetActive(false);
        Debug.Log("WElp");
         dialogueManager.EndDialogue();
                StopAllCoroutines();
                 dialogueManager.DisplayNextSentence();
                    // Dialogue has ended

                    initialised = false;
                    // Start of level should only gets set to false once as that
                    // dialogue only happens at the start
                    startOfLevel = false;
                      energyBar.SetActive(false);
            bootsBar.SetActive(false);
             boot.SetActive(false);
            bolt.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        // If collision is detected then set interactable to true meaning the
        // player can press E to talk to the NpC
        if (Collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("text should show");
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
               boot.SetActive(true);
                bolt.SetActive(true);
                energyBar.SetActive(true);
                bootsBar.SetActive(true);
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
