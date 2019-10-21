using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetForestDifficulty : MonoBehaviour
{
    public GameObject spawnerObject;

    public GameObject timerObject;

    public GameObject treeTracker;

    // sets the properties of forest based on chosen difficulty level
    void Start()
    {
        spawnerObject.GetComponent<SpawnerScript>().spawnDelay = GlobalGameManager.instance.chosenForestProperties.spawnRate;
        timerObject.GetComponent<Timer>().time = GlobalGameManager.instance.chosenForestProperties.time;
        treeTracker.GetComponent<ForestTracker>().treesToPlant = GlobalGameManager.instance.chosenForestProperties.treesToPlant;
    }
}
