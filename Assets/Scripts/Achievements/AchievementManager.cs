using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement
{
    public int unlockCount { get; set; }
    public bool isUnlocked { get; set; }
    public string name { get; set; }

    public Achievement(int unlockCount, bool isUnlocked, string name)
    {
        this.unlockCount = unlockCount;
        this.isUnlocked = isUnlocked;
        this.name = name;
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
    private static Dictionary<AchievementType, List<Achievement>> achievementsMap = new Dictionary<AchievementType, List<Achievement>>();
    //private static List<Achievement> unlockedAchievements;
    private Dictionary<AchievementType, int> achievementCounts = new Dictionary<AchievementType, int>();

    //TODO get last unlocked.
    public Achievement getAchievementForType(AchievementType achievementType)
    {
        return achievementsMap[achievementType][0];
    }
    public int getCountForType(AchievementType achievementType)
    {
        return achievementCounts[achievementType];
    }



    public List<Achievement> getUnlockedAchievements()
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

    public AchievementManager()
    {
        if (achievementCounts.Keys.Count == 0)
        {
            List<Achievement> initialList = new List<Achievement>();
            Achievement ach = new Achievement(3, false, "First Time Playing!");
            initialList.Add(ach);
            achievementsMap.Add(AchievementType.Boots, initialList);
            
            initialList = new List<Achievement>();
            ach = new Achievement(3, false, "Plated the first tree!");
            initialList.Add(ach);
            achievementsMap.Add(AchievementType.PlantingTrees, initialList);
            achievementCounts.Add(AchievementType.PlantingTrees, 4);
        }
    }

    public void IncrementAchievement(AchievementType ach)
    {
        achievementCounts[ach]++;
        updateAchievement(ach);

    }

    private void updateAchievement(AchievementType ach)
    {
        int curCount = achievementCounts[ach];
        List<Achievement> achievements = achievementsMap[ach];
        foreach (Achievement achievement in achievements)
        {
            if (achievement.unlockCount >= curCount)
            {
                achievement.isUnlocked = true;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
