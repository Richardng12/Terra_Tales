using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpriteHealth : MonoBehaviour
{
    Vector3 localScale;
    public FireSpriteController fire;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Changes the length of the health bar
        localScale.x = fire.health;
        transform.localScale = localScale;
    }
}
