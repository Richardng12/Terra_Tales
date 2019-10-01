using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    private Slider slider;
    private int currentValue;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        currentValue = 10;
    }
    public void increaseEnergy(int i)
    {
        currentValue += i;
    }
    // Update is called once per frame
    void Update()
    {

        slider.value = currentValue;
    }
}
