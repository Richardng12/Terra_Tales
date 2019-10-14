using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForestTracker : MonoBehaviour, ITracker<int>
{
    public int treesToPlant;
    private int[] treesPlanted = new int[1];

    public Text text;

    public float fadeOutTime;

    public GameObject gameManager;

    private Color startingColour;


    private bool isComplete = false;


    // Start is called before the first frame update
    void Start()
    {
        treesPlanted[0] = 0;
        startingColour = text.color;
    }
       
    // increments the number of trees planted and displays the text on screen
    public void UpdateAndDisplayTaskCounter(int i = 0)
    {
        text.color = startingColour;
        treesPlanted[i]++;
        text.text = "Planted " + treesPlanted[i] + "/" + treesToPlant + " Trees";

        // activates the coroutine to display text then fade it
        StartCoroutine(TextFadeOutRoutine());

        // once the player completes task the score for the level is calculated
        if (CheckIsComplete())
        {
            Scoring scoring = gameManager.GetComponent<Scoring>();
            //scoring.CalculateStageScore("Forest");
            scoring.StopStageTimer();
            Debug.Log("Called");
        }
    }

    // Routine that fades the alpha of a text UI component
    public IEnumerator TextFadeOutRoutine()
    {
        Color color = text.color;

        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        {
            text.color = Color.Lerp(color, Color.clear, Mathf.Min(1, t / fadeOutTime));

            yield return null;
        }
    }

    // checks whether the objective counter is met
    public bool CheckIsComplete()
    {
        for(int i=0; i < treesPlanted.Length; i++)
        {
            if (treesPlanted[i] < treesToPlant) {
                return false;
             }
        }
        isComplete = true;
        return true;
    }

    // returns the number of trees planted array
    public int[] GetTasks()
    {
        return treesPlanted;
    }
}
