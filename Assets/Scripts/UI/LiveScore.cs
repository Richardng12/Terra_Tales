using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveScore : MonoBehaviour
{
    public Text liveScoreText;
    public Text scoreIncrement;

    private float origx;
    private float origy;

    public int curScore;

    private int prevScore = 0;

    private RectTransform assign_text_1RT;

    public GameObject scoringObject;

    // Start is called before the first frame update
    void Start()
    {
        liveScoreText.text = "Score: 0";
        assign_text_1RT = scoreIncrement.GetComponent<RectTransform>();
        origx = assign_text_1RT.anchoredPosition.x;
        origy = assign_text_1RT.anchoredPosition.y;
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
        prevScore = curScore;
        curScore = scoringObject.GetComponent<Scoring>().CalculateLiveScore("Forest");
        StartCoroutine(fadingText());
        liveScoreText.text = "Score: " + curScore.ToString();
    }

    void UpdateOceanLiveScore()
    {
        prevScore = curScore;
        curScore = scoringObject.GetComponent<Scoring>().CalculateLiveScore("Ocean");
        StartCoroutine(fadingText());
        liveScoreText.text = "Score: " + curScore.ToString();
    }

    IEnumerator fadingText()
    {
        int diff = curScore - prevScore;
        scoreIncrement.text = "+" + diff;
        scoreIncrement.color = new Color(255, 255, 255, 1);
        assign_text_1RT.anchoredPosition = new Vector3(origx, origy, 0f);

        for (int i = 0; i < 100; i++)
        {
            float j = i / 100f;
            j = 1 - j;
            yield return new WaitForSeconds(0.01f);
            scoreIncrement.color = new Color(255, 255, 255, j);
            assign_text_1RT.anchoredPosition = new Vector3(origx, origy + i, 0f);
        }
    }
}
