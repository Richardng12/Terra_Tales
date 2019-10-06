using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	public Animator animator;
	private bool first;

	private Queue<string> listOfSentences;

	void Start () {
		listOfSentences = new Queue<string>();
	}

	public void StartDialogue (Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		listOfSentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			listOfSentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public int DisplayNextSentence ()
	{
		if(first){
			first = true;
		}

		if (listOfSentences.Count == 0)
		{
			EndDialogue();
			return listOfSentences.Count;
		}

		string sentence = listOfSentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
		return listOfSentences.Count;

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

	public void EndDialogue()
	{
		Time.timeScale = 1f;
		animator.SetBool("IsOpen", false);
	}

}
