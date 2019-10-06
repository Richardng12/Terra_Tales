﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleScript : MonoBehaviour
{
    private bool inPuddle = false;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(regen());
    }


    IEnumerator regen()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            if (gameObject.transform.localScale.x < 4)
            {
                gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (inPuddle)
        {
            player = GameObject.Find("Player");
            float time = Time.deltaTime;
            if (gameObject.transform.localScale.x > 0 && !player.GetComponent<ShootWater>().isFull())
            {
                gameObject.transform.localScale -= new Vector3(time, time, 0);
                player.GetComponent<ShootWater>().ReloadWaterGun();

            }
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
