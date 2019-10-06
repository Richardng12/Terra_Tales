using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner: MonoBehaviour
{
    public Window[] windows;
    int randomSpawnPoint;
    private readonly int spawnDelay = 10;
    public static float currentSpawnDelay = 10;
    public static FireSpriteController[] spawnedMonsters;
    // Start is called before the first frame update
    void Start()
    {
        windows = (Window[]) Resources.FindObjectsOfTypeAll(typeof(Window));
        
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
        randomSpawnPoint = Random.Range(0, windows.Length);

        if ( currentSpawnDelay >= spawnDelay)
        {
            windows[randomSpawnPoint].hasPerson = true;
        }

    }
}
