using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{

    public Window window0;
    public Window window1;
    public Window window2;
    public Switch sw0;
    public Building building;


    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        // If it is off and there is a person, then switch on building
        bool hasPerson = window0.getHasPerson() || window1.getHasPerson() || window2.getHasPerson();
        if(hasPerson && sw0.getIsOn() == false)
        {
            building.setAllOn();
        }
    }
}
