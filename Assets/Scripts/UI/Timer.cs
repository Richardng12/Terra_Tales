using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    public Text text;

   static Coroutine co;
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

    public void StartTimer()
    {
        text = GetComponent<Text>();
        co = StartCoroutine(StartCountdown());
    }

    public void StopTimer()
    {
        Debug.Log("Stopped Timer");
        StopCoroutine(co);
    }


}
