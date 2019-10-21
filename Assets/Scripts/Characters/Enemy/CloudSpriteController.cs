using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpriteController : AbstractSpawnableObject, ICharacter
{
    
    public GameObject rainDrop;
    public Transform cloud;
    public int health = 1;
    public float spawnTime = 0.8f;

    //Speed of cloud
    public float direction = 0.05f;
    private float timer = 0;

    //Refernce
    SpawnerScript spawner;

    //Initialise object body
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        //Get reference to spawner objects
        if (GameObject.FindGameObjectWithTag("EnemySpawner") != null) {
            spawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<SpawnerScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > Random.Range(0.3f, 20f)) {
            spawnRainDrop();
            timer = 0;
        }
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
        AchievementManager.instance.IncrementAchievement(AchievementType.Deaths);        
        spawner.getSpawnedObjects()[this.GetLocation()] = null;
        spawner.SetCurrentSpawnDelay(0);
        Publisher.TriggerEvent("UpdateCityScore");
        Publisher.TriggerEvent("CloudDestroyed");

        Destroy(this.gameObject);
    }

    public void spawnRainDrop() {
        Vector2 pos = new Vector2(cloud.position.x, cloud.position.y - 0.5f);
        Instantiate(rainDrop, pos, Quaternion.identity);
    }

    public void Move() {
        
        cloud.transform.position = new Vector2(cloud.position.x + direction, cloud.position.y);
    }

    public void Move(float moveInput, float speed)
    {
        throw new System.NotImplementedException();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        CharacterController character = other.gameObject.GetComponent<CharacterController>();
        if (character != null) {
            character.LoseHealth();
        }
        if (other.CompareTag("Boundary"))
        {
            //Move cloud in other direction if a boundary is hit
            direction = direction * -1;
        }


    }

}
