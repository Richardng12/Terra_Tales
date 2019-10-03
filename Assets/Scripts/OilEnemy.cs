using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilEnemy : MonoBehaviour
{
    //Speed of enemy
    public float speed;

    //Reference to player position and object
    private Transform playerPos;
    private CharacterController player;

    //Reference to centre of map
    private Transform centrePos;

    //Initialise object body
    private Rigidbody2D rb;

    //Variables to calculate velocity
    private Vector2 moveVelocity;
    private Vector2 moveInput;
    private Vector2 pos;
    private Vector2 tempMove;
    private Vector2 oppMove;

    //Variables for boundary collision
    private int travelTime = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        centrePos = GameObject.FindGameObjectWithTag("Centre").transform;



        //velocity = new Vector2(5f, 5f);
        rb = gameObject.GetComponent<Rigidbody2D>();


    }

    void Update()
    {
        pos = new Vector2(playerPos.position.x, playerPos.position.y);
        oppMove = rb.position - pos;
        moveInput = pos - rb.position;
        moveVelocity = moveInput.normalized * speed;

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Collision with player
        if (other.CompareTag("Player"))
        {
            //TODO player loses hp
        }

        //Water bubble
        if (other.CompareTag("WaterBullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        //If it hits a boundary
        if (other.CompareTag("Boundary")) { 

        }
    }


}
