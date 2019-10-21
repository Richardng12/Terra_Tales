using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCompleteCanvasForest : MonoBehaviour
{
    public Text currentScore;
    public Text timerBonus;
    public Text healthBonus;
    public Text totalScore;
    public GameObject gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        //Calculate the score breakdown 
        Scoring scoring = gameManager.GetComponent<Scoring>();
        timerBonus.text = scoring.CalculateTimerScore().ToString();
        healthBonus.text = scoring.CalculateHealthScore().ToString();
        currentScore.text = scoring.CalculateLiveScore("Forest").ToString();
        totalScore.text = Scoring.forestScore.ToString();

        //Depending on the difficulty, transition to different level with the same difficulty
        string difficulty = GlobalGameManager.instance.difficulty;
        if (Equals(difficulty, "Easy"))
        {
            Publisher.TriggerEvent("OceanLevelEasy");
        }
        else if (Equals(difficulty, "Medium"))
        {
            Publisher.TriggerEvent("OceanLevelMedium");
        }
        else
        {
            Publisher.TriggerEvent("OceanLevelHard");
        }
    }
}
