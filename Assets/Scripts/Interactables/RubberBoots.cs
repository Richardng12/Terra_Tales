using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberBoots : MonoBehaviour
{
    private int life = 10;
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

        // if player's boots' hp is full, player can't pick up
        if (character != null && (character.getBoots() == null || character.getBoots().life < 10))
        {
            Destroy(character.getBoots());
            pickUp(character);
        }
    }

    private void pickUp(CharacterController character) {
        character.setBoots(this);
        Debug.Log("picked up!");
    }

    public void loseBootsLife() {
        life--;
    }

    public int getBootsLife() {
        return life;
    }
}
