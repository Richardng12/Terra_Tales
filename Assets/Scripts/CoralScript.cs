using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralScript : MonoBehaviour
{
    CharacterController character;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit player");
        character = other.gameObject.GetComponent<CharacterController>();
        if (character != null)
        {
            character.LoseHealth();
        }
    }
}
