using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpriteShooting : MonoBehaviour
{
    private CharacterController player;
    
 //Chooses the spawn
    public GameObject shot;
    //Initialize enemy position
    private Transform enemyPos;
    private float lastShot;
    public float timeBetweenShots;

    void Start() {
        enemyPos = GetComponent<Transform>();
    }


    void Update() {
        if(Time.time - lastShot > timeBetweenShots){
            lastShot = Time.time;
            Instantiate(shot, enemyPos.position, Quaternion.identity);
        }
    }

}
