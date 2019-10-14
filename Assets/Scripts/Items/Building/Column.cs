using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    
    public List<Window> windows;

    // Start is called before the first frame update
    void Start()
    { 

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
    }

    public void useSwitch() {
        bool correct = true;

        foreach (Window window in windows) {
            window.turnOff();
        }
    }

    public void wrongSwitch() {
        Debug.Log("OIII");
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

    IEnumerator waitToTurnOn()
    {
        yield return new WaitForSeconds(1);
        transform.parent.GetComponent<Building>().turnAllOn();
    } 
}
