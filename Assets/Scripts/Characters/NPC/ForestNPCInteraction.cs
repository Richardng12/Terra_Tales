using UnityEngine;
using UnityEngine.UI;

public class ForestNPCInteraction : MonoBehaviour
{
    public bool interactable = false;
    public DialogueTrigger dialogueTrigger;
    public DialogueManager dialogueManager;
    public bool initialised = false;
    private bool wasUsed = false;

    public Text showText;

    // Start is called before the first frame update
    void Start()
    {
        interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (initialised)
            {
                if(dialogueManager.DisplayNextSentence() ==0){
                    initialised = false;
                    dialogueManager.EndDialogue();
                };
            }
            else if (interactable )
            {
                wasUsed = false;
                dialogueTrigger.TriggerDialogue();
                interactable = false;
                initialised = true;
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log(interactable);
            showText.gameObject.SetActive(true);
            interactable = true;
            showText.text = "Press E";
        }
    }

    private void OnTriggerExit2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log(interactable);
            showText.gameObject.SetActive(false);
            interactable = false;
        }
    }
}
