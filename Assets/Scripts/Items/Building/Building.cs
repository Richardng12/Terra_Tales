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
    private CharacterController character;
    private bool inBuilding;
    private bool applied;
    private bool shortCircuit;
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

    // Set all the building lights on
    public void setAllOn()
    {
        foreach (Switch switcha in switches)
        {
            switcha.setIsOn(true);
        }
        Update();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        inBuilding = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        inBuilding = true;
        character = other.gameObject.GetComponent<CharacterController>();

    }

    // Set the colour to red to ward the player
    private IEnumerator DelayedNormal()
    {
        applied = true;
        // process pre-yield
        yield return new WaitForSeconds(1f);
        if (shortCircuit)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        }
        shortCircuit = false;

        // process post-yield
    }

    // Update is called once per frame
    void Update()
    {
        bool switchOn = true;
        foreach (Switch switcha in switches)
        {
            switchOn &= switcha.isOn;
        }
        if (switchOn)
        {
            // Set building to red if shortcircuited and update energy bar.
            if (!applied)
            {
                applied = true;
                energyBar.increaseEnergy(5);
                shortCircuit = true;
                // Change colour for 5 seconds
                this.gameObject.GetComponent<Renderer>().material.color = Color.red;
                StartCoroutine(DelayedNormal());
            }

        }
        else
        {
            if (applied)
            {
                // Undo energy bar change
                energyBar.increaseEnergy(-5);

            }
            applied = false;
            shortCircuit = false;

            this.gameObject.GetComponent<Renderer>().material.color = Color.white;

        }
        
        // Make the character lose health if the building is shortcircuited.
        if (character != null && shortCircuit && inBuilding)
        {
            character.LoseHealth();
        }
    }
}
