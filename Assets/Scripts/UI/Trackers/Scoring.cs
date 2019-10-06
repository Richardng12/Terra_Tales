﻿using System.Collections;
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

    public int overallScore;
    public void CalculateStageScore(string stage)
    {
        timerObject.GetComponent<Timer>().StopTimer();
        int currentScore = ScoreCalculation();

        // check the stage type and replace score for stage if its greater
        switch (stage)
        {
            case "Forest":
                forestScore = Math.Max(currentScore, forestScore);
                break;
            case "Ocean":
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

    private int ScoreCalculation()
    {
        // Grabs the scripts from the objects provided
        CharacterController characterController = playerObject.GetComponent<CharacterController>();
        Timer timer = timerObject.GetComponent<Timer>();

        // Calculate the score from time and health
        int timerScore = (int)timer.time * 50;
        int healthScore = characterController.health * 200;

        return timerScore + healthScore;
    }
}