using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowNew : MonoBehaviour
{
    public Sprite WindowPerson;

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = WindowPerson;
    }
}
