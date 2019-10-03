using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForestNPCInteraction : MonoBehaviour
{
    public bool Interactable = false;

    public Text showText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f") && Interactable)
        {
            Debug.Log("Hello");
        }

    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log(Interactable);
            showText.gameObject.SetActive(true);
            Interactable = true;
            showText.text = "Press E";
        }
    }

    private void OnTriggerExit2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log(Interactable);
            showText.gameObject.SetActive(false);
            Interactable = false;
        }
    }
}
