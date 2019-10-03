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

    public void setAllOn()
    {
        foreach(Switch switcha in switches){
            switcha.setIsOn(true);
        }
        Update();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit player");
        CharacterController character = other.gameObject.GetComponent<CharacterController>();
        if (character != null && shortCircuit)
        {
            character.LoseHealth();
        }
    }
    private IEnumerator HandleIt()
    {
        applied = true;
        // process pre-yield
        yield return new WaitForSeconds(5.0f);
        shortCircuit = false;
        this.gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        // process post-yield
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
                shortCircuit = true;
                // Change colour for 5 seconds
                this.gameObject.GetComponent<Renderer>().material.color = Color.red;
                StartCoroutine(HandleIt());
            }
            
        }
        else
        {
            if (applied)
            {
                energyBar.increaseEnergy(-5);

            }
            applied = false;
            shortCircuit = false;

            this.gameObject.GetComponent<Renderer>().material.color = Color.white;

        }
    }
}
