using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveScore : MonoBehaviour
{
    public Text liveScoreText;

    public GameObject scoringObject;

    // Start is called before the first frame update
    void Start()
    {
        liveScoreText.text = "Score: 0";
    }

    private void OnEnable()
    {
        Publisher.StartListening("UpdateForestScore", UpdateForestLiveScore);
        Publisher.StartListening("UpdateOceanScore", UpdateOceanLiveScore);
    }

    private void OnDisable()
    {
        Publisher.StopListening("UpdateForestScore", UpdateForestLiveScore);
        Publisher.StopListening("UpdateOceanScore", UpdateOceanLiveScore);
    }

    void UpdateForestLiveScore()
    {
        liveScoreText.text = "Score: " + scoringObject.GetComponent<Scoring>().CalculateLiveScore("Forest").ToString();
    }

    void UpdateOceanLiveScore()
    {
        Debug.Log("HELLO");
        liveScoreText.text = "Score: " + scoringObject.GetComponent<Scoring>().CalculateLiveScore("Ocean").ToString();
    }
}
