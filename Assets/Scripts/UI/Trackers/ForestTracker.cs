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

    private bool isComplete;


    // Start is called before the first frame update
    void Start()
    {
        treesPlanted[0] = 0;
        startingColour = text.color;
    }

    public void UpdateAndDisplayTaskCounter(int i = 0)
    {
        text.color = startingColour;
        treesPlanted[i]++;
        text.text = "Planted " + treesPlanted[i] + "/" + treesToPlant + " Trees";
        StartCoroutine(TextFadeOutRoutine());
        if (treesPlanted[i] == treesToPlant)
        {
            Scoring scoring = gameManager.GetComponent<Scoring>();
            scoring.CalculateStageScore("Forest");
        }
    }

    public IEnumerator TextFadeOutRoutine()
    {
        Color color = text.color;

        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        {
            text.color = Color.Lerp(color, Color.clear, Mathf.Min(1, t / fadeOutTime));

            yield return null;
        }
    }

    public bool CheckIsComplete()
    {
        return isComplete;
    }

    public int[] GetTasks()
    {
        return treesPlanted;
    }
}
