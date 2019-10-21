using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCompleteCanvasCity : MonoBehaviour
{

    public Text currentScore;
    public Text energyBarBonus;
    public Text healthBonus;
    public Text totalScore;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        Scoring scoring = gameManager.GetComponent<Scoring>();
        energyBarBonus.text = scoring.CalculateEnergyScore().ToString();
        healthBonus.text = scoring.CalculateHealthScore().ToString();
        currentScore.text = scoring.CalculateLiveScore("City").ToString();
        totalScore.text = Scoring.cityScore.ToString();

        string difficulty = GlobalGameManager.instance.difficulty;
        if (Equals(difficulty, "Easy"))
        {
            Publisher.TriggerEvent("ForestLevelEasy");
        }
        else if (Equals(difficulty, "Medium"))
        {
            Publisher.TriggerEvent("ForestLevelMedium");
        }
        else
        {
            Publisher.TriggerEvent("ForestLevelHard");
        }
    }
}
