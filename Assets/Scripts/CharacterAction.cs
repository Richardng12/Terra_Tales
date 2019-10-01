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

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButton("Fire1"))
        {
            characterController.CheckFireRate();
        }
    }


private void FixedUpdate()
{
        characterController.Move(moveInput, speed);
        characterController.Jump(jump, jumpSpeed);
        jump = false;
    }
    
}
