using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour
{

    public static GlobalGameManager instance;
    public bool firstPlay = true;


    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // Dont destroy this object when a new scene is loaded
            DontDestroyOnLoad(this);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
