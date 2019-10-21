using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetCompleteCanvas : MonoBehaviour
{
    public Text currentScore;
    public Text timerBonus;
    public Text healthBonus;
    public GameObject liveScore;
    public Text totalScore;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        Scoring scoring = gameManager.GetComponent<Scoring>();
        timerBonus.text = scoring.CalculateTimerScore().ToString();
        healthBonus.text = scoring.CalculateHealthScore().ToString();
        currentScore.text = liveScore.GetComponent<LiveScore>().curScore.ToString();
        totalScore.text = Scoring.forestScore.ToString();
    }
}
