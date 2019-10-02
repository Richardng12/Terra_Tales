using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seedling : MonoBehaviour
{

    public bool Interactable = false;
    public float CurrentProgress;
    public  readonly float MaxProgress = 5;
    // Start is called before the first frame update
    void Start()
    {
        CurrentProgress = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("f") && Interactable)
        {
            CurrentProgress += Time.deltaTime;
            Debug.Log(CurrentProgress);
        }
        if(Input.GetKey("f") && Interactable && CurrentProgress == 5)
        {
            Interactable = false;
        }
        if (Input.GetKeyUp("f") && CurrentProgress < MaxProgress )
        {
            CurrentProgress = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log(Interactable);
            Interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log(Interactable);
            Interactable = false;
            CurrentProgress = 0;
        }
    }
}
