using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;

    //The object the enemy is chasing
    //Transform is the position vector
    private Transform playerPos;

    //reference the player object
    private CharacterController player;

    
    //Variables to give enemy velocity
    private Vector moveVelocity;
    private Vector moveInput;
    private Vector pos;
    private Vector tempMove;
    private Vector oppMove;
    

    //initialize the enemy body
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        
        //Find the player which has the tag of Player and grab player script
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        //Find the position of the "target" which has the tag of Player
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        

        pos = new Vector2(playerPos.position.x, playerPos.position.y);
        oppMove = rb.position - pos;
        moveInput = pos - rb.position;
        moveVelocity = moveInput.normalized * speed;
        colCount = 0;
        time = 100;
    

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
