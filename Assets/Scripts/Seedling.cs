using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seedling : MonoBehaviour
{
    public bool Interactable = false;
    public float CurrentProgress;
    public readonly float MaxProgress = 5;

    // Start is called before the first frame update
    void Start()
    {
        CurrentProgress = 0;
        transform.Find("ProgressBar").localScale = new Vector3(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e") && Interactable && CurrentProgress > 5)
        {
            Interactable = false;
            transform.Find("ProgressBar").localScale = new Vector3(0, 1);

        }
        if (Input.GetKey("e") && Interactable)
        {
            CurrentProgress += Time.deltaTime;
            Debug.Log(CurrentProgress);
            float progress = CurrentProgress / MaxProgress;
            Debug.Log("progress" + progress);
            transform.Find("ProgressBar").localScale = new Vector3(1 - progress, 1);
        }
        if (Input.GetKeyUp("e") && CurrentProgress < MaxProgress)
        {
            CurrentProgress = 0;
            transform.Find("ProgressBar").localScale = new Vector3(0, 1);
        }

    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("Player") && CurrentProgress <= MaxProgress)
        {
            Debug.Log(Interactable);
            transform.Find("ProgressBar").localScale = new Vector3(1, 1);
            Interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log(Interactable);
            transform.Find("ProgressBar").localScale = new Vector3(0, 1);
            Interactable = false;
            CurrentProgress = 0;
        }
    }
}
