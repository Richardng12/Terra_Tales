using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{

    public List<Column> columns;

    public Sprite shortcircuit;
    public Sprite notShortcircuit;

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
            this.gameObject.GetComponent<SpriteRenderer>().sprite = shortcircuit;
        } else {
            shortCircuit = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = notShortcircuit;
        }
    }

    void OnTriggerStay2D(Collider2D collision) {
        if(collision.tag == "Player"){
        CharacterController character = collision.gameObject.GetComponent<CharacterController>();

        if (character != null && shortCircuit) {
            if (character.GetComponent<BootsBar>().getBootsHealth() > 0) {
                // if player's boots' health is above 0, the boots will take damage instead of the player when standing on a short-circuited building
                if (!character.GetComponent<BootsBar>().isOnCD()) {
                    character.GetComponent<BootsBar>().putOnCD();
                    character.GetComponent<BootsBar>().loseBootsHealth();
                    Debug.Log("boots health: " + character.GetComponent<BootsBar>().getBootsHealth());
                }
                
            } else {
                character.LoseHealth();
                Debug.Log(character.health);
            }     
        } 
        }
    }

    // turn all the building lights on due to wrong switch by player
    public void turnAllOn()
    {
        foreach (Column column in columns) 
        {
            if (!column.ifWindowOn()) {
                column.turnOnWindows(false);
            }   
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
