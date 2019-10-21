using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
    public GameObject dialogueBox;

	public Animator animator;
	private bool first;
    private bool dialogueEnded = true;

	private Queue<string> listOfSentences;
    public Image image;

    // Initialises sentence queue
	void Start () {
		listOfSentences = new Queue<string>();
	}
    // Checks if dialogue has ended
    public bool GetDialogueEnded()
    {
        return dialogueEnded;
    }
    // Starts the dialogue
    public void StartDialogue (Dialogue dialogue)
	{
        // Sets the bool to false so that we know that a dialogue is started
        dialogueEnded = false;
        // Starts the animator to show the text
        animator.SetBool("IsOpen", true);
        // Sets the image of the NPC to active
        image.gameObject.SetActive(true);
        // Shows the name of the NPC
        nameText.text = dialogue.name;
		listOfSentences.Clear();
        // Queues each sentence to be after the previous one
		foreach (string sentence in dialogue.sentences)
		{
			listOfSentences.Enqueue(sentence);
		}
        // Displays the next sentence
		DisplayNextSentence();
	}
    // Shows the next sentences
	public void DisplayNextSentence ()
	{
		if(first){
			first = true;
		}
		//If theres no more sentences left in array, end the dialogue
		if (listOfSentences.Count == 0)
		{
            EndDialogue();
            return;
		}
		//Remove the current sentence from the queue
		string sentence = listOfSentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));

	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	//Load the main dialogbox canvas 
   public IEnumerator LoadDialogueBox()
    {
		//Delay before we set timescale to make sure dialogue box pops up.
        yield return new WaitForSeconds(animator.playbackTime);
        Time.timeScale = 0f;
}
    // Ends the dialogue and sets the time scale back to 1
    public void EndDialogue()
	{
		listOfSentences.Clear();
        Time.timeScale = 1f;
        dialogueEnded = true;
        image.gameObject.SetActive(false);
        animator.SetBool("IsOpen", false);
        return;
	}

}
