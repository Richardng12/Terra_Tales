using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementBox : MonoBehaviour
{
    public Text achievemntMessage;
    public Text achievementName;
    public Image starOne;
    private Color achievedColor = Color.yellow;
    public Image starTwo;
    public Image starThree;
    public string achievementType;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I'm here");
        GetStats(achievementType);
    }

    void GetStats(String achievementType)
    {
        Type t = typeof(AchievementType);
        AchievementType at = (AchievementType)Enum.Parse(t, achievementType);
        Debug.Log(at);
        AchievementManager aMan = new AchievementManager();

        List<Achievement> completedAchievements = aMan.GetCompletedAchievements(at);
        SetStars(completedAchievements.Count);



        achievementName.text = completedAchievements[completedAchievements.Count -1].name;
        int achievementCount = aMan.GetCountForType(at);
        achievemntMessage.text = "Congratulations on achieving " + achievementCount + " " + achievementType.ToString();

    }

    private void SetStars(int count)
    {
        if (count > 0)
        {
            starOne.color = achievedColor;
        }
        if (count > 1)
        {
            starTwo.color = achievedColor;
        }
        if (count > 2)
        {
            starThree.color = achievedColor;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
