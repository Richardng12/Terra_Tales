using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class TrashScript : AbstractSpawnableObject
{
    private SpawnerScript spawner;
    private GrabObject player;
    public bool isThrowable = true;
    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("ItemSpawner").GetComponent<SpawnerScript>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<GrabObject>();

    }

    // Destroys the rubbish and resets the array in the spawner so that more
    // Rubbish can be spawned in the particular spawn locations
    public override void OnDestroy()
    {
        spawner.getSpawnedObjects()[this.GetLocation()] = null;
        spawner.SetCurrentSpawnDelay(0);
        player.SetRubbishItem(null);
        player.SetGrabbedRubbishItem(null);
        Destroy(this.gameObject);

    }

    // If in range of rubbish sets interactable to true
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            player.SetRubbishItem(this.gameObject);
            player.SetInteractable(true);

        }
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isThrowable = false;
        }
    }
    // Sets interactable to false if leaves range of rubbish
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            player.SetRubbishItem(null);
            player.SetInteractable(false);

        }
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isThrowable = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            player.SetRubbishItem(this.gameObject);
            player.SetInteractable(true);

        }

    }


}
