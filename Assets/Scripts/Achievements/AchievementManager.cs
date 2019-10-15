using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
public class Achievement
{
    public string msg0 { get; set; }
    public string msg1 { get; set; }
    public int count { get; set; }
    public int unlockedAchievements { get; set; }

    public List<AchievementName> achievementNames;

    public Achievement(string msg0, string msg1)
    {
        unlockedAchievements = 0;
        this.msg0 = msg0;
        this.msg1 = msg1;
        count = 0;
        achievementNames = new List<AchievementName>();
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
    Plays,
    Deaths,
    HighScore,
};

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager instance;

    public Text name;
    public Text message;

    public CanvasGroup achievementNotification;

    private Dictionary<AchievementType, Achievement> achievementsMap = new Dictionary<AchievementType, Achievement>();
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
                Destroy(this.achievementNotification);
            }
        }
    }

    public int getUnlockNum(AchievementType achievementType, int index)
    {
        return achievementsMap[achievementType].achievementNames[index].unlockCount;
    }

    public void IncrementAchievement(AchievementType ach)
    {
        achievementsMap[ach].count++;
        updateAchievement(ach);
    }

    private void updateAchievement(AchievementType ach)
    {
        Debug.Log("Updating achievements");

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
                    StartCoroutine(ShowAndFade());
                    achievementsMap[ach].unlockedAchievements++;
                    message.text = achievementsMap[ach].msg0 + achievement.unlockCount + achievementsMap[ach].msg1;
                    name.text = achievement.name;
                }
                Debug.Log("Unlocked one");
            }
        }
    }

    IEnumerator ShowAndFade()
    {
        achievementNotification.alpha = 1;
        yield return new WaitForSeconds(1);
        for (float i = 1f; i > 0; i -= 0.01f)
        {
            yield return new WaitForSeconds(.01f);
            achievementNotification.alpha = i;
        }
    }
    public String GetMessageForAchievement(AchievementType achievementType)
    {
        Achievement achievement = achievementsMap[achievementType];
        return achievement.msg0 + achievement.count + achievement.msg1;
    }
    void Start()
    {
        //Initialise achievement messages
        Achievement achievement = new Achievement("Congratulations on playing for ", " time");
        achievementsMap.Add(AchievementType.Plays, achievement);
        achievement = new Achievement("Congratulations on planting ", " trees");
        achievementsMap.Add(AchievementType.PlantingTrees, achievement);


        //Initialise achievement counts and names
        AddAchievementToType(AchievementType.Plays, 1, "First Time Playing!");
        IncrementAchievement(AchievementType.Plays);

        AddAchievementToType(AchievementType.PlantingTrees, 1, "Tree Trooper");
        AddAchievementToType(AchievementType.PlantingTrees, 2, "Tree Hugger");
        AddAchievementToType(AchievementType.PlantingTrees, 3, "Tree Mesiah");

    }

    public int GetNumStars(AchievementType achievementType){
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
