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
        Debug.Log("I'm here");
        getStats(achievementType);
    }

    void getStats(String achievementType)
    {
        Type t = typeof(AchievementType);
        AchievementType at = (AchievementType)Enum.Parse(t, achievementType);
        Debug.Log(at);
        AchievementManager aMan = new AchievementManager();
        achievementName.text = aMan.getAchievementForType(at).name;
        int achievementCount = aMan.getCountForType(at);
        achievemntMessage.text = "Congratulations on achieving " + achievementCount + achievementType.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
