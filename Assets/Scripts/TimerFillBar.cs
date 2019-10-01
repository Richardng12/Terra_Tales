using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerFillBar : MonoBehaviour
{
    public float secondsToCountDown;
    private float secondsLeft;
    public Text text;

    // Unity UI References
    public Slider slider;
    public Text displayText;

    float currentValue = 0f;
    // Start is called before the first frame update
    void Start()
    {
        currentValue += 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentValue;
    }
}
