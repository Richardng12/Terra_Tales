using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    private bool isGrabbed = false;

    public Transform holdPoint;
    GameObject grabbedRubbishItem;
    GameObject rubbishItem;
    Rigidbody2D rb;
    public float throwVelocity;
    private bool interactable = false;

    // Update is called once per frame
    void Update()
    {
        // If action button is pressed
        if (Input.GetButtonDown("Fire2"))
        {
            // Grabs the object
            Grab();
        }
        if (isGrabbed)
        {
            // Throws the object
            if (grabbedRubbishItem != null)
            {
                grabbedRubbishItem.transform.position = holdPoint.position;
            }
        }
    }
    private void Grab()
    {
        // If player is already grabbing something
        if (isGrabbed)
        {
            // Then set that grabbed object as the fields rigid body
            rb = grabbedRubbishItem.gameObject.GetComponent<Rigidbody2D>();
            // Since the object will be thrown isGrabbed is set to false
            isGrabbed = false;
            if (rb != null)
            {
                // Updates the objects velocity so that it is thrown
                rb.velocity = new Vector2(transform.localScale.x, 1) * throwVelocity;
            }
        }
        else
        {
            // If the player hasnt grabbed anything and is in range of r=grabbing a object
            if (interactable)
            {
                // Set is grabbed to true so update method changes object location
                isGrabbed = true;
                // Sets the grabbedRubbishItem to the current hovered rubbish item 
                grabbedRubbishItem = rubbishItem;
            }
        }
    }

    // Getters and Setters for the fields in this class

    public bool GetIsGrabbed()
    {
        return isGrabbed;
    }

    public void SetGrabbed(bool boolean)
    {
        isGrabbed = boolean;
    }

    public void SetInteractable(bool boolean)
    {
        interactable = boolean;
    }

    public void SetRubbishItem(GameObject rubbishItem)
    {
        this.rubbishItem = rubbishItem;
    }

}
