using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        List<Achievement> achievements = achievementsMap[ach];
        foreach (Achievement achievement in achievements)
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
        List<Achievement> initialList = new List<Achievement>();
        Achievement ach = new Achievement(1, false, "First Time Playing!", "Congratulations on playing for ", " time");
        initialList.Add(ach);
        achievementsMap.Add(AchievementType.Plays, initialList);
        achievementCounts.Add(AchievementType.Plays, 0);
        //achievementCounts.Add(AchievementType.PlantingTrees, 0);
        IncrementAchievement(AchievementType.Plays);


        initialList = new List<Achievement>();
        ach = new Achievement(1, false, "Tree Trooper", "Congratulations on planting ", " trees");
        initialList.Add(ach);
        ach = new Achievement(2, false, "Tree Hugger", "Congratulations on planting ", " trees");
        initialList.Add(ach);
        ach = new Achievement(3, false, "Tree Mesiah", "Congratulations on planting ", " trees");
        initialList.Add(ach);
        //TODO remove this
        achievementsMap.Add(AchievementType.PlantingTrees, initialList);
        achievementCounts.Add(AchievementType.PlantingTrees, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
