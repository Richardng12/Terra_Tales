using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyTracker : MonoBehaviour
{
    // max number of windows that can be turned on 
    public float max;
    // number of windows that are currently on
    private float current = 0;
    
    public Slider energyBar;

    // Start is called before the first frame update
    void Start()
    {
       energyBar.maxValue = max;
    }

    // Update is called once per frame
    void Update()
    {
        // every second, update the slider value with the current number of windows on
        StartCoroutine(setSliderValue(current));
    }

    public void increaseEnergy() {
        current++;
    }

    public void decreaseEnergy() {
        current--;
    }

    public float getCurrent(){
        return current;
    }

    IEnumerator setSliderValue(float v) {
        yield return new WaitForSeconds(0f);
        energyBar.value = v;
    }
}
