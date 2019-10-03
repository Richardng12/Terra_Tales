using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /**

    private Transform playerPos;

    private CharacterController player;

    private Rigidbody2D rb;


    //Vectors
    private Vector2 moveVelocity;
    private Vector2 moveInput;
    private Vector2 pos;
    private Vector2 tempMove;
    private Vector2 oppMove;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /**
        pos = new Vector2(playerPos.position.x, playerPos.position.y);
        oppMove = rb.position - pos;
        moveInput = pos - rb.position;
        moveVelocity = moveInput.normalized * 4;
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    

        moveVelocity = new Vector2(5, 5);
        rb.MovePosition(rb.position + moveVelocity *Time.fixedDeltaTime);
       
        
    }

    */


    private Transform playerPos;

    private CharacterController player;

    private Rigidbody2D rb;

    private Vector2 velocity;


    private Vector2 moveVelocity;
    private Vector2 moveInput;
    private Vector2 pos;
    private Vector2 tempMove;
    private Vector2 oppMove;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        //velocity = new Vector2(5f, 5f);
        rb = gameObject.GetComponent<Rigidbody2D>();


    }

    void Update()
    {
        pos = new Vector2(playerPos.position.x, playerPos.position.y);
        oppMove = rb.position - pos;
        moveInput = pos - rb.position;
        moveVelocity = moveInput.normalized * 4;

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }


}
