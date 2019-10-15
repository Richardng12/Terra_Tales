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
    void GetStats(String achievementType)
    {
        Type t = typeof(AchievementType);
        AchievementType at = (AchievementType)Enum.Parse(t, achievementType);
        Debug.Log(at);
        // AchievementManager aMan = GetComponent<AchievementManager>();
        AchievementManager aMan = AchievementManager.instance;
        Debug.Log(aMan);
        List<AchievementName> completedAchievements = aMan.GetCompletedAchievements(at);
        SetStars(completedAchievements.Count);
        SetVisibleStars(aMan.GetNumStars(at));

        AchievementName curAch = completedAchievements[completedAchievements.Count - 1];
        achievementName.text = curAch.name;
        int achievementCount = aMan.GetCountForType(at);
        achievemntMessage.text = aMan.GetMessageForAchievement(at);

        starOneText.text = aMan.getUnlockNum(at, 0).ToString();
        starTwoText.text = aMan.getUnlockNum(at, 1).ToString();
        starThreeText.text = aMan.getUnlockNum(at, 2).ToString();

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
