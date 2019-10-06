using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scoring : MonoBehaviour
{
    // Start is called before the first frame update
    static public int forestScore = 0;

    static public int oceanScore = 0;

    static public int cityScore = 0;

    public int overallScore;
    public void CalculateStageScore(string stage)
    {
        int currentScore = ScoreCalculation();
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
        return 0;
    }
}
