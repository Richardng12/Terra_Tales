using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFirstTimePlaying : MonoBehaviour
{
    // Start is called before the first frame update
    public void SetFirstTime(){
        GlobalGameManager.instance.delayedSet(false);
        Debug.Log("Set first play to false");
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
