using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCompleteCanvasOcean : MonoBehaviour
{
    public Text currentScore;
    public Text timerBonus;
    public Text healthBonus;
    public Text totalScore;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        Scoring scoring = gameManager.GetComponent<Scoring>();
        timerBonus.text = scoring.CalculateTimerScore().ToString();
        healthBonus.text = scoring.CalculateHealthScore().ToString();
        currentScore.text = scoring.CalculateLiveScore("Ocean").ToString();
        totalScore.text = Scoring.oceanScore.ToString();
    }

}
