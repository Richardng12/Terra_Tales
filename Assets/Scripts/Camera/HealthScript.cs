using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Sprite[] hearts;
    public Image displayedHearts;
    private CharacterController player;

    // Start is called before the first frame update
    void Start()
    {
        // Finds the object with tag player
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Constantly updates the displayed sprite health
        displayedHearts.sprite = hearts[player.health];
    }
}
