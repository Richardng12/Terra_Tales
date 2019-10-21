﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    
    public List<Window> windows;
    // cooldown property: after the lights of a column has been turned on by the game, put it on cooldown to ensure the lights don't get turned
    // on immediately after again
    private bool onCD;

    // Start is called before the first frame update
    void Start()
    { 
        onCD = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turnOnWindows(bool withPerson) {
        if (withPerson) {
            foreach (Window window in windows) {
                window.turnOn();
            }
        } else {
            foreach (Window window in windows) {
                window.turnOnEmpty();
            }
        }
        transform.parent.GetComponent<Building>().transform.parent.GetComponent<EnergyTracker>().increaseEnergy();   
    }

    public void useSwitch() {
        bool correct = true;

        foreach (Window window in windows) {
            window.turnOff();
        }
        transform.parent.GetComponent<Building>().transform.parent.GetComponent<EnergyTracker>().decreaseEnergy(); 
    }

    // method called when player incorrectly turns off the lights
    public void wrongSwitch() {
        StartCoroutine(waitToTurnOn());
    }

    public bool ifWindowOn() {
        foreach (Window window in windows) {
            if (window.getIsOn()) {
                return true;
            }
        }
        return false;
    }

    public List<Window> getWindows() {
        return windows;
    }

    public void putOnCD() {
        onCD = true;
        StartCoroutine(waitForCD());
    }

    public bool getOnCD() {
        return onCD;
    }

    IEnumerator waitForCD() {
        yield return new WaitForSeconds(10f);
        onCD = false;
    }

    // allow the lights to be turned off for a few seconds before notifying building to turn all its lights on
    IEnumerator waitToTurnOn()
    {
        yield return new WaitForSeconds(1f);
        transform.parent.GetComponent<Building>().turnAllOn();
    } 
}
