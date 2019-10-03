using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    private Switch[] switches;
    
    //public Rigidbody2D building;
    public EnergyBar energyBar;
   // public Text text;

    private bool applied;
    // Start is called before the first frame update
    void Start()
    {
        switches = GetComponentsInChildren<Switch>();
        applied = false;
        Update();

        foreach (Switch switcha in switches)
        {
            switcha.building = this;
            switcha.energyBar = energyBar;
        }
    }

    public void setAllOn()
    {
        foreach(Switch switcha in switches){
            switcha.setIsOn(true);
        }
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        bool switchOn = true;
        foreach(Switch switcha in switches)
        {
            switchOn &= switcha.isOn;
        }
        if (switchOn)
        {
            if (!applied)
            {
                applied = true;
                energyBar.increaseEnergy(5);
            }
         //   text.text = "Oh no energy max reached";
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
            //Decrease energy. Turn on aurora of POWA
        }
        else
        {
            if (applied)
            {
                energyBar.increaseEnergy(-5);

            }
            applied = false;
            
            this.gameObject.GetComponent<Renderer>().material.color = Color.white;

        }
    }
}
