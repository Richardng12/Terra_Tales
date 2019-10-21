using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour
{

    public static GlobalGameManager instance;
    
    public bool firstPlay = true;
    public bool forestUnlocked= false;
    public bool oceanUnlocked = false;

    public string difficulty;

    private ForestLevelProperties[] forestProperties;
    public ForestLevelProperties chosenForestProperties;
    private OceanLevelProperties[] oceanProperties;
    public OceanLevelProperties chosenOceanLevelProperties;
    public Dictionary<string, int> highScoreDict = new Dictionary<string, int>();

    public void delayedSet(bool b)
    {
        firstPlay = b;
    }

    // listens for difficulty events and level finish events
    private void OnEnable()
    {
        InitLevels();
        Publisher.StartListening("ForestLevelEasy", SetForestLevelEasy);
        Publisher.StartListening("ForestLevelMedium", SetForestLevelMedium);
        Publisher.StartListening("ForestLevelHard", SetForestLevelHard);
        Publisher.StartListening("OceanLevelEasy", SetOceanLevelEasy);
        Publisher.StartListening("OceanLevelMedium", SetOceanLevelMedium);
        Publisher.StartListening("OceanLevelHard", SetOceanLevelHard);
        Publisher.StartListening("FinishCity", UnlockForest);
        Publisher.StartListening("FinishForest", UnlockOcean);
    }

    // unmounts all listeners when disabled
    private void OnDisable()
    {
        Publisher.StopListening("ForestLevelEasy", SetForestLevelEasy);
        Publisher.StopListening("ForestLevelMedium", SetForestLevelMedium);
        Publisher.StopListening("ForestLevelHard", SetForestLevelHard);
        Publisher.StopListening("OceanLevelEasy", SetOceanLevelEasy);
        Publisher.StopListening("OceanLevelMedium", SetOceanLevelMedium);
        Publisher.StopListening("OceanLevelHard", SetOceanLevelHard);
        Publisher.StopListening("FinishCity", UnlockForest);
        Publisher.StopListening("FinishForest", UnlockOcean);
    }

    private void SetForestLevelEasy()
    {
        difficulty = "Easy";
        SetForestProperties(0);
        SetMultiplierEasy();
    }

    private void SetForestLevelMedium()
    {
        difficulty = "Medium";
        SetForestProperties(1);
        SetMultiplierMedium();
    }

    private void SetForestLevelHard()
    {
        difficulty = "Hard";
        SetForestProperties(2);
        SetMultiplierHard();
    }

    // sets difficulty for level based on the chosen properties
    private void SetForestProperties(int i)
    {
        chosenForestProperties = forestProperties[i];
    }

    private void SetOceanLevelEasy()
    {
        difficulty = "Easy";
        SetOceanProperties(0);
        SetMultiplierEasy();
    }

    private void SetOceanLevelMedium()
    {
        difficulty = "Medium";
        SetOceanProperties(1);
        SetMultiplierMedium();
    }

    private void SetOceanLevelHard()
    {
        difficulty = "Hard";
        SetOceanProperties(2);
        SetMultiplierHard();
    }

    private void SetOceanProperties(int i)
    {
        chosenOceanLevelProperties = oceanProperties[i];
    }

    private void UnlockOcean()
    {
        oceanUnlocked = true;
    }

    private void UnlockForest()
    {
        forestUnlocked = true;
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
            DontDestroyOnLoad(this);
            instance = this;
            StartCoroutine(startUp());
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private IEnumerator startUp()
    {
        yield return new WaitForSeconds(0);
        SaveValues.getInstance().LoadGame();
        //Get the path of the Game data folder
        string m_Path = Application.dataPath;
        AchievementManager.instance.IncrementAchievement(AchievementType.Plays);

        //Output the Game data path to the console
        StartCoroutine(continuousSave());
        // Dont destroy this object when a new scene is loaded
    }

    private IEnumerator continuousSave()
    {
        yield return new WaitForSeconds(10);
        SaveValues.getInstance().SaveGame();
        continuousSave();
    }

    // initialises all the difficulty prperties for levels
    private void InitLevels()
    {
        forestUnlocked = false;
        oceanUnlocked = false;

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

// model class representing properties of each level
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