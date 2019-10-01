using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float secondsToCountDown;
    public Text text;
    public IEnumerator startCountdown()
    {
        while (secondsToCountDown > 0)
        {
            int minutes =(int) secondsToCountDown / 60;
            int seconds = (int)secondsToCountDown - 60 * minutes;
            Debug.Log("Countdown: " + secondsToCountDown);
            yield return new WaitForSeconds(1.0f);
            secondsToCountDown--;
            text.text  = "Time Left: " + minutes.ToString() + ":" + seconds.ToString();
            
        }
    }

    public int timeInSeconds;
    private double timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
         StartCoroutine(startCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
