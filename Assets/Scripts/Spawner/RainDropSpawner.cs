using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDropSpawner : MonoBehaviour
{
    public GameObject rainDrop;

    public float spawnTime = 2f;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime) {
            SpawnRandom();
            timer = 0;
        }
    }

    public void SpawnRandom() {
        Vector2 spawnPosition = Camera.main.ScreenToWorldPoint (new Vector2(Random.Range(0, Screen.width), Random.Range(600, Screen.height)));

        Instantiate(rainDrop, spawnPosition, Quaternion.identity);
    }
}
