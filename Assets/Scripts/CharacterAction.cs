using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAction : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;

    public float jumpSpeed;
    private float moveInput;
    private bool jump = false;


    Rigidbody2D rb;

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump")){
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        characterController.Move(moveInput);
        characterController.Jump(jump, jumpSpeed);
        jump = false;
    }
    
}
