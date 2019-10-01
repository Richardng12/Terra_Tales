﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAction : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;

    public float jumpSpeed = 8;
    private float moveInput = 8;
    private bool jump = false;
    private bool shoot = false;
    private float fireSpeed = 0.5f;
 
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonDow("Fire1"))
        {
            shoot = true;
        }


    }


private void FixedUpdate()
{
        characterController.Move(moveInput, speed);
        characterController.Jump(jump, jumpSpeed);
        if(shoot)
        {
            characterController.ShootWaterGun();
        }
        shoot = false;
        jump = false;
    }
    
}