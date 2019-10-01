using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAction : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;

    public float jumpSpeed = 8;
    private float moveInput = 8;
    private bool jump = false;
    private bool shoot = true;
    public float fireSpeed = 0.3f;
    private float currentTime;

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButton("Fire1") && Time.time > currentTime)
        {
            characterController.ShootWaterGun();
            currentTime = currentTime+fireSpeed;
        }


    }


private void FixedUpdate()
{
        characterController.Move(moveInput, speed);
        characterController.Jump(jump, jumpSpeed);
        if(shoot && Input.GetButton("Fire1"))
        {
            characterController.ShootWaterGun();
        }
        shoot = false;
        jump = false;
    }
    
}
