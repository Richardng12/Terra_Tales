using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpriteController : MonoBehaviour
{
    public GameObject rainDrop;
    public Transform cloud;
    public int health = 3;
    public float spawnTime = 0.8f;

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
            spawnRainDrop();
            timer = 0;
        }
        move();
    }

    public void LoseHealth()
    {
        health--;
        if (health <= 0) {
            Destroy(gameObject);
        } 
    }

    public void spawnRainDrop() {
        Vector2 pos = new Vector2(cloud.position.x, cloud.position.y - 0.5f);
        Instantiate(rainDrop, pos, Quaternion.identity);
    }

    public void move() {
        cloud.transform.position = new Vector2(cloud.position.x - 0.05f, cloud.position.y);
    }
}
