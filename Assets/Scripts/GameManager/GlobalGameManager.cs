using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour
{

    public static GlobalGameManager instance;
    public bool firstPlay = true;
    private ForestLevelProperties[] forestProperties;
    public ForestLevelProperties chosenForestProperties;
    private OceanLevelProperties[] oceanProperties;
    public OceanLevelProperties chosenOceanLevelProperties;


    public IEnumerator delayedSet(bool b)
    {
        yield return new WaitForSeconds(3);
        firstPlay = b;
    }
    private void OnEnable()
    {
        InitLevels();
        Publisher.StartListening("ForestLevelEasy", SetForestLevelEasy);
        Publisher.StartListening("ForestLevelMedium", SetForestLevelMedium);
        Publisher.StartListening("ForestLevelHard", SetForestLevelHard);
        Publisher.StartListening("OceanLevelEasy", SetOceanLevelEasy);
        Publisher.StartListening("OceanLevelMedium", SetOceanLevelMedium);
        Publisher.StartListening("OceanLevelHard", SetOceanLevelHard);
    }

    private void OnDisable()
    {
        Publisher.StopListening("ForestLevelEasy", SetForestLevelEasy);
        Publisher.StopListening("ForestLevelMedium", SetForestLevelMedium);
        Publisher.StopListening("ForestLevelHard", SetForestLevelHard);
        Publisher.StopListening("OceanLevelEasy", SetOceanLevelEasy);
        Publisher.StopListening("OceanLevelMedium", SetOceanLevelMedium);
        Publisher.StopListening("OceanLevelHard", SetOceanLevelHard);
    }

    private void SetForestLevelEasy()
    {
        SetForestProperties(0);
        SetMultiplierEasy();
    }

    private void SetForestLevelMedium()
    {
        SetForestProperties(1);
        SetMultiplierMedium();   
    }

    private void SetForestLevelHard()
    {
        SetForestProperties(2);
        SetMultiplierHard();
    }

    private void SetForestProperties(int i)
    {
        chosenForestProperties = forestProperties[i];
    }

    private void SetOceanLevelEasy()
    {
        SetOceanProperties(0);
        SetMultiplierEasy();
    }

    private void SetOceanLevelMedium()
    {
        SetOceanProperties(1);
        SetMultiplierMedium();
    }

    private void SetOceanLevelHard()
    {
        SetOceanProperties(2);
        SetMultiplierHard();
    }

    private void SetOceanProperties(int i)
    {
        chosenOceanLevelProperties = oceanProperties[i];
    }

    private void SetMultiplierEasy()
    {
        Scoring.multiplier = 1.0;
    }

    private void SetMultiplierMedium()
    {
        Scoring.multiplier = 1.5;
    }

    private void SetMultiplierHard()
    {
        Scoring.multiplier = 2.0;
    }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // Dont destroy this object when a new scene is loaded
            DontDestroyOnLoad(this);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void InitLevels()
    {
        forestProperties = new ForestLevelProperties[3]
        {
            new ForestLevelProperties(360, 6, 4),
            new ForestLevelProperties(300, 5, 6),
            new ForestLevelProperties(240, 4, 8)
        };

        oceanProperties = new OceanLevelProperties[3]
        {
            new OceanLevelProperties(360, 6, 3),
            new OceanLevelProperties(300, 5, 4),
            new OceanLevelProperties(240, 4, 5)
        };
    }
}

public abstract class LevelProperties
{
    public int time;
    public int spawnRate;
}

public class ForestLevelProperties : LevelProperties
{
    public int treesToPlant;
    
    public ForestLevelProperties(int time, int spawnRate, int treesToPlant)
    {
        this.time = time;
        this.spawnRate = spawnRate;
        this.treesToPlant = treesToPlant;
    }
}

public class OceanLevelProperties : LevelProperties
{
    public int rubbishToCollect;

    public OceanLevelProperties(int time, int spawnRate, int rubbishToCollect)
    {
        this.time = time;
        this.spawnRate = spawnRate;
        this.rubbishToCollect = rubbishToCollect;
    }
}