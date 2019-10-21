using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHUD : MonoBehaviour
{

    public OceanTracker oceanTracker;
    public Text text0;
    public Text text1;
    public Text text2;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int[] rubbish = oceanTracker.GetTasks();
        text0.text = rubbish[0].ToString()+"/" + oceanTracker.rubbishToCollect;
        text1.text = rubbish[1].ToString()+"/" + oceanTracker.rubbishToCollect;
        text2.text = rubbish[2].ToString()+"/" + oceanTracker.rubbishToCollect;
        
    }
}
