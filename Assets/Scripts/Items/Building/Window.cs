using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window: MonoBehaviour
{
    public Animation anim;

    public bool hasPerson;
    public bool isOn;

    public Sprite WindowOffEmpty;
    public Sprite WindowOnPerson;
    public Sprite WindowOnEmpty;

    // Use this for initialization
    private void Start()
    {
        anim = GetComponent<Animation>();

        hasPerson = false;
        isOn = false;
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public bool getHasPerson()
    {
        return hasPerson;
    }

    public bool getIsOn() {
        return isOn;
    }

    public void turnOn() {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = WindowOnPerson;
        hasPerson = true;
        isOn = true;
    }

    public void turnOff() {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = WindowOffEmpty;
        isOn = false;

        if (hasPerson) {
            // if window turned off while person is inside, signal to column parent that a mistake has been made
            transform.parent.GetComponent<Column>().wrongSwitch();
        } else {
            // if window has been correctly turned off, put the window on cooldown 
            transform.parent.GetComponent<Column>().putOnCD();
        }
    }

    public void personLeave() {
        // foreach(AnimationState state in anim) {
        //     state.speed = 1F;
        // }
        this.gameObject.GetComponent<SpriteRenderer>().sprite = WindowOnEmpty;
        hasPerson = false;
    }

    // turns on light of a window while maintaining its state (ie. whether or not the window had a person)
    public void turnOnEmpty() {
        if (hasPerson) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = WindowOnPerson;
        } else {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = WindowOnEmpty;
        }
        
        isOn = true;
    }
}