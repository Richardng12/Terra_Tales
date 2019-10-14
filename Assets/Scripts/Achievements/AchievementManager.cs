using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement
{
    public int unlockCount { get; set; }
    public bool isUnlocked { get; set; }
    public string message { get; set; }

    public Achievement(int unlockCount, bool isUnlocked, string message)
    {
        this.unlockCount = unlockCount;
        this.isUnlocked = isUnlocked;
        this.message = message;
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
    private static Dictionary<AchievementType, List<Achievement>> achievementsMap;
    //private static List<Achievement> unlockedAchievements;
    private Dictionary<AchievementType, int> achievementCounts;

    public List<Achievement> getUnlockedAchievements()
    {
        List<Achievement> result = new List<Achievement>();
        foreach (KeyValuePair<AchievementType, List<Achievement>> entry in achievementsMap)
        {
            // do something with entry.Value or entry.Key
            foreach(Achievement achievement in entry.Value){
                if(achievement.isUnlocked){
                    result.Add(achievement);
                }
            }
        }
        return result;

        //return unlockedAchievements;
    }

    public void init()
    {
        List<Achievement> initialList = new List<Achievement>();
        Achievement ach = new Achievement(3, false, "First Time Playing!");
        initialList.Add(ach);
        achievementsMap.Add(AchievementType.Boots, initialList);
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
