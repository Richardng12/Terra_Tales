﻿using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class TrashScript : AbstractSpawnableObject
{
    private SpawnerScript spawner;
    private int spawnLocation;

    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("ItemSpawner").GetComponent<SpawnerScript>();
    }

    public void SetLocation(int location) {

        spawnLocation = location;
    }

    public void OnDestroy()
    {
        spawner.getSpawnedObjects()[spawnLocation] = null;
        spawner.SetCurrentSpawnDelay(0);
    }
}