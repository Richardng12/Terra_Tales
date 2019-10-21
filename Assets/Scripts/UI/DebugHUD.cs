using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugHUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
