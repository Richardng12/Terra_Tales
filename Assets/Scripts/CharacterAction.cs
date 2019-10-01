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
    private bool shoot = true;


    Rigidbody2D rb;

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump")){
            jump = true;
        }
        if(Input.GetButtonDown("Fire1")){
            shoot = true;
        }
    }

    private void FixedUpdate()
    {
        characterController.Move(moveInput);
        characterController.Jump(jump, jumpSpeed);
        if (shoot)
        {
            characterController.ShootWaterGun();
        }
        shoot = false;
        jump = false;
    }
    
}
