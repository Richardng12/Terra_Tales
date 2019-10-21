using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDifficulty : MonoBehaviour
{
    public void SetForestEasy()
    {
        Publisher.TriggerEvent("ForestLevelEasy");
    }

    public void SetForestMedium()
    {
        Publisher.TriggerEvent("ForestLevelMedium");
        Debug.Log("HELLO");

    }

    public void SetForestHard()
    {
        Publisher.TriggerEvent("ForestLevelHard");
    }

    public void SetOceanEasy()
    {
        Publisher.TriggerEvent("OceanLevelEasy");
    }

    public void SetOceanMedium()
    {
        Publisher.TriggerEvent("OceanLevelMedium");
    }

    public void SetOceanHard()
    {
        Publisher.TriggerEvent("OceanLevelHard");
    }
}
