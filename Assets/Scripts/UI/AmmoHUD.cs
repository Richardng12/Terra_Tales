using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoHUD : MonoBehaviour
{
    public Canvas display; // Assign in inspector
    GameObject player;
    public Text ammoCount;
    public string amountOfAmmo;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
}
    // Update is called once per frame
    void Update()
    {
        // Creates the ammo text by accessing player and checking how much ammo
       ammoCount.text = CreateAmmoText(player.GetComponent<ShootWater>().GetAmmoCount());
    }

    // Constructs the string to be shown
    private string CreateAmmoText(int ammo)
    {
        if(ammo == 99)
        {
            return ": " + "∞" + amountOfAmmo; 
        }
        return ": " + ammo + amountOfAmmo;
    }
}
