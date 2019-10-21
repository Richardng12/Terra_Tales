using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject[] objectsToSpawn;
    int randomSpawnPoint;
    public int spawnDelay = 2;
    float currentSpawnDelay = 2;
    public float spawnRate;
    AbstractSpawnableObject[] spawnedObject;
    // Start is called before the first frame update
    void Start()
    {
        spawnedObject = new AbstractSpawnableObject[spawnLocations.Length];
        // Adds a few entities when the scene starts
        for (int i =0; i < 5; i++) {
            SpawnObject();
            }
        // Keeps calling the SpawnObject method at a rate
        InvokeRepeating("SpawnObject",0f,spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        // Updates the delay for the spawns
        if(currentSpawnDelay <= spawnDelay)
        {
            currentSpawnDelay = Time.deltaTime + currentSpawnDelay;
        }
       
    }

    // This spawns a random object using RNG in a particular location that does not
    // have a object associated with it
    void SpawnObject()
    {
        // Chooses a random spawn point to spawn the object
        randomSpawnPoint = Random.Range(0, spawnLocations.Length);
        // If that position is not occupied and the delay is met
        if (spawnedObject[randomSpawnPoint] == null && currentSpawnDelay >= spawnDelay)
        {
            // Chooses a random object to spawn from the object array listed
            int chosenObject = Random.Range(0, objectsToSpawn.Length);
            // Spawns the random object in the random location
            spawnedObject[randomSpawnPoint] = 
            Instantiate(objectsToSpawn[chosenObject],
                 spawnLocations[randomSpawnPoint].position,
             Quaternion.identity).GetComponent<AbstractSpawnableObject>();
            // Sets the name so that it doesnt appear to be
            // "entity 1" "entity 2" etc..
            if (spawnedObject[randomSpawnPoint] != null && objectsToSpawn[chosenObject])
            {
                spawnedObject[randomSpawnPoint].name = objectsToSpawn[chosenObject].name;
                // Sets the location of the spawned object to the rng spawn point
                spawnedObject[randomSpawnPoint]
                .GetComponent<AbstractSpawnableObject>()
                    .SetLocation(randomSpawnPoint);
            }
        }

    }

    // Gets list of spawned objects
    public AbstractSpawnableObject[] getSpawnedObjects()
    {
        return spawnedObject;
    }

    // Sets the current delay for the object
    public void SetCurrentSpawnDelay(float delay)
    {
        this.currentSpawnDelay = delay;
    }
}
