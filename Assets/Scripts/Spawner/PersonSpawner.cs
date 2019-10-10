using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner : MonoBehaviour
{
    public Window[] windows;
    int randonIndex;
    private readonly int spawnDelay = 10;
    public static float currentSpawnDelay = 10;
    public static FireSpriteController[] spawnedMonsters;
    // Start is called before the first frame update
    void Start()
    {
        windows = (Window[])Resources.FindObjectsOfTypeAll(typeof(Window));
        for(int i = 0; i < 10; i++){
        Debug.Log("On index " + i);

        }
        InvokeRepeating("SpawnMonster", 0f, 2f);
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
        randonIndex = Random.Range(0, windows.Length);

        windows[randonIndex].hasPerson = true;
        StartCoroutine(delayedOff(randonIndex));


    }

    IEnumerator delayedOff(int index)
    {
        yield return new WaitForSeconds(10);
        windows[index].hasPerson = false;
    }
}
