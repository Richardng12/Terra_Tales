﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement
{
    public int unlockCount { get; set; }
    public bool isUnlocked { get; set; }
    public string name { get; set; }
    public string msg0 { get; set; }
    public string msg1 { get; set; }

    public Achievement(int unlockCount, bool isUnlocked, string name, string msg0, string msg1)
    {
        this.unlockCount = unlockCount;
        this.isUnlocked = isUnlocked;
        this.name = name;
        this.msg0 = msg0;
        this.msg1 = msg1;
    }
}
public enum AchievementType
{
    PlantingTrees,
    ReducingFires,
    RefillingGun,
    LevelCompletions,
    Trash,
    Switch,
    Boots,
    Deaths,
    HighScore,
};

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager instance;

    private Dictionary<AchievementType, List<Achievement>> achievementsMap = new Dictionary<AchievementType, List<Achievement>>();
    //private static List<Achievement> unlockedAchievements;
    private Dictionary<AchievementType, int> achievementCounts = new Dictionary<AchievementType, int>();

    //TODO get last unlocked.

    public List<Achievement> GetCompletedAchievements(AchievementType achievementType)
    {
        List<Achievement> result = new List<Achievement>();
        foreach (Achievement achievement in achievementsMap[achievementType])
        {
            if (achievement.isUnlocked)
            {
                result.Add(achievement);
            }
        }

        return result;
    }

    public Achievement GetAchievementForType(AchievementType achievementType)
    {
        return achievementsMap[achievementType][0];
    }
    public int GetCountForType(AchievementType achievementType)
    {
        return achievementCounts[achievementType];
    }



    public List<Achievement> GetUnlockedAchievements()
    {
        List<Achievement> result = new List<Achievement>();
        foreach (KeyValuePair<AchievementType, List<Achievement>> entry in achievementsMap)
        {
            // do something with entry.Value or entry.Key
            foreach (Achievement achievement in entry.Value)
            {
                if (achievement.isUnlocked)
                {
                    result.Add(achievement);
                }
            }
        }
        return result;

        //return unlockedAchievements;
    }

    void Awake()
    {
            Debug.Log("Awaenachieveentangercalled");

        if (instance == null)
        {
            Debug.Log("Thiis");
            instance = this;
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

    public int getUnlockNum(AchievementType achievementType, int index)
    {
        return achievementsMap[achievementType][index].unlockCount;
    }

    public void IncrementAchievement(AchievementType ach)
    {
        achievementCounts[ach]++;
        updateAchievement(ach);

    }

    private void updateAchievement(AchievementType ach)
    {
        Debug.Log("Updating achievements");

        int curCount = achievementCounts[ach];
        List<Achievement> achievements = achievementsMap[ach];
        foreach (Achievement achievement in achievements)
        {
            if (curCount >= achievement.unlockCount)
            {
                achievement.isUnlocked = true;
                Debug.Log("Unlocked one");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        List<Achievement> initialList = new List<Achievement>();
        Achievement ach = new Achievement(3, false, "First Time Playing!", "Congratulations on playing for ", " time");
        initialList.Add(ach);
        achievementsMap.Add(AchievementType.Boots, initialList);

        initialList = new List<Achievement>();
        ach = new Achievement(1, false, "Tree Trooper", "Congratulations on planting ", " trees");
        initialList.Add(ach);
        ach = new Achievement(5, false, "Tree Hugger", "Congratulations on planting ", " trees");
        initialList.Add(ach);
        ach = new Achievement(10, false, "Tree Mesiah", "Congratulations on planting ", " trees");
        initialList.Add(ach);
        //TODO remove this
        achievementsMap.Add(AchievementType.PlantingTrees, initialList);
        achievementCounts.Add(AchievementType.PlantingTrees, 1);
        IncrementAchievement(AchievementType.PlantingTrees);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
