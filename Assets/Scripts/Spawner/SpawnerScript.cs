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
    AbstractSpawnableObject[] spawnedObject;
    // Start is called before the first frame update
    void Start()
    {
        spawnedObject = new AbstractSpawnableObject[spawnLocations.Length];
        // Adds a few monsters when the scene starts
        for (int i =0; i < 5; i++) {
            SpawnObject();
            }
        InvokeRepeating("SpawnObject",0f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSpawnDelay <= spawnDelay)
        {
            currentSpawnDelay = Time.deltaTime + currentSpawnDelay;
        }
       
    }

    void SpawnObject()
    {
        randomSpawnPoint = Random.Range(0, spawnLocations.Length);
        
        if (spawnedObject[randomSpawnPoint] == null && currentSpawnDelay >= spawnDelay)
        {
            Debug.Log("Spawned");
            int chosenObject = Random.Range(0, objectsToSpawn.Length);
            spawnedObject[randomSpawnPoint] = Instantiate(objectsToSpawn[chosenObject], spawnLocations[randomSpawnPoint].position, Quaternion.identity).GetComponent<AbstractSpawnableObject>();
            spawnedObject[randomSpawnPoint].name = objectsToSpawn[chosenObject].name;
            spawnedObject[randomSpawnPoint].SetLocation(randomSpawnPoint);
        }

    }

    public AbstractSpawnableObject[] getSpawnedObjects()
    {
        return spawnedObject;
    }

    public void SetCurrentSpawnDelay(float delay)
    {
        this.currentSpawnDelay = delay;
    }
}
