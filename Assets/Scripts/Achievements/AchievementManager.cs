using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class AchievementName
{
    public int unlockCount { get; set; }
    public bool isUnlocked { get; set; }
    public string name { get; set; }

    public AchievementName(int unlockCount, string name)
    {
        this.unlockCount = unlockCount;
        this.isUnlocked = false;
        this.name = name;
    }
}
[System.Serializable]

public class Achievement
{
    public string msg0 { get; set; }
    public string msg1 { get; set; }
    public string lockedMsg { get; set; }
    public int count { get; set; }
    public int unlockedAchievements { get; set; }

    public List<AchievementName> achievementNames;

    public Achievement(string msg0, string msg1, string lockedMsg)
    {
        this.lockedMsg = lockedMsg;
        unlockedAchievements = 0;
        this.msg0 = msg0;
        this.msg1 = msg1;
        count = 0;
        achievementNames = new List<AchievementName>();
    }
}
[System.Serializable]

public enum AchievementType
{
    PlantingTrees,
    Time,
    ReducingFires,
    RefillingGun,
    LevelCompletions,
    Trash,
    Switch,
    Plays,
    Deaths,
    HighScore,
    Fires,
    LevelCompletionsForest,
    LevelCompletionsOcean,
    LevelCompletionsCity,
    OilSpills,
    Achievements,
};

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager instance;

    public Text name;
    public Text message;

    public CanvasGroup achievementNotification;

    public Dictionary<AchievementType, Achievement> achievementsMap = new Dictionary<AchievementType, Achievement>();
    //private static List<Achievement> unlockedAchievements;

    //TODO get last unlocked.

    public List<AchievementName> GetCompletedAchievements(AchievementType achievementType)
    {
        List<AchievementName> result = new List<AchievementName>();
        foreach (AchievementName achievement in achievementsMap[achievementType].achievementNames)
        {
            if (achievement.isUnlocked)
            {
                result.Add(achievement);
            }
        }

        return result;
    }

    public AchievementName GetAchievementForType(AchievementType achievementType)
    {
        return achievementsMap[achievementType].achievementNames[0];
    }
    public int GetCountForType(AchievementType achievementType)
    {
        return achievementsMap[achievementType].count;
    }

    public AchievementName GetLastAchievement(AchievementType achievementType)
    {
        Achievement achievement = achievementsMap[achievementType];
        return achievement.achievementNames[achievement.count - 1];
    }

    public List<AchievementName> GetUnlockedAchievements()
    {
        List<AchievementName> result = new List<AchievementName>();
        foreach (KeyValuePair<AchievementType, Achievement> entry in achievementsMap)
        {
            // do something with entry.Value or entry.Key
            foreach (AchievementName achievement in entry.Value.achievementNames)
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

        if (instance == null)
        {
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
        return achievementsMap[achievementType].achievementNames[index].unlockCount;
    }
    private HashSet<AchievementType> achievementsHashSet = new HashSet<AchievementType>();
    public void IncrementAchievement(AchievementType ach)
    {
        achievementsMap[ach].count++;
        updateAchievement(ach);

        achievementsHashSet.Add(ach);
        achievementsHashSet.Add(AchievementType.Achievements);
        achievementsMap[AchievementType.Achievements].count = achievementsHashSet.Count;
    }

    public void closeNotificatino()
    {
        StopAllCoroutines();
        achievementNotification.gameObject.SetActive(false);

    }

    private void updateAchievement(AchievementType ach)
    {

        int curCount = achievementsMap[ach].count;
        List<AchievementName> achievements = achievementsMap[ach].achievementNames;
        foreach (AchievementName achievement in achievements)
        {
            bool waslocked = !achievement.isUnlocked;
            if (curCount >= achievement.unlockCount)
            {
                achievement.isUnlocked = true;
                if (waslocked)
                {
                    if (curCount != 0)
                    {
                        StartCoroutine(ShowAndFade());

                        message.text = achievementsMap[ach].msg0 + achievement.unlockCount + achievementsMap[ach].msg1;
                        name.text = achievement.name;
                    }
                    achievementsMap[ach].unlockedAchievements++;
                }
            }
        }
    }

    IEnumerator ShowAndFade()
    {
        achievementNotification.gameObject.SetActive(true);
        achievementNotification.alpha = 1;
        yield return new WaitForSeconds(3);
        for (float i = 1f; i > 0; i -= 0.01f)
        {
            yield return new WaitForSeconds(.01f);
            achievementNotification.alpha = i;
        }
        achievementNotification.gameObject.SetActive(false);

    }

    public String GetMessageForAchievement(AchievementType achievementType)
    {
        Achievement achievement = achievementsMap[achievementType];
        if (achievement.count < 1)
        {
            return achievement.lockedMsg;
        }
        else
        {
            return achievement.msg0 + achievement.count + achievement.msg1;
        }
    }
    void Start()
    {
        //Initialise achievement messages
        achievementsMap.Add(AchievementType.Plays, new Achievement("Congratulations on playing for ", " time(s)", "Play to unlock this achievement"));
        achievementsMap.Add(AchievementType.PlantingTrees, new Achievement("Congratulations on planting ", " tree(s)", "Plant trees to unlock this achievement"));
        achievementsMap.Add(AchievementType.Time, new Achievement("Congratulations on finishing ", " level(s) in under three minutes", "Finish a level in under three minutes to unlock this achievement"));
        achievementsMap.Add(AchievementType.Fires, new Achievement("Congratulations on putting out ", " fire(s)", "Put out fires to unlock this achievement"));
        achievementsMap.Add(AchievementType.LevelCompletionsForest, new Achievement("Congratulations on completing ", " forest level(s)", "Finish the forest level to unlock this achievement"));
        achievementsMap.Add(AchievementType.LevelCompletionsOcean, new Achievement("Congratulations on completing ", " ocean level(s)", "Finish the ocean level to unlock this achievement"));
        achievementsMap.Add(AchievementType.LevelCompletionsCity, new Achievement("Congratulations on completing ", " city level(s)", "Finish the city level to unlock this achievement"));
        achievementsMap.Add(AchievementType.Deaths, new Achievement("Congratulations on persisiting through ", " failures(s)", "Continue trying despite failing"));
        achievementsMap.Add(AchievementType.OilSpills, new Achievement("Congratulations on cleaning up ", " spill(s)", "Take care of oil spills to unlock this achievement"));
        achievementsMap.Add(AchievementType.Trash, new Achievement("Congratulations on cleaning up ", " pieces of trash", "Take care of trash to unlock this achievement"));
        achievementsMap.Add(AchievementType.Switch, new Achievement("Congratulations on turning off ", " lights", "Turn off a light to unlock this achievement"));
        achievementsMap.Add(AchievementType.Achievements, new Achievement("Congratulations on finishing ", " Achievements", "Get an achievement to unlock this achievement"));

        //Initialise achievement counts and names
        AddAchievementToType(AchievementType.Plays, 0, "Play Count");
        AddAchievementToType(AchievementType.Plays, 1, "Novice");
        AddAchievementToType(AchievementType.Plays, 4, "Adventurer");
        AddAchievementToType(AchievementType.Plays, 10, "Expert");
        IncrementAchievement(AchievementType.Plays);

        //Initialise achievement counts and names
        AddAchievementToType(AchievementType.Achievements, 0, "Achievements Unlocked");
        AddAchievementToType(AchievementType.Achievements, 1, "Trophy Hunter");
        AddAchievementToType(AchievementType.Achievements, 4, "Trophy Collector");
        AddAchievementToType(AchievementType.Achievements, 10, "Museum Owner");

        AddAchievementToType(AchievementType.Trash, 0, "Garbage Collection");
        AddAchievementToType(AchievementType.Trash, 1, "Garbage Man");
        AddAchievementToType(AchievementType.Trash, 2, "Garbage Hero");
        AddAchievementToType(AchievementType.Trash, 5, "God of garbage");

        AddAchievementToType(AchievementType.Time, 0, "Time");
        AddAchievementToType(AchievementType.Time, 1, "Speed Demon");
        AddAchievementToType(AchievementType.Time, 2, "Sprint Demon");
        AddAchievementToType(AchievementType.Time, 5, "Speed God");

        AddAchievementToType(AchievementType.Switch, 0, "Switches turned off");
        AddAchievementToType(AchievementType.Switch, 1, "Conserver");
        AddAchievementToType(AchievementType.Switch, 5, "Light Hero");
        AddAchievementToType(AchievementType.Switch, 15, "Faster than Light");

        AddAchievementToType(AchievementType.PlantingTrees, 0, "Planting Trees");
        AddAchievementToType(AchievementType.PlantingTrees, 1, "Tree Hugger");
        AddAchievementToType(AchievementType.PlantingTrees, 7, "Tree Trooper");
        AddAchievementToType(AchievementType.PlantingTrees, 10, "Tree Mesiah");

        AddAchievementToType(AchievementType.Fires, 0, "Putting out fires");
        AddAchievementToType(AchievementType.Fires, 1, "Fire Recruit");
        AddAchievementToType(AchievementType.Fires, 8, "Fire Fighter");
        AddAchievementToType(AchievementType.Fires, 12, "Fire Genneral");

        AddAchievementToType(AchievementType.LevelCompletionsForest, 0, "Forest Level Completions");
        AddAchievementToType(AchievementType.LevelCompletionsForest, 1, "Forest Trooper ");
        AddAchievementToType(AchievementType.LevelCompletionsForest, 2, "Nature Lover");
        AddAchievementToType(AchievementType.LevelCompletionsForest, 3, "Mother Nature");

        AddAchievementToType(AchievementType.LevelCompletionsOcean, 0, "Ocean Level Completions");
        AddAchievementToType(AchievementType.LevelCompletionsOcean, 1, "Ocean Trooper");
        AddAchievementToType(AchievementType.LevelCompletionsOcean, 2, "Ocean Lover");
        AddAchievementToType(AchievementType.LevelCompletionsOcean, 3, "Poseidon");

        AddAchievementToType(AchievementType.LevelCompletionsCity, 0, "City Level Completeions");
        AddAchievementToType(AchievementType.LevelCompletionsCity, 1, "City Trooper");
        AddAchievementToType(AchievementType.LevelCompletionsCity, 2, "CIty Lover");
        AddAchievementToType(AchievementType.LevelCompletionsCity, 3, "City Saviour");

        AddAchievementToType(AchievementType.Deaths, 0, "Persisting");
        AddAchievementToType(AchievementType.Deaths, 1, "Never Give Up");
        AddAchievementToType(AchievementType.Deaths, 3, "Persevere");
        AddAchievementToType(AchievementType.Deaths, 10, "God of Patience");

        AddAchievementToType(AchievementType.OilSpills, 0, "Cleaning up oill spills");
        AddAchievementToType(AchievementType.OilSpills, 1, "Environmentalist");
        AddAchievementToType(AchievementType.OilSpills, 15, "Ecologist");
        AddAchievementToType(AchievementType.OilSpills, 50, "Conservationalist");

        foreach (AchievementType achievementType in achievementsMap.Keys)
        {
            updateAchievement(achievementType);
        }

    }

    public int GetNumStars(AchievementType achievementType)
    {
        return achievementsMap[achievementType].achievementNames.Count;
    }

    private void AddAchievementToType(AchievementType type, int unlockCount, string name)
    {
        AchievementName achievement = new AchievementName(unlockCount, name);
        achievementsMap[type].achievementNames.Add(achievement);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
