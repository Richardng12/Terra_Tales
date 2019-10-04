using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //Chooses what to spawn
    public GameObject[] enemies;
    //Create an array holding all spots that the enemies can spawn from
    public Transform[] spawnSpots;
    //Value that holds the time between each spawn so enemies don't spawn all at once
    private float timeBetweenSpawns;
    //Gives the value of time between spawns
    public float startTimeBetweenSpawns;


    void Start()
    {
        //Holds the value set for the time between spawns
        timeBetweenSpawns = startTimeBetweenSpawns;
    }

    void Update()
    {
        //If time between spawns is less than or equal to 0, spawn something
        if (timeBetweenSpawns <= 0)
        {
            //Choose random spawn point
            int randPos = Random.Range(0, spawnSpots.Length);
            int randEnemy = Random.Range(0, enemies.Length);
            //Create the enemy
            Instantiate(enemies[randEnemy], spawnSpots[randPos].position, Quaternion.identity);
            //Reset time
            timeBetweenSpawns = startTimeBetweenSpawns;
            //else wait for time to start spawning again
        }
        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }
    }
}