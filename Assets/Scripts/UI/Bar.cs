using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    private Transform bar;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void setBar(string name) {
        bar = transform.Find(name);
    }

    public void setSize(float no) {
        bar.localScale = new Vector3(no, 1f);
    }
}
