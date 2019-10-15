﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{

    public List<Column> columns;

    private bool shortCircuit;
    // Start is called before the first frame update
    void Start()
    {
        shortCircuit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ifAllOn()) {
            shortCircuit = true;
        } else {
            shortCircuit = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision) {
        CharacterController character = collision.gameObject.GetComponent<CharacterController>();

        if (character != null && shortCircuit && character.getBoots() == null) {
            if (character.getBoots() == null) {
                //TO DO
                Debug.Log("take dmg");
            } else {
                character.getBoots().loseBootsLife();
            }     
        } 
    }

    // Turn all the building lights on due to wrong switch by player
    public void turnAllOn()
    {
        foreach (Column column in columns) 
        {
            column.turnOnWindows(false);
        }  
    }

    public bool ifAllOn() {
        foreach (Column column in columns) {
            if (!column.ifWindowOn()) {
                return false;
            }
        }
        return true;
    }

    public List<Column> getColumns() {
        return columns;
    }
}
