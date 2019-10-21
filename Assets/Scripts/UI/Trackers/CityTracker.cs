using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityTracker : MonoBehaviour
{

 public Text text;


    public float fadeOutTime;

    public GameObject gameManager;

    private Color startingColour;
        public GameObject timer;
       AudioManager audioManager;

       public bool isCompleted = false;


    string cityLevelAudio = "CityLevel";

     void Update()
    {

      if(Input.GetKeyDown(KeyCode.J)){
         timer.GetComponent<Timer>().StopTimer();
           isCompleted = true;
            timer.GetComponent<Timer>().text.text = "Time Left: 0:00";
             text.text = "Task finished. Please Return to NPC";
            StartCoroutine(TextFadeOutRoutine());
            gameManager.GetComponent<Scoring>().StopStageTimer();
        }
        if(timer.GetComponent<Timer>().time == 0f){
            isCompleted = true;
            text.text = "Task finished. Please Return to NPC";
            StartCoroutine(TextFadeOutRoutine());
            gameManager.GetComponent<Scoring>().StopStageTimer();
        }
    }

     void Start()
    {
        startingColour = text.color;
        audioManager = AudioManager.instance;
        if(audioManager != null)
        {
            audioManager.StopAll();
            audioManager.Play(cityLevelAudio);
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
    void OnEnable(){
        Publisher.StartListening("TimerFinished", Win);
    }

    void OnDisable(){
        Publisher.StopListening("TimerFinished", Win);
    }

    private void Win(){
        Debug.Log("GIN");
    }
}
