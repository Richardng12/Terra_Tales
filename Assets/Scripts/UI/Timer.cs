using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    public Text text;

    private float countTime = 0f;
    private bool isComplete = false;

   static Coroutine co;
    // routine that countsdown from given time in second to zero
    public IEnumerator StartCountdown()
    {
        while (time > 0)
        {
            int minutes = (int)time / 60;
            int seconds = (int)time - 60 * minutes;
            string secondsString = "Time Left: " + minutes.ToString() + ":";
            // checks whether seconds is less than 10 then appends a 0 to the start of seconds string
            // to give the format of 0x for seconds 
            if (seconds < 10)
            {
                secondsString += 0;
            }
            secondsString += seconds.ToString();

            // waits 1 second before carrying on with function
            yield return new WaitForSeconds(1.0f);

            time--;
            countTime ++;
            text.text = secondsString;
            //TODO add the finish level thing here which is called to end the level.
        }
    }

    // used to start the countdown for timer
    public void StartTimer()
    {
        text = GetComponent<Text>();
        co = StartCoroutine(StartCountdown());
    }

    public void StopTimer()
    {
        StopCoroutine(co);
        if(countTime < 180 && !isComplete){
            isComplete = true;
            AchievementManager.instance.IncrementAchievement(AchievementType.Time);
        }
    }


}
