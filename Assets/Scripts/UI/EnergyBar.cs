using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider energyBar;

    public int maxEnergy;
    //private Slider slider;
    public int currentValue;

    // Start is called before the first frame update
    void Start()
    {
        energyBar.maxValue = maxEnergy;
        currentValue = 0;
    }

    // Increase energy bar energy
    public void increaseEnergy(int i)
    {
        //Debug.Log("increased energy" + i.ToString());
        currentValue += i;
    }

    // Update is called once per frame
    void Update()
    {

        energyBar.value = currentValue;
    }

    public bool isFull()
    {
        return currentValue > energyBar.maxValue;
    }
    public bool isEmpty()
    {
        return currentValue == 0;
    }
}
