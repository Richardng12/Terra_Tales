using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text scoreText;

    public Text playerText;

    public Button nextButton;

    private int totalScore;

    static public HighScore instance;

    static public Dictionary<string, int> highScoreDict = new Dictionary<string, int>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
        nextButton.onClick.AddListener(AddScore);
    }

    public void AddScore()
    {
        highScoreDict.Add(playerText.text, totalScore);
        highScoreDict = highScoreDict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
    }
}
