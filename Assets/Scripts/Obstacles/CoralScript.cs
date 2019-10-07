using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralScript : MonoBehaviour
{
    CharacterController character;

    // Coral damages player on collision
    void OnTriggerEnter2D(Collider2D other)
    {
        character = other.gameObject.GetComponent<CharacterController>();
        if (character != null)
        {
            character.LoseHealth();
        }
    }
}
