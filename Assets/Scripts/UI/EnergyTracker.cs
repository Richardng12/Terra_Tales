using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyTracker : MonoBehaviour
{
    public int max;
    private int current = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(current >= max) {
            Debug.Log("u lose");
        }
        Debug.Log(current);
    }

    public void increaseEnergy() {
        current++;
    }

    public void decreaseEnergy() {
        current--;
    }
}
