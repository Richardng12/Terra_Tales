using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OceanTracker : MonoBehaviour, ITracker<string>
{
    public int rubbishToCollect;
    private int[] tasks = new int[3];

    public Text text;
    private Color startingColour;
    private bool isComplete;

    public float fadeOutTime;

    public GameObject gameManager;


    AudioManager audioManager;

    string oceanLevelAudio = "OceanLevel";


    // Start is called before the first frame update

    void Start()
    {
        audioManager = AudioManager.instance;
        if (audioManager != null)
        {
            audioManager.StopAll();
            audioManager.Play(oceanLevelAudio);
        }

        startingColour = text.color;
        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = 0;
        }

    }

    void Update()
    {
        // checks whther game objective is met then calculates score for stage
        if (CheckIsComplete())
        {
            gameManager.GetComponent<Scoring>().CalculateStageScore("Ocean");
        }
    }

    // Checks what task the update corresponds too and shows the text
    public void UpdateAndDisplayTaskCounter(string binItem)
    {
        text.color = startingColour;
        if (RubbishTypes.RubbishBag.ToString().Equals(binItem))
        {
            tasks[0]++;
            text.text = +tasks[0] + "/" + rubbishToCollect + " Rubbish Collected";

        }
        else if (RubbishTypes.RecyclableCans.ToString().Equals(binItem))
        {
            tasks[1]++;
            text.text = tasks[1] + "/" + rubbishToCollect + " Recycling Collected";

        }
        else if (RubbishTypes.AppleCore.ToString().Equals(binItem))
        {
            tasks[2]++;
            text.text = tasks[2] + "/" + rubbishToCollect + " Compost Collected";

        }

        StartCoroutine(TextFadeOutRoutine());
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
    // If any of the tasks are less than 5 then the task is not completed
    // else its true
    public bool CheckIsComplete()
    {
        for (int i = 0; i < tasks.Length; i++)
        {
            if (tasks[i] < rubbishToCollect)
            {
                return false;
            }
        }
        isComplete = true;
        return true;
    }

    public int[] GetTasks()
    {
        return tasks;
    }
}


