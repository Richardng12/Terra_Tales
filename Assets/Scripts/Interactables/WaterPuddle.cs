using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=yFKg8qVclBk
public class WaterPuddle : MonoBehaviour
{

    // Reference to Sprite Renderer component
    private Renderer rend;
    public EnergyBar waterBar;
    // Color value that we can set in Inspector
    // It's White by default
    [SerializeField]
    private Color colorToTurnTo = Color.white;



    // Change sprite color to selected color
    public Text allowSwitchText;
    private bool isOn;
    private Rigidbody2D switc;

    private bool allowSwitch;

    // Use this for initialization
    private void Start()
    {
        // Assign Renderer component to rend variable
        rend = GetComponent<Renderer>();
        switc = GetComponent<Rigidbody2D>();
        allowSwitchText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (allowSwitch && Input.GetKeyDown(KeyCode.E))
            ChangeState();
    }

    // Need to check if the trigger collided is a player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            allowSwitchText.gameObject.SetActive(true);
            allowSwitch = true;
        }
    }

    // Need to check if the trigger collided is a player to enable switch again
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            allowSwitchText.gameObject.SetActive(false);
            allowSwitch = false;
        }
    }

    private void ChangeState()
    {
        isOn = !isOn;
        if (isOn)
        {
            allowSwitchText.text = "Turned on";
            waterBar.increaseEnergy(1);
            rend.material.color = new Color(249, 166, 2);

        }
        else
        {
            rend.material.color = new Color(255, 255, 255);
            waterBar.increaseEnergy(-1);

            allowSwitchText.text = "Turned Off";

        }
    }

}