using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    public Text text;

    Coroutine co;
    public IEnumerator StartCountdown()
    {
        while (time > 0)
        {
            int minutes = (int)time / 60;
            int seconds = (int)time - 60 * minutes;
            string secondsString = "Time Left: " + minutes.ToString() + ":";
            if (seconds < 10)
            {
                secondsString += 0;
            }
            secondsString += seconds.ToString();
            yield return new WaitForSeconds(1.0f);
            time--;
            text.text = secondsString;
            //TODO add the finish level thing here which is called to end the level.
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        co = StartCoroutine(StartCountdown());
    }

    void StopTimer()
    {
        StopCoroutine(co);
    }


}
