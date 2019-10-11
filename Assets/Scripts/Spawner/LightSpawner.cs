﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpawner : MonoBehaviour
{
    public Switch[] switches;
    int randomInt;
    // Start is called before the first frame update
    void Start()
    {
        switches = (Switch[])FindObjectsOfType(typeof(Switch));
        StartCoroutine(delayedLoad());
        for (int i = 0; i < 10; i++)
        {
            Debug.Log("At light index " + i);
            //    yield return new WaitForSeconds(.1f);
            TurnOnLight();
        }
        InvokeRepeating("TurnOnLight", 0f, 3);
    }

    // Add in delay to nesure all lights can be found and switched on
    IEnumerator delayedLoad()
    {
        //  yield return new WaitForSeconds(.1f);


        yield return new WaitForSeconds(.1f);

    }

    // Update is called once per frame


    void TurnOnLight()
    {
        randomInt = Random.Range(0, switches.Length  );
        switches[randomInt].setIsOn(true);
    }
}
