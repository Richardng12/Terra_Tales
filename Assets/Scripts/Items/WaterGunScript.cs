using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player")){
            //TODO Play sound
            Destroy(gameObject);
        }
    }
}
