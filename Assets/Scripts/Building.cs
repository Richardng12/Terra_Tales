using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public Rigidbody2D switch0;
    public Rigidbody2D switch1;
    public Rigidbody2D switch2;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (switch0.gameObject.GetComponent<Renderer>().material.color == switch1.gameObject.GetComponent<Renderer>().material.color && 
            switch1.gameObject.GetComponent<Renderer>().material.color == switch2.gameObject.GetComponent<Renderer>().material.color &&
            switch0.gameObject.GetComponent<Renderer>().material.color == new Color(249, 166, 2))
        {
            text.text = "Oh no energy max reached";
            //Decrease energy. Turn on aurora of POWA
        }
    }
}
