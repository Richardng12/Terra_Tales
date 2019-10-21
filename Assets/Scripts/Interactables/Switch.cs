using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Switch : MonoBehaviour
{
    // field allows the switch to interacted with
    private bool switchAllowed;

    // Use this for initialization
    void Start()
    {
        switchAllowed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (switchAllowed && Input.GetKeyDown(KeyCode.E))
        {
            transform.parent.GetComponent<Column>().useSwitch();
        }
    }

    // two triggers below allow/disallow player to interact with switch depending on the player's proximity to the switch
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            switchAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            switchAllowed = false;
        }
    }
}