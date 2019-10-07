using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSpriteController : AbstractSpawnableObject, ICharacter
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
    SpawnerScript spawner;

    //Variables for boundary collision
    private int travelTime = 0;

    void Start()
    {
        //Get reference to player object
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        //Get reference to player position
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        //Get reference to oil sprite
        centrePos = GameObject.FindGameObjectWithTag("Centre").transform;
        //Get reference to spawner objects
        spawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<SpawnerScript>();
        //Get reference to rigidbody object
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Call the move method to move the oil sprite
        Move();
    }

    //Method to destroy this gameobject
    public void LoseHealth()
    {
        OnDestroy();
    }

    //Method to destroy object and update spawn locations
    public override void OnDestroy()
    {
        spawner.getSpawnedObjects()[this.GetLocation()] = null;
        spawner.SetCurrentSpawnDelay(0);
        Destroy(this.gameObject);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Collision with player
        if (other.CompareTag("Player"))
        {
            //Cause player to lose health
            player.LoseHealth();
            OnDestroy();
        }

        //If it hits a boundary
        if (other.CompareTag("Boundary")) {
            //Move oil sprite towards the map centre if it collides map boundary
            travelTime = 500;
            pos = new Vector2(centrePos.position.x, centrePos.position.y);
            oppMove = rb.position - pos;
            moveInput = pos - rb.position;
            moveVelocity = moveInput.normalized * speed;
        }
    }
    
    //Method to move oil sprite
    public void Move()
    {
        //Check if the oil sprite should move toward
        if (travelTime > 0)
        {
            travelTime--;
        }
        else
        {
            pos = new Vector2(playerPos.position.x, playerPos.position.y);
            oppMove = rb.position - pos;
            moveInput = pos - rb.position;
            moveVelocity = moveInput.normalized * speed;
        }

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    public void Move(float moveInput, float speed)
    {
        throw new System.NotImplementedException();
    }
}
