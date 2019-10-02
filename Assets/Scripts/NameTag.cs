using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=yFKg8qVclBk
public class NameTag : MonoBehaviour
{


    public Text allowSwitchText;
    private Rigidbody2D switc;

    private bool allowSwitch;

    private void Start()
    {
        // Assign Renderer component to rend variable
        switc = GetComponent<Rigidbody2D>();
        allowSwitchText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (allowSwitch && Input.GetKeyDown(KeyCode.E))
        {
            allowSwitchText.text = "we";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            allowSwitchText.gameObject.SetActive(true);
            allowSwitch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            allowSwitchText.gameObject.SetActive(false);
            allowSwitch = false;
        }
    }


}