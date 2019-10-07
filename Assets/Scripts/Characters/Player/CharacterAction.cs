using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAction : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;
    public float jumpSpeed = 8;
    private float moveInput;
    private bool jump = false;
    private bool loseHealth = false;

    void Update()
    {
        // Looks for jump input from the player 
        moveInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        // Does the certain actions for each player
        characterController.Move(moveInput, speed);
        characterController.Jump(jump, jumpSpeed);
        if (loseHealth)
        {
            characterController.LoseHealth();
        }
        loseHealth = false;
        jump = false;
    }
    
}
