﻿using UnityEngine;
using System.Collections;

public class ShootWater : MonoBehaviour
{

    public Transform direction;
    public GameObject waterBubblePrefab;
    public bool hasWep = false;
    public float rateOfFire;
    float timeToFire = 0;
    private readonly float reloadDelay = 0.5f;
    private float currrentReloadDelay = 0.5f;
    public int ammo = 9;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            this.CheckFireRate();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Water Gun"))
        {
            hasWep = true;
        }
    }
    private void Shoot()
    {
        if (ammo > 0 && ammo != 99)
        {
            Instantiate(waterBubblePrefab, direction.position, direction.rotation);
            DecreaseAmmoCount();
        }
        else
        {
            Instantiate(waterBubblePrefab, direction.position, direction.rotation);

        }
    }
    // Shoots water gun  by instantianting a waterBubble object
    // dependent on couple of variables
    public void CheckFireRate()
    {
        if (hasWep)
        {
            if (rateOfFire == 0)
            {
                Shoot();
            }
            else
            {
                if (Time.time > timeToFire)
                {
                    timeToFire = Time.time + 1 / rateOfFire;
                    Shoot();
                }
            }
        }
    }

    // Checks if the ammo is less than 9 and slowly reloads the water gun with
    // a set delay
    public void ReloadWaterGun()
    {
        if (ammo < 9)
        {
            if (currrentReloadDelay >= reloadDelay)
            {
                IncreaseAmmoCount();
                currrentReloadDelay = 0;
            }
            else
            {
                currrentReloadDelay = currrentReloadDelay + Time.deltaTime;
            }
        }
    }
    public int GetAmmoCount()
    {
        return ammo;
    }

    public void DecreaseAmmoCount()
    {
        ammo--;
    }

    public void IncreaseAmmoCount()
    {
        ammo++;
    }

}