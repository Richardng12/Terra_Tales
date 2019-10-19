using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberBootsSpawner : MonoBehaviour
{
    public GameObject rubberBoots;

    public float spawnTime = 3f;

    private float timer = 0;

    public Transform[] spawnLocations;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime) {
            // do not spawn any more rubber boots if there are too many in the game
            if (countExistingBoots() < 3) {
                SpawnRandom();
                timer = 0;
            } else {
                Debug.Log("too many boots");
            }
        }
    }

    private int countExistingBoots() {
        GameObject[] boots = GameObject.FindGameObjectsWithTag("RubberBoots");
        return boots.Length;
    }

    private void SpawnRandom() {
        Vector2 spawnPosition = Camera.main.ScreenToWorldPoint (new Vector2(x, y));

        Instantiate(rubberBoots, spawnPosition, Quaternion.identity);
        Debug.Log("boots!!!!!!!");
    }
}
