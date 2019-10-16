using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class FireSpriteController : AbstractSpawnableObject, ICharacter
{
    // Start is called before the first frame update
    public float speed;
    public float distance;

    private bool movingRight = true;

    public int health = 9;

    public Transform groundDetection;
    public Transform wallDetection;
    private CharacterController character;
    private SpawnerScript spawner;

    string hitSound = "Hit";
    string monsterDeathSound = "FireMonsterDeath";

    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<SpawnerScript>();
    }

    void Update()

    {
        Move();
    }

    // Moves the fire sprite so that it goes to the edge of a platform and 
    // moves in the other direction after
    public void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        LayerMask mask = LayerMask.GetMask("Ground");
        //origin, direction, length
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, mask);
        RaycastHit2D frontInfo = Physics2D.Raycast(wallDetection.position, Vector2.left, distance, mask);
        RaycastHit2D backInfo = Physics2D.Raycast(wallDetection.position, Vector2.right, distance, mask);
        if (groundInfo.collider == false || frontInfo.collider == true || backInfo.collider == true)
        {
            if (movingRight == true)
            {
                //Move the opposite direction
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                //Set characters rotation values back to original
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
    // Reduces the sprites health and destroys the object is health is 0
    public void LoseHealth()
    {
        if (health > 3)
        {
            AudioManager.instance.Play(hitSound);
            health -= 3;
        }
        else
        {
            AudioManager.instance.Play(monsterDeathSound);
            ForestTracker.fireSpriteDestroyed++;
            Destroy(this.gameObject);
            OnDestroy();
        }
    }
    // Sets the index of the spawner array to be null so that more sprites can
    // be generated from the spawner
    public override void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.getSpawnedObjects()[this.GetLocation()] = null;
            // Sets the delay
            spawner.SetCurrentSpawnDelay(0);
        }
    }
    // If sprite hits the player plays loses health
    void OnTriggerEnter2D(Collider2D other)
    {
      //  Debug.Log("hit player");
        character = other.gameObject.GetComponent<CharacterController>();
        if (character != null)
        {
            character.LoseHealth();
        }

        // //collision with the projectile
        // if (other.CompareTag("WaterBullet"))
        // {
        //     //Destroy projectile
        //     Destroy(other.gameObject);
        //     LoseHealth();
        // }
    }


    public void Move(float moveInput, float speed)
    {
        throw new NotImplementedException();
    }

  
}
