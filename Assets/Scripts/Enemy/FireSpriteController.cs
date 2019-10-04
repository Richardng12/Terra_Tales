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
    private int spawnLocation;

    public Transform groundDetection;
    private CharacterController character;
    private SpawnerScript spawner;

    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<SpawnerScript>();
    }

    void Update()

    {
        Move();
    }

    public void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        //origin, direction, length
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
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

    public void LoseHealth()
    {
        if (health > 3)
        {
            health -= 3;
        }
        else
        {
            OnDestroy();
            Destroy(this.gameObject);

        }
    }

    private void OnDestroy()
    {
        spawner.getSpawnedObjects()[spawnLocation] = null;
        spawner.SetCurrentSpawnDelay(0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit player");
        character = other.gameObject.GetComponent<CharacterController>();
        if (character != null)
        {
            character.LoseHealth();
        }
    }
    public void SetLocation(int location)
    {
        this.spawnLocation = location;
    }

    public void Move(float moveInput, float speed)
    {
        throw new NotImplementedException();
    }
}
