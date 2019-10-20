using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityTracker : MonoBehaviour
{
    void OnEnable(){
        Publisher.StartListening("TimerFinished", Win);
    }

    void OnDisable(){
        Publisher.StopListening("TimerFinished", Win);
    }

    private void Win(){
        Debug.Log("NIG");
    }
}
