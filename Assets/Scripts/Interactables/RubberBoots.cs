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

    private void OnTriggerEnter2D(Collider2D collision) {
        CharacterController character = collision.gameObject.GetComponent<CharacterController>();

        // if player's boots' hp is full, player can't pick it up
        if (character != null && character.getBootsHealth() < 10)
        {
            pickUp(character);
            Debug.Log("GOT IT");
        }
    }

    private void pickUp(CharacterController character) {
        character.fillBootsHealth();
        Destroy(gameObject);
    }
}
