using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpriteShooting : MonoBehaviour
{
 
    //Gameobject to projectile
    public GameObject shot;
    //Variable for fire spriteposition
    private Transform enemyPos;

    //Variables to contorl shooting speed
    private float lastShot;
    public float timeBetweenShots;

    void Start() {
        //Get fire sprite position
        enemyPos = GetComponent<Transform>();
    }


    void Update() {
        //Fire projectile if interval is met
        if(Time.time - lastShot > timeBetweenShots){
            lastShot = Time.time;
            Instantiate(shot, enemyPos.position, Quaternion.identity);
        }
    }

}
