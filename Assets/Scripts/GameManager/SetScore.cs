using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SetScore : MonoBehaviour
{
    public Text forestScore;

    public Text oceanScore;

    public Text cityScore;

    public Text rankOneName, rankOneScore;

    public Text rankTwoName, rankTwoScore;

    public Text rankThreeName, rankThreeScore;

    public Text rankFourName, rankFourScore;

    public Text rankFiveName, rankFiveScore;


    // Start is called before the first frame update
    void Start()
    {
        forestScore.text = Scoring.forestScore.ToString();
        oceanScore.text = Scoring.oceanScore.ToString();
        cityScore.text = Scoring.cityScore.ToString();

        if (GlobalGameManager.instance.highScoreDict.Count > 0) {
            SetHighScores();
        }
    }

    private void SetHighScores()
    {
        for (int i = 0; i < 5; i++)
        {
            string name = GlobalGameManager.instance.highScoreDict.ElementAt(i).Key;
            string score = GlobalGameManager.instance.highScoreDict.ElementAt(i).Value.ToString();
            if (i == 0)
            {
                rankOneName.text = name;
                rankOneScore.text = score;
            }
            else if (i == 1)
            {
                rankTwoName.text = name;
                rankTwoScore.text = score;
            }
            else if (i == 2)
            {
                rankThreeName.text = name;
                rankThreeScore.text = score;
            }
            else if (i == 3)
            {
                rankFourName.text = name;
                rankFourScore.text = score;
            }
            else
            {
                rankFiveName.text = name;
                rankFiveScore.text = score;
            }

            if (i + 1 == GlobalGameManager.instance.highScoreDict.Count)
            {
                break;
            }
        }
    }
}
