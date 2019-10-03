using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleScript : MonoBehaviour
{
    private bool inPuddle = false;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inPuddle)
        {
            player = GameObject.Find("Player");

            player.GetComponent<ShootWater>().ReloadWaterGun();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            inPuddle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            inPuddle = false;
        }
    }
}
