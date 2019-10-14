using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=yFKg8qVclBk
public class Window: MonoBehaviour
{
    public Animation anim;

    public bool hasPerson;
    public bool isOn;

    public Sprite WindowOffEmpty;
    public Sprite WindowOnPerson;

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
            transform.parent.GetComponent<Column>().wrongSwitch();
        }
    }

    public void personLeave() {
        // foreach(AnimationState state in anim) {
        //     state.speed = 1F;
        // }
        hasPerson = false;
    }

    public void turnOnEmpty() {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = WindowOnPerson;
        isOn = true;
    }

    GameObject CreateText(Transform canvas_transform, float x, float y, string text_to_print, int font_size, Color text_color)
    {
        GameObject UItextGO = new GameObject("Text2");
        UItextGO.transform.SetParent(canvas_transform);

        RectTransform trans = UItextGO.AddComponent<RectTransform>();
        trans.anchoredPosition = new Vector2(x, y);

        Text text = UItextGO.AddComponent<Text>();
        text.text = text_to_print;
        text.fontSize = font_size;
        text.color = text_color;

        return UItextGO;
    }
}