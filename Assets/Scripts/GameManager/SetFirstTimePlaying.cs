using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFirstTimePlaying : MonoBehaviour
{
    // Sets the first time playing to false
    public void SetFirstTime(){
        GlobalGameManager.instance.delayedSet(false);
        Debug.Log("Set first play to false");
    }
}
