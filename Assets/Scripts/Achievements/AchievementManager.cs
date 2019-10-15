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
    public string msg0 { get; set; }
    public string msg1 { get; set; }

    public AchievementName(int unlockCount, bool isUnlocked, string name, string msg0, string msg1)
    {
        this.unlockCount = unlockCount;
        this.isUnlocked = isUnlocked;
        this.name = name;
        this.msg0 = msg0;
        this.msg1 = msg1;
    }
}
public class Achievement
{
    public string msg0 { get; set; }
    public string msg1 { get; set; }
    public int count { get; set; }

    public List<AchievementName> achievementNames;

    public Achievement(string msg0, string msg1)
    {
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

    private Dictionary<AchievementType, List<AchievementName>> achievementsMap = new Dictionary<AchievementType, List<AchievementName>>();
    //private static List<Achievement> unlockedAchievements;
    private Dictionary<AchievementType, int> achievementCounts = new Dictionary<AchievementType, int>();

    //TODO get last unlocked.

    public List<AchievementName> GetCompletedAchievements(AchievementType achievementType)
    {
        List<AchievementName> result = new List<AchievementName>();
        foreach (AchievementName achievement in achievementsMap[achievementType])
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
        return achievementsMap[achievementType][0];
    }
    public int GetCountForType(AchievementType achievementType)
    {
        return achievementCounts[achievementType];
    }



    public List<AchievementName> GetUnlockedAchievements()
    {
        List<AchievementName> result = new List<AchievementName>();
        foreach (KeyValuePair<AchievementType, List<AchievementName>> entry in achievementsMap)
        {
            // do something with entry.Value or entry.Key
            foreach (AchievementName achievement in entry.Value)
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
        List<AchievementName> achievements = achievementsMap[ach];
        foreach (AchievementName achievement in achievements)
        {
            bool waslocked = !achievement.isUnlocked;
            if (curCount >= achievement.unlockCount)
            {
                achievement.isUnlocked = true;
                if (waslocked)
                {
                    StartCoroutine(ShowAndFade());
                    message.text = achievement.msg0 + achievement.unlockCount + achievement.msg1;
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


        //int fadeOutTime = 5;
        // for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        // {
        //           gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(gameObject.GetComponent<MeshRenderer>().material.color, Color.clear, Mathf.Min(1, t / fadeOutTime));

        //         yield return null;
        //   }

    }

    // Start is called before the first frame update
    void Start()
    {
        //Initialise count array
        foreach (AchievementType achievementType in Enum.GetValues(typeof(AchievementType)))
        {
            achievementCounts.Add(achievementType, 0);
            List<AchievementName> initialList = new List<AchievementName>();
            achievementsMap.Add(achievementType, initialList);
        }
        AddAchievementToType(AchievementType.Plays, 1, false, "First Time Playing!", "Congratulations on playing for ", " time");
        IncrementAchievement(AchievementType.Plays);

        AddAchievementToType(AchievementType.PlantingTrees, 1, false, "Tree Trooper", "Congratulations on planting ", " tree");
        AddAchievementToType(AchievementType.PlantingTrees, 2, false, "Tree Hugger", "Congratulations on planting ", " trees");
        AddAchievementToType(AchievementType.PlantingTrees, 3, false, "Tree Mesiah", "Congratulations on planting ", " trees");
        
    }

    private void AddAchievementToType(AchievementType type, int unlockCount, bool isUnlocked, string name, string msg0, string msg1)
    {
        AchievementName achievement = new AchievementName(unlockCount,isUnlocked,name,msg0,msg1);
        achievementsMap[type].Add(achievement);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
