using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOceanDifficulty : MonoBehaviour
{
    public GameObject spawnerObject;

    public GameObject timerObject;

    public GameObject oceanTracker;
    // Start is called before the first frame update
    void Start()
    {
        spawnerObject.GetComponent<SpawnerScript>().spawnDelay = GlobalGameManager.instance.chosenOceanLevelProperties.spawnRate;
        timerObject.GetComponent<Timer>().time = GlobalGameManager.instance.chosenOceanLevelProperties.time;
        oceanTracker.GetComponent<OceanTracker>().rubbishToCollect = GlobalGameManager.instance.chosenOceanLevelProperties.rubbishToCollect;
    }

}
