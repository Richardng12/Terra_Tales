using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseTrigger : MonoBehaviour
{
    public LevelLoader levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter2D(Collider2D Collision)
    {
        // If collision is detected then go back to main menu
        if (Collision.gameObject.tag.Equals("Player"))
        {

             levelLoader.LoadLevel(2);
        }
    }
}
