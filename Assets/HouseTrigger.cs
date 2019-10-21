using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseTrigger : MonoBehaviour
{
    public LevelLoader levelLoader;

     private void OnTriggerEnter2D(Collider2D Collision)
    {
        // If collision is detected then go back to main menu
        if (Collision.gameObject.tag.Equals("Player"))
        {
            //Loads level selection screen
             levelLoader.LoadLevel(6);
        }
    }
}
