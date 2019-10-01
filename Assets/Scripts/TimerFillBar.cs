using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerFillBar : MonoBehaviour
{
    private Slider slider;
    private float currentValue;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        currentValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentValue += 0.1f;

        slider.value = currentValue;
    }
}
