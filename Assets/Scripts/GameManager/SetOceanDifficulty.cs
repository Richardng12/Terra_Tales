using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOceanDifficulty : MonoBehaviour
{
    public GameObject spawnerObject;

    public GameObject timerObject;

    public GameObject oceanTracker;

    // sets the properties of ocean based on chosen difficulty level
    void Start()
    {
        spawnerObject.GetComponent<SpawnerScript>().spawnDelay = GlobalGameManager.instance.chosenOceanLevelProperties.spawnRate;
        timerObject.GetComponent<Timer>().time = GlobalGameManager.instance.chosenOceanLevelProperties.time;
        oceanTracker.GetComponent<OceanTracker>().rubbishToCollect = GlobalGameManager.instance.chosenOceanLevelProperties.rubbishToCollect;
    }

}
