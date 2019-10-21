using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CityTracker : MonoBehaviour
{

 public Text text;


    public float fadeOutTime;

    public GameObject gameManager;
    public GameObject energyTracker;
    private Color startingColour;
    public GameObject timer;
    AudioManager audioManager;
    public bool isCompleted = false;

    public static int maxEnergyReached;

    public static int energyDiff;

    public static int cloudsDestroyed;


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
        maxEnergyReached = 0;
        cloudsDestroyed = 0;
        energyDiff = 0;
        startingColour = text.color;
        audioManager = AudioManager.instance;
        if(audioManager != null)
        {
            audioManager.StopAll();
            AudioManager.mainMenuMusic = false;
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
        Publisher.StartListening("UpdateEnergy", UpdateEnergy);
        Publisher.StartListening("CloudDestroyed", CloudKilled);
    }

    void OnDisable(){
        Publisher.StopListening("UpdateEnergy", UpdateEnergy);
        Publisher.StopListening("CloudDestroyed", CloudKilled);
    }

    private void UpdateEnergy()
    {
        maxEnergyReached = Math.Max((int) energyTracker.GetComponent<EnergyTracker>().getCurrent(), maxEnergyReached);
        SetEnergyDiff();
    }

    private void CloudKilled()
    {
        cloudsDestroyed++;
    }

    private void SetEnergyDiff()
    {
        energyDiff = (int) energyTracker.GetComponent<EnergyTracker>().max - maxEnergyReached;
    }
}
