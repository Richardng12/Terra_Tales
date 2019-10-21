using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider energyBar;

    public Slider energyThreshold;

        public int maxEnergy;
    public int threshold;
    //private Slider slider;
    public int currentValue;

    // Start is called before the first frame update
    void Start()
    {
        energyThreshold.maxValue = maxEnergy;
        energyBar.maxValue = maxEnergy;
        energyThreshold.value = threshold;
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
