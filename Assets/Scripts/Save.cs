using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using System;

/**
    Class to deal with save and loading into files
 */
public class Save : MonoBehaviour
{
    //Save game to a file
    public void SaveGame()
    {
       SaveValues.getInstance().SaveGame();
    }

    //Load game to a file
    public void LoadGame()
    {
        Debug.Log("Serialising" + Application.persistentDataPath + "/gamesave.save");

        // 1
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            SaveValues.setInstance((SaveValues)bf.Deserialize(file));
            file.Close();
        }


    }
}
[System.Serializable]
public sealed class SaveValues
{
    private static SaveValues instance = null;
    private static readonly object padlock = new object();
    public Dictionary<AchievementType, Achievement> achievementsMap;
    public Dictionary<string, int> highScoreDict;
    public bool firstPlay;
    public bool forestUnlocked;
    public bool oceanUnlocked;
    
    //Save game to a file
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        SaveValues.getInstance().UpdateValues();
        bf.Serialize(file, SaveValues.getInstance());

        Debug.Log("Serialising " + Application.persistentDataPath + "/gamesave.save");

        file.Close();

        Debug.Log("Game Saved");
    }

    //Load game to a file
    public void LoadGame()
    {
        // 1
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Debug.Log("Loading " + Application.persistentDataPath + "/gamesave.save");

            SaveValues sv = (SaveValues)bf.Deserialize(file);
            AchievementManager.instance.achievementsMap = sv.achievementsMap;
            GlobalGameManager.instance.highScoreDict = sv.highScoreDict;

            GlobalGameManager.instance.forestUnlocked = sv.forestUnlocked;
            GlobalGameManager.instance.oceanUnlocked = sv.oceanUnlocked;
            GlobalGameManager.instance.firstPlay = sv.firstPlay;

            file.Close();
        }
        AchievementManager.instance.IncrementAchievement(AchievementType.Plays);


    }

    //Grab update to values
    public void UpdateValues()
    {
        achievementsMap = AchievementManager.instance.achievementsMap;
        highScoreDict = GlobalGameManager.instance.highScoreDict;
        forestUnlocked = GlobalGameManager.instance.forestUnlocked;
        oceanUnlocked = GlobalGameManager.instance.oceanUnlocked;
        firstPlay = GlobalGameManager.instance.firstPlay;
    }
    public static SaveValues getInstance()
    {
        if (instance == null)
        {
            instance = new SaveValues();
        }
        return instance;
    }

    internal static void setInstance(SaveValues saveValues)
    {
        instance = saveValues;
    }
}