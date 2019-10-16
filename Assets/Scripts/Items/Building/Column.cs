using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    
    public List<Window> windows;
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

    public void putOnCD() {
        onCD = true;
        StartCoroutine(waitForCD());
    }

    public bool getOnCD() {
        return onCD;
    }

    IEnumerator waitForCD() {
        yield return new WaitForSeconds(5f);
        onCD = false;
        Debug.Log("off CD!!");
    }

    IEnumerator waitToTurnOn()
    {
        yield return new WaitForSeconds(1);
        transform.parent.GetComponent<Building>().turnAllOn();
    } 
}
