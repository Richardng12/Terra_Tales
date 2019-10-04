using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{

    private Window window0;
    private Window window1;
    private Window window2;
    private Switch sw0;
    private Building building;


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
