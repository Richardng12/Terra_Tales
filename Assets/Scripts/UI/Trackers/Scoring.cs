using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scoring : MonoBehaviour
{
    public GameObject playerObject;

    public GameObject timerObject;
    static public int forestScore = 0;

    static public int oceanScore = 0;

    static public int cityScore = 0;

    static private Timer timer;

    static public double multiplier = 1;

    public int overallScore;

    private void Start()
    {
        Time.timeScale = 1f;
        timer = timerObject.GetComponent<Timer>();
    }

    // calculates score for each stage and overall score
    public void CalculateStageScore(string stage)
    {
        Debug.Log("Stage: " + stage);
        int currentScore = 0;
        if (!stage.Equals(""))
        {
            currentScore = ScoreCalculation();
        }

        // check the stage type and replaces score for stage if its greater than the current score 
        switch (stage)
        {
            case "Forest":
                currentScore += (ForestTracker.fireSpriteDestroyed * 50);
                currentScore += (ForestTracker.treesPlanted[0] * 100);
                currentScore =  (int) (currentScore * multiplier);
                forestScore = Math.Max(currentScore, forestScore);
                break;
            case "Ocean":
                currentScore += (OceanTracker.oilSpriteDestroyed * 20);
                currentScore += (OceanTracker.tasks[0] + OceanTracker.tasks[1] + OceanTracker.tasks[2]) * 50;
                currentScore = (int)(currentScore * multiplier);
                oceanScore = Math.Max(currentScore, oceanScore);
                break;
            case "City":
                cityScore = Math.Max(currentScore, cityScore);
                break;
            default:
                overallScore = forestScore + oceanScore + cityScore;
                break;
        }
    }

    public void StopStageTimer()
    {
        timer.StopTimer();
    }

    private int ScoreCalculation()
    {
        // Grabs the scripts from the objects provided
        CharacterController characterController = playerObject.GetComponent<CharacterController>();

        // Calculate the score from time and health
        int timerScore = (int)timer.time * 25;
        int healthScore = characterController.health * 1000;
        return timerScore + healthScore;
    }

    public int CalculateLiveScore(string stage)
    {
        int currentScore = 0;
        switch (stage)
        {
            case "Forest":
                currentScore += (ForestTracker.fireSpriteDestroyed * 500);
                currentScore += (ForestTracker.treesPlanted[0] * 1000);
                break;
            case "Ocean":
                currentScore += (OceanTracker.oilSpriteDestroyed * 200);
                currentScore += (OceanTracker.tasks[0] + OceanTracker.tasks[1] + OceanTracker.tasks[2]) * 500;
                break;
            case "City":
                break;
            default:
                break;
        }
        currentScore = (int)(currentScore * multiplier);

        return currentScore;
    }   

}
