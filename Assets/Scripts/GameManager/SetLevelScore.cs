﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLevelScore : MonoBehaviour
{

    public Text forestScore;

    public Text oceanScore;

    public Text cityScore;

    // sets score for stages on LevelSelectionScreen
    void Start()
    {
        forestScore.text = Scoring.forestScore.ToString();
        oceanScore.text = Scoring.oceanScore.ToString();
        cityScore.text = Scoring.cityScore.ToString();
    }
}
