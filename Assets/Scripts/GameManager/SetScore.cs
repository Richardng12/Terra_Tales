using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScore : MonoBehaviour
{
    public Text forestScore;

    public Text oceanScore;

    public Text cityScore;

    // Start is called before the first frame update
    void Start()
    {
        forestScore.text = Scoring.forestScore.ToString();
        oceanScore.text = Scoring.oceanScore.ToString();
        cityScore.text = Scoring.cityScore.ToString();
    }
}
