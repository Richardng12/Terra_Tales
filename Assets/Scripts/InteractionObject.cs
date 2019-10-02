using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{

    public bool tree;

    public GameObject itemNeeded;

    public bool talks;  //if true then the object can talk to the player

    public string message; //message that the object will give the player


    public void DoInteraction()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Talk()
    {
        Debug.Log(message);
    }
}
