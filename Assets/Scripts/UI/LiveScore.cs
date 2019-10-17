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

    // Update is called once per frame
    void Update()
    {
        liveScoreText.text = "Score: " + scoringObject.GetComponent<Scoring>().CalculateLiveScore("Forest").ToString();
    }
}
