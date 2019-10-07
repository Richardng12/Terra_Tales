using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLose : MonoBehaviour
{

    public GameObject player;

    public GameObject timer;

    public GameObject loseScreen;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<CharacterController>().health == 0 || timer.GetComponent<Timer>().time == 0)
        {
            timer.GetComponent<Timer>().text.text = "Time Left: 0:00";
            loseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
