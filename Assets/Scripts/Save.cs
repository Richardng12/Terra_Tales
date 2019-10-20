using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Save : MonoBehaviour
{

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        SaveValues.getInstance().UpdateValues();
        bf.Serialize(file, SaveValues.getInstance());
        Debug.Log("Serialising" + Application.persistentDataPath + "/gamesave.save");
        Debug.Log("Serialising" + SaveValues.getInstance().highScoreDict.Count + "/gamesave.save");

        file.Close();

        Debug.Log("Game Saved");
    }

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

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        SaveValues.getInstance().UpdateValues();
        bf.Serialize(file, SaveValues.getInstance());
            Debug.Log("Count " + SaveValues.getInstance().highScoreDict.Count);

        Debug.Log("Serialising " + Application.persistentDataPath + "/gamesave.save");

        file.Close();

        Debug.Log("Game Saved");
    }

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
            HighScore.highScoreDict = sv.highScoreDict;
            Debug.Log("Count " + sv.highScoreDict.Count);

            file.Close();
        }


    }
    public void UpdateValues()
    {
        achievementsMap = AchievementManager.instance.achievementsMap;
        highScoreDict = HighScore.highScoreDict;
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