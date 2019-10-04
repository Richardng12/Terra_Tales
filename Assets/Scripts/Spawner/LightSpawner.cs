using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpawner : MonoBehaviour
{
    public Switch[] switches;
    int randomSpawnPoint;
    private readonly int spawnDelay = 10;
    public static float currentSpawnDelay = 10;
    public static FireSpriteController[] spawnedMonsters;
    // Start is called before the first frame update
    void Start()
    {
        switches = (Switch[])Resources.FindObjectsOfTypeAll(typeof(Switch));

        InvokeRepeating("SpawnMonster", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpawnDelay <= spawnDelay)
        {
            currentSpawnDelay = Time.deltaTime + currentSpawnDelay;
        }

    }

    void SpawnMonster()
    {
        randomSpawnPoint = Random.Range(0, switches.Length);

        if (currentSpawnDelay >= spawnDelay)
        {
            switches[randomSpawnPoint].setIsOn( true);
        }

    }
}
