﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoHUD : MonoBehaviour
{
    public Canvas display; // Assign in inspector
    GameObject player;
    public Text ammoCount;

    void Start()
    {
        player = GameObject.Find("Player");
        display.enabled = player.GetComponent<ShootWater>().hasWep;
}
    // Update is called once per frame
    void Update()
    {

       ammoCount.text = CreateAmmoText(player.GetComponent<ShootWater>().GetAmmoCount());
       display.enabled = player.GetComponent<ShootWater>().hasWep; 
    }

    private string CreateAmmoText(int ammo)
    {
        return ": " + ammo + "/9";
    }
}
