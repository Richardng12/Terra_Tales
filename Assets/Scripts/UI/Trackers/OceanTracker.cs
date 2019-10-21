using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OceanTracker : MonoBehaviour, ITracker<string>
{
    public int rubbishToCollect;
    static public int[] tasks = new int[3];

    public Text text;
    private Color startingColour;

    public float fadeOutTime;

    static public int oilSpriteDestroyed;

    public GameObject gameManager;


    AudioManager audioManager;

    string oceanLevelAudio = "OceanLevel";


    // Start is called before the first frame update

void Update(){
    
      if(Input.GetKeyDown(KeyCode.J)){
            tasks[0] = rubbishToCollect;
            tasks[1] = rubbishToCollect;
            tasks[2] = rubbishToCollect;
            text.text = "Tasks completed. Please Return to NPC";
            StartCoroutine(TextFadeOutRoutine());
            gameManager.GetComponent<Scoring>().StopStageTimer();
        }
}
    void Start()
    {
        audioManager = AudioManager.instance;
        if (audioManager != null)
        {
            audioManager.StopAll();
            AudioManager.mainMenuMusic = false;
            audioManager.Play(oceanLevelAudio);
        }

        oilSpriteDestroyed = 0;
        startingColour = text.color;
        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = 0;
        }

    }

    // Checks what task the update corresponds too and shows the text
    public void UpdateAndDisplayTaskCounter(string binItem)
    {
        Debug.Log("UPDATE DISPLAY");
        text.color = startingColour;
        if (RubbishTypes.RubbishBag.ToString().Equals(binItem))
        {
            tasks[0]++;
            text.text = tasks[0] + "/" + rubbishToCollect + " Rubbish Collected";

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
        
        Publisher.TriggerEvent("UpdateOceanScore");
        Publisher.TriggerEvent("IncreasePlayerHealth");

        if (CheckIsComplete())
        {
            text.text = "Tasks completed. Please Return to NPC";
        }

        StartCoroutine(TextFadeOutRoutine());

        // checks whther game objective is met then calculates score for stage
        if (CheckIsComplete())
        {
            gameManager.GetComponent<Scoring>().StopStageTimer();
        }
    }
    public void ShowWrongRubbishPrompt()
    {
        text.color = startingColour;
        text.text = "Hey that isn't meant to go there!!";
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
        return true;
    }

    public int[] GetTasks()
    {
        return tasks;
    }
}


