using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoseCity : MonoBehaviour
{
    public GameObject player;

    public GameObject timer;

    public GameObject loseScreen;

    public GameObject energyTracker;

    bool lose = false;
    // Start is called before the first frame update, get the player component
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //If the players health reaches 0, or the timer reaches 0, display the lose screen
        if (!lose)
        {
            if (player.GetComponent<CharacterController>().health == 0)
            {
                // timer.GetComponent<Timer>().text.text = "Time Left: 0:00";
                loseScreen.SetActive(true);
                Time.timeScale = 0f;
                lose = true;
            }
            else if (energyTracker.GetComponent<EnergyTracker>().getCurrent() >= energyTracker.GetComponent<EnergyTracker>().max)
            {
                loseScreen.SetActive(true);
                Time.timeScale = 0f;
                lose = true;

            }
        }
    }
}