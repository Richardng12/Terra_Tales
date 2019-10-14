using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementBox : MonoBehaviour
{
    public Text achievemntMessage;
    public Text achievementName;

    public string achievementType;
    // Start is called before the first frame update
    void Start()
    {
        getStats(achievementType);
    }

    void getStats(string s)
    {
        Type t = typeof(AchievementType);
        AchievementType achievementType = (AchievementType)Enum.Parse(t, s);
        AchievementManager aMan = new AchievementManager();
        achievemntMessage.text = aMan.getAchievementForType(achievementType).name;
        int achievementCount = aMan.getCountForType(achievementType);
        achievemntMessage.text = "Congratulations on achieving " + achievementCount + achievementType.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
