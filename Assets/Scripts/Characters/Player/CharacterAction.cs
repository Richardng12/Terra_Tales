using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAction : MonoBehaviour
{
    public CharacterController characterController;
    public Animator moveAnimator;
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
        if (Input.GetButtonDown("Fire1"))
        {
            moveAnimator.SetTrigger("castWater");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            moveAnimator.SetTrigger("grab");

        }
        // Sets the animation to moving
        moveAnimator.SetFloat("speed",Mathf.Abs(moveInput));
        if (characterController.OnGround())
        {
            moveAnimator.SetBool("onGround", true);
        }
        else
        {
            moveAnimator.SetBool("onGround", false);

        }
    }

    private void FixedUpdate()
    {
        // Does the certain actions for each player
        characterController.Move(moveInput, speed);
        if (characterController.Jump(jump, jumpSpeed)){
            // Shows jump animation
            Debug.Log("Jumping");
            moveAnimator.SetTrigger("isJumping");
        }
        if (loseHealth)
        {
            characterController.LoseHealth();
        }
        loseHealth = false;
        jump = false;
    }
    
}
