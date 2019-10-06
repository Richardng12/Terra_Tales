using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	public Animator animator;
	private bool first;
    private bool dialogueEnded = true;

	private Queue<string> listOfSentences;
    public Image image;

	void Start () {
		listOfSentences = new Queue<string>();
	}
    public bool GetDialogueEnded()
    {
        return dialogueEnded;
    }
    public void StartDialogue (Dialogue dialogue)
	{
        dialogueEnded = false;
        animator.SetBool("IsOpen", true);
        image.gameObject.SetActive(true);
        nameText.text = dialogue.name;
		listOfSentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			listOfSentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if(first){
			first = true;
		}

		if (listOfSentences.Count == 0)
		{
			EndDialogue();
            return;
		}

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

   public IEnumerator LoadDialogueBox()
    {
        yield return new WaitForSeconds(animator.playbackTime);
        Time.timeScale = 0f;
}

    public void EndDialogue()
	{
        dialogueEnded = true;
		Time.timeScale = 1f;
        image.gameObject.SetActive(false);
        animator.SetBool("IsOpen", false);
	}

}
