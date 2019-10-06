using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OceanTracker : MonoBehaviour, ITracker<string>
{
    private int[] tasks = new int[3];

    public Text text;
    private Color startingColour;
    private bool isComplete;

    public float fadeOutTime;
    void Start()
    {
        startingColour = text.color;
        for(int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = 0;
        }
    }
    // Checks what task the update corresponds too and shows the text
    public void UpdateAndDisplayTaskCounter(string binItem)
    {
        text.color = startingColour;
        if (RubbishTypes.RubbishBag.ToString().Equals(binItem)) {
            tasks[0]++;
            text.text = + tasks[0]+ "/5 Rubbish Collected";

        }
        else if (RubbishTypes.RecyclableCans.ToString().Equals(binItem))
        {
            tasks[1]++;
            text.text = tasks[1] + "/5 Recycling Collected";

        }
        else if(RubbishTypes.AppleCore.ToString().Equals(binItem))
        {
            tasks[2]++;
            text.text = tasks[2] + "/5 Compost Collected";

        }

        StartCoroutine(TextFadeOutRoutine());
    }

    public IEnumerator TextFadeOutRoutine()
    {
        Color color = text.color;
        for ( float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        {
            text.color = Color.Lerp(color, Color.clear, Mathf.Min(1, t / fadeOutTime));

            yield return null;
        }

    }
    // If any of the tasks are less than 5 then the task is not completed
    // else its true
    public bool CheckIsComplete()
    {
        for(int i= 0; i < tasks.Length; i++)
        {
            if(tasks[i] < 5)
            {
                return false;
            }
        }
        return true;
    }

    public int[] GetTasks()
    {
        return tasks;
    }
}


