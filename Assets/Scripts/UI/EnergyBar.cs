using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider2;
    private Slider slider;
    public int currentValue;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void increaseEnergy(int i)
    {
        Debug.Log("increased energy" + i.ToString());
        currentValue += i;
    }
    // Update is called once per frame
    void Update()
    {

        slider.value = currentValue;
    }

    public bool isFull()
    {
        return currentValue > slider.maxValue;
    }
    public bool isEmpty()
    {
        return currentValue == 0;
    }
}
