using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=yFKg8qVclBk
public class Switch : MonoBehaviour
{

    // Reference to Sprite Renderer component
    private Renderer rend;
    public EnergyBar energyBar;
    // Color value that we can set in Inspector
    // It's White by default
    [SerializeField]
    private Color colorToTurnTo = Color.white;

    public Window window0;
    public Window window1;
    public Window window2;
    public Building building;

    // Change sprite color to selected color

    public Text allowSwitchText;
    public bool isOn;
    private Rigidbody2D switc;

    private bool allowSwitch;

    public bool getIsOn()
    {
        return isOn;
    }

    public void setIsOn(bool toSet)
    {
        isOn = toSet;
        ChangeColour();
    }

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
        {
            ChangeState();
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

    private void ChangeState()
    {
        isOn = !isOn;

        if ((window0.hasPerson || window1.hasPerson || window2.hasPerson)&& !isOn) {
            building.setAllOn();
        }
        ChangeColour();
    }
    private void ChangeColour()
    {
        if (isOn)
        {
            allowSwitchText.text = "Turned on";
            energyBar.increaseEnergy(1);
            rend.material.color = new Color(249, 166, 2);

        }
        else
        {
            rend.material.color = new Color(255, 255, 255);
            energyBar.increaseEnergy(-1);

            allowSwitchText.text = "Turned Off";

        }
    }

}