﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Seedling : MonoBehaviour
{

    public Slider progressBar;
    public bool complete;
    public bool interactable = false;
    public float currentProgress;
    public float maxProgress = 5;

    public GameObject pivot;

    public GameObject treeCounterObject;

    private ForestTracker treeCounter;

    public GameObject player;

    private ShootWater shootWater;
    // Start is called before the first frame update
    void Start()
    {
        currentProgress = 0;
        complete = false;
        progressBar.value = CalculateProgress();
        progressBar.gameObject.SetActive(false);
        pivot.transform.localScale = new Vector3(1, 1, 0);
        treeCounterObject = GameObject.Find("TreeCounter");
        treeCounter = treeCounterObject.GetComponent<ForestTracker>();
        shootWater = player.GetComponent<ShootWater>();
    }

    // Update is called once per frame
    void Update()
    {
        // complete progress bar
        if (Input.GetKey("e") && interactable && currentProgress > 5)
        {
            interactable = false;
            complete = true;
            progressBar.gameObject.SetActive(false);
            shootWater.DecreaseAmmoCount();
            treeCounter.UpdateAndDisplayTaskCounter();
        }
        if (Input.GetKey("e") && interactable && !player.GetComponent<ShootWater>().isEmpty())
        {
            player = GameObject.Find("Player");

            player.GetComponent<ShootWater>().waterTree();
            float time = Time.deltaTime;
            currentProgress += time;
            progressBar.value = CalculateProgress();
            pivot.transform.localScale += new Vector3(time, time, 0);
        }
        // if (Input.GetKeyUp("e") && currentProgress < maxProgress)
        // {
        //     currentProgress = 0;
        //     progressBar.value = CalculateProgress();
        //     pivot.transform.localScale = new Vector3(1, 1, 0);
        // }

    }

    private float CalculateProgress()
    {
        return currentProgress / maxProgress;
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("Player") && complete == false)
        {
            interactable = true;
            progressBar.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("Player") && complete == false)
        {
            interactable = false;
            // currentProgress = 0;
            progressBar.gameObject.SetActive(false);
            // if (complete != true)
            //     pivot.transform.localScale = new Vector3(1, 1, 0);
        }
    }
}
