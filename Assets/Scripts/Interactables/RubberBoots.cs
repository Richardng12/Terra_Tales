using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberBoots : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterController character = collision.gameObject.GetComponent<CharacterController>();

        // if player's boots' hp is full, player can't pick it up
        if (character != null && character.GetComponent<BootsBar>().getBootsHealth() < character.GetComponent<BootsBar>().bootsMaxHealth)
        {
            pickUp(character);
        }
    }

    private void pickUp(CharacterController character)
    {
        // picking up boots will fill up the boots' health
        if(character.GetComponent<BootsBar>() != null)
        character.GetComponent<BootsBar>().fillBootsHealth();
        Destroy(gameObject);
    }
}
