using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTrigger : MonoBehaviour
{

    public DialogueTrigger dialogueTrigger;
    public DialogueManager dialogueManager;
    public bool done = false;
    public  bool autoActivate;

    public bool runOnce;
    public Text showText;

    public bool initialised = false;
    // Start is called before the first frame update
    void Start()
    {
        showText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && initialised)
        {
            if (dialogueManager.DisplayNextSentence() == 0)
            {
                initialised = runOnce;
                dialogueManager.EndDialogue();
            };
        }
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0f;
        print(Time.time);
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("Player"))
        {
            if (!done && autoActivate)
            {
                dialogueTrigger.TriggerDialogue();
                StartCoroutine(Example());
                initialised = true;
                showText.gameObject.SetActive(true);

            }
        }
    }


    private void OnTriggerExit2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("Player"))
        {
            showText.gameObject.SetActive(false);
            done = true;
        }
    }
}
