using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{

    public List<Column> columns;

    private bool shortCircuit;
    // Start is called before the first frame update
    void Start()
    {
        shortCircuit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ifAllOn()) {
            shortCircuit = true;
        } else {
            shortCircuit = false;
        }
    }

    void OnTriggerStay2D(Collider2D collision) {
        CharacterController character = collision.gameObject.GetComponent<CharacterController>();

        if (character != null && shortCircuit) {
            if (character.getBootsHealth() > 0) {
                // if player's boots' health is above 0, the boots will take damage instead of the player when standing on a short-circuited building
                character.loseBootsHealth();
                Debug.Log("boots health: " + character.getBootsHealth());
            } else {
                character.LoseHealth();
                Debug.Log("take dmg");
            }     
        } 
    }

    // turn all the building lights on due to wrong switch by player
    public void turnAllOn()
    {
        foreach (Column column in columns) 
        {
            column.turnOnWindows(false);
        }  
    }

    public bool ifAllOn() {
        foreach (Column column in columns) {
            if (!column.ifWindowOn()) {
                return false;
            }
        }
        return true;
    }

    public List<Column> getColumns() {
        return columns;
    }
}
