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
    string monsterDeathSound = "FireMonsterDeath";
    //Variables for boundary collision
    private int travelTime = 0;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //Get reference to player object
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        //Get reference to player position
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        //Get reference to oil sprite
        centrePos = GameObject.FindGameObjectWithTag("Centre").transform;
        //Get reference to spawner objects
        if (GameObject.FindGameObjectWithTag("EnemySpawner") != null) {
            spawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<SpawnerScript>();
        }

        //Get reference to rigidbody object
    }

    void Update()
    {
        //Call the move method to move the oil sprite
        Move();
    }

    //Method to destroy this gameobject
    public void LoseHealth()
    {
        OceanTracker.oilSpriteDestroyed++;
        Debug.Log(OceanTracker.oilSpriteDestroyed);
        OnDestroy();
    }

    //Method to destroy object and update spawn locations
    public override void OnDestroy()
    {
        AudioManager.instance.Play(monsterDeathSound);
        AchievementManager.instance.IncrementAchievement(AchievementType.OilSpills);

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
        if (other.CompareTag("Boundary"))
        {
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
