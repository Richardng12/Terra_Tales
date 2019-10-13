using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=yFKg8qVclBk
public class Window: MonoBehaviour
{

    // Reference to Sprite Renderer component
    private Renderer rend;
    public SpriteRenderer sprite;

    public Rigidbody2D switch0;
    public bool hasPerson;

   public bool getHasPerson()
    {
        return hasPerson;
    }

    // Use this for initialization
    private void Start()
    {
        //hasPerson = false;
        rend = GetComponent<Renderer>();
        ChangeState();
    }

    // Update is called once per frame
    private void Update()
    {
            ChangeState();
    }

    // Update colour depending on switch
    private void ChangeState()
    {
            rend.material.color = switch0.gameObject.GetComponent<Renderer>().material.color;
            sprite.enabled = hasPerson;
    }

}
// public class Window: MonoBehaviour
// {   
//     public Sprite WindowPerson;
//     public counter = 0;
//     void Update() {
//         this.gameObject.GetComponent<SpriteRenderer>().sprite = WindowPerson;
//     }

// }