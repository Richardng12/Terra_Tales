using UnityEngine;
using System.Collections;
using System;

public class ShootWater : MonoBehaviour
{

    public Transform direction;
    public GameObject waterBubblePrefab;
    public bool hasWep = true;
    public float rateOfFire;
    float timeToFire = 0;
    private readonly float reloadDelay = 0.5f;
    private float currrentReloadDelay = 0.5f;
    public int ammo = 9;

    AudioManager audioManager;
    string shootSound = "Shoot";
    string reloadSound = "WaterReload";
    string noAmmoSound = "NoAmmo";


    private void Start()
    {
        audioManager = AudioManager.instance;
    }
    // Update is called once per frame
    void Update()
    {
        // If player inputs the fire button it calls CheckFireRate()
        if (Input.GetButton("Fire1"))
        {
            this.CheckFireRate();
        }
    }

    internal bool isFull()
    {
        return ammo == 9;
    }
    internal bool isEmpty()
    {
        return ammo == 0;
    }

    // Shoot method that instantiates a waterbubbleprefab if there is sufficient
    // amounf of 
    private void Shoot()
    {
        if (ammo == 99) {
            Instantiate(waterBubblePrefab, direction.position, direction.rotation);
            audioManager.Play(shootSound);
        }
        else if (ammo > 0 && ammo != 99)
        {
            Instantiate(waterBubblePrefab, direction.position, direction.rotation);
            DecreaseAmmoCount();
            audioManager.Play(shootSound);
        }
        else
        {
            audioManager.Play(noAmmoSound);
        }

    }
    // Shoots water gun  by instantianting a waterBubble object
    // dependent on couple of variables
    public void waterTree()
    {
           if (rateOfFire == 0)
            {
                DecreaseAmmoCount();
            }
            else
            {
                if (Time.time > timeToFire)
                {
                    timeToFire = Time.time + 2 / rateOfFire;
                    DecreaseAmmoCount();
                }
            }
        }
        // Shoots water gun  by instantianting a waterBubble object
        // dependent on couple of variables
        public void CheckFireRate()
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
            audioManager.Play(reloadSound);
            ammo++;
        }
    }