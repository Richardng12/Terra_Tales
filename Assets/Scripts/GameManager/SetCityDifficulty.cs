using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCityDifficulty : MonoBehaviour
{
    public GameObject timerObject;

    public GameObject energyTracker;

    public GameObject lightSpawner;

    public GameObject enemySpawner;

    public GameObject bootSpawner;


    // Start is called before the first frame update
    void Start()
    {
        timerObject.GetComponent<Timer>().time = GlobalGameManager.instance.chosenCityLevelProperties.time;
        energyTracker.GetComponent<EnergyTracker>().max = GlobalGameManager.instance.chosenCityLevelProperties.maxEnergy;
        lightSpawner.GetComponent<LightSpawner>().spawnTime = GlobalGameManager.instance.chosenCityLevelProperties.lightSpawnRate;
        enemySpawner.GetComponent<SpawnerScript>().spawnDelay = GlobalGameManager.instance.chosenCityLevelProperties.spawnRate;
        bootSpawner.GetComponent<SpawnerScript>().spawnDelay = GlobalGameManager.instance.chosenCityLevelProperties.bootSpawnRate;
    }

}
