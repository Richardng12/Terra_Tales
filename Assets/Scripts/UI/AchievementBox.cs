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
    public Text starOneText;
    public Text starTwoText;
    public Text starThreeText;
    public string achievementType;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I'm here");
    }

    void Update()
    {
        GetStats(achievementType);
    }

    // Retrieve stats to show
    void GetStats(String achievementTypeStr)
    {
        Type t = typeof(AchievementType);
        AchievementType achievementType = (AchievementType)Enum.Parse(t, achievementTypeStr);
        AchievementManager aMan = AchievementManager.instance;

        achievemntMessage.text = aMan.GetMessageForAchievement(achievementType);

        List<AchievementName> completedAchievements = aMan.GetCompletedAchievements(achievementType);
        Debug.Log(completedAchievements.Count);
        SetStars(completedAchievements.Count);
        SetVisibleStars(aMan.GetNumStars(achievementType));

        AchievementName curAch = completedAchievements[completedAchievements.Count - 1];
        achievementName.text = curAch.name;
        int achievementCount = aMan.GetCountForType(achievementType);

        starOneText.text = aMan.getUnlockNum(achievementType, 1).ToString();
        starTwoText.text = aMan.getUnlockNum(achievementType, 2).ToString();
        starThreeText.text = aMan.getUnlockNum(achievementType, 3).ToString();

    }

    // Set visible stars to yellow if required
    private void SetStars(int count)
    {
        if (count > 1)
        {
            starOne.color = achievedColor;
        }
        if (count > 2)
        {
            starTwo.color = achievedColor;
        }
        if (count > 3)
        {
            starThree.color = achievedColor;
        }

    }
    private void SetVisibleStars(int count)
    {
        if (count > 0)
        {
            starOne.enabled = true;
        }
        if (count > 1)
        {
            starTwo.enabled = true;
        }
        if (count > 2)
        {
            starThree.enabled = true;
        }
        if (count > 3)
        {
           // starFour.color = true;
        }
        if (count > 4)
        {
           // starFive.color = true;
        }

    }


}
