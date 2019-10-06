using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class TrashScript : AbstractSpawnableObject
{
    private SpawnerScript spawner;

    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("ItemSpawner").GetComponent<SpawnerScript>();
    }

    public override void OnDestroy()
    {
        Debug.Log("Destroy: " + this.GetLocation());
        spawner.getSpawnedObjects()[this.GetLocation()] = null;
        spawner.SetCurrentSpawnDelay(0);
        Destroy(this.gameObject);

    }

}
