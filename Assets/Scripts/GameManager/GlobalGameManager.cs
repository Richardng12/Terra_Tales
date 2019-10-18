using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour
{

    public static GlobalGameManager instance;
    public bool firstPlay = true;
    private ForestLevelProperties[] forestProperties;
    public ForestLevelProperties chosenForestLevel;


    public IEnumerator delayedSet(bool b)
    {
        yield return new WaitForSeconds(3);
        firstPlay = b;
    }
    private void OnEnable()
    {
        Publisher.StartListening("ForestLevelEasy", SetForestLevelEasy);
        Publisher.StartListening("ForestLevelMedium", SetForestLevelMedium);
        Publisher.StartListening("ForestLevelHard", SetForestLevelHard);
    }

    private void OnDisable()
    {
        Publisher.StopListening("ForestLevelEasy", SetForestLevelEasy);
        Publisher.StopListening("ForestLevelMedium", SetForestLevelMedium);
        Publisher.StopListening("ForestLevelHard", SetForestLevelHard);
    }

    private void SetForestLevelEasy()
    {
        SetForestProperties(0);
    }

    private void SetForestLevelMedium()
    {
        SetForestProperties(1);
    }

    private void SetForestLevelHard()
    {
        SetForestProperties(2);
    }

    private void SetForestProperties(int i)
    {
         chosenForestLevel = forestProperties[i];
    }

    private void Start()
    {
        InitLevels();
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
            new ForestLevelProperties(300, 4, 6),
            new ForestLevelProperties(240, 2, 8)
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

    public ForestLevelProperties(int levelTime, int levelSpawnRate, int levelTreesToPlant)
    {
        time = levelTime;
        spawnRate = levelSpawnRate;
        treesToPlant = levelTreesToPlant;
    }
}