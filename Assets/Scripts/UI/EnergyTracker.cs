using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyTracker : MonoBehaviour
{
    public float max;
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
        if(current >= max) {
            Debug.Log("u lose");
        }
        Debug.Log(current);
        StartCoroutine(setSliderValue(current));
    }

    public void increaseEnergy() {
        current++;
    }

    public void decreaseEnergy() {
        current--;
    }

    IEnumerator setSliderValue(float v) {
        yield return new WaitForSeconds(0f);
        energyBar.value = v;
    }
}
