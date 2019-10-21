using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyTracker : MonoBehaviour
{
    public float max;
    private float current = 0;

    [SerializeField] private Bar bar;

    // Start is called before the first frame update
    void Start()
    {
        bar.setBar("eBar");
    }

    // Update is called once per frame
    void Update()
    {
        if(current >= max) {
            Debug.Log("u lose");
        }
        Debug.Log(current);
        bar.setSize((current / max));
    }

    public void increaseEnergy() {
        current++;
    }

    public void decreaseEnergy() {
        current--;
    }
}
