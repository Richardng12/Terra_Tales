using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaplingHUD : MonoBehaviour
{
    public ForestTracker tracker;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = tracker.GetTasks()[0] + "/" + tracker.treesToPlant;
    }
}
