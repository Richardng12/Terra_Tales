using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text scoreText;

    public Text playerText;

    public Button nextButton;

    private int totalScore;

    static public HighScore instance;

    static private Dictionary<string, int> highScoreDict;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            highScoreDict = new Dictionary<string, int>();
            // Dont destroy this object when a new scene is loaded
            DontDestroyOnLoad(this);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        totalScore = Scoring.cityScore + Scoring.forestScore + Scoring.oceanScore;
        scoreText.text = totalScore.ToString();
        nextButton.onClick.AddListener(SetHighScore);
    }

    public void SetHighScore()
    {
        highScoreDict.Add(playerText.text, totalScore);
        foreach(KeyValuePair<string, int> item in highScoreDict)
        {
            Debug.Log("Name: " + item.Key + " Score: " + item.Value);
        }
    }
}
