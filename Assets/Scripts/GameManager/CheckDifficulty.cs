using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// publishes events based on button onclicks and sets the difficulty 
public class CheckDifficulty : MonoBehaviour
{
    public void SetForestEasy()
    {
        Publisher.TriggerEvent("ForestLevelEasy");
    }

    public void SetForestMedium()
    {
        Publisher.TriggerEvent("ForestLevelMedium");
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

    public void SetCityEasy()
    {
        Publisher.TriggerEvent("CityLevelEasy");
    }

    public void SetCityMedium()
    {
        Publisher.TriggerEvent("CityLevelMedium");
    }

    public void SetCityHard()
    {
        Publisher.TriggerEvent("CityLevelHard");
    }
}
