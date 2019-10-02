using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public Switch switch0;
    public Switch switch1;
    public Switch switch2;
    public Rigidbody2D building;
    public EnergyBar energyBar;
    public Text text;
    private bool applied;
    // Start is called before the first frame update
    void Start()
    {
        applied = false;
    }

    public void setAllOn()
    {
        switch0.setIsOn(true);
        switch1.setIsOn(true);
        switch2.setIsOn(true);
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (switch0.isOn && switch1.isOn && switch2.isOn)
        {
            if (!applied)
            {
                applied = true;
                energyBar.increaseEnergy(10);
            }
            text.text = "Oh no energy max reached";
            building.gameObject.GetComponent<Renderer>().material.color = Color.red;
            //Decrease energy. Turn on aurora of POWA
        }
        else
        {
            if (applied)
            {
                energyBar.increaseEnergy(-10);

            }
            applied = false;
            
            building.gameObject.GetComponent<Renderer>().material.color = Color.green;

        }
    }
}
