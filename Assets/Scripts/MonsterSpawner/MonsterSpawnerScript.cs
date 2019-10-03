using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnerScript : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject monster;
    int randomSpawnPoint;
    private readonly int spawnDelay = 2;
    public static float currentSpawnDelay = 2;
    public static FireSpriteController[] spawnedMonsters;
    // Start is called before the first frame update
    void Start()
    {
        spawnedMonsters = new FireSpriteController[spawnLocations.Length];
        // Adds a fewe monsters when the scene starts
        for (int i =0; i < 5; i++) {
            SpawnMonster();
        }
        InvokeRepeating("SpawnMonster",0f,5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSpawnDelay <= spawnDelay)
        {
            currentSpawnDelay = Time.deltaTime + currentSpawnDelay;
        }
       
    }

    void SpawnMonster()
    {
        randomSpawnPoint = Random.Range(0, spawnLocations.Length);
        
        if (spawnedMonsters[randomSpawnPoint] == null && currentSpawnDelay >= spawnDelay)
        {
            Debug.Log("Spawned");
            spawnedMonsters[randomSpawnPoint] = Instantiate(monster, spawnLocations[randomSpawnPoint].position, Quaternion.identity).GetComponent<FireSpriteController>();
            spawnedMonsters[randomSpawnPoint].SetLocation(randomSpawnPoint);
        }

    }
}
