using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    private bool isGrabbed = false;
    RaycastHit2D touching;
    public float grabDistance = 2f;
    public Transform holdPoint;
    Rigidbody2D rb;
    public float throwVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If action button is pressed
        if (Input.GetButtonDown("Fire2"))
        {
            Grab();
        }
        if (isGrabbed)
        {
            touching.collider.gameObject.transform.position = holdPoint.position;
        }
    }
    private void Grab()
    {
        // If player is already grabbing something
        if (isGrabbed)
        {
            rb = touching.collider.gameObject.GetComponent<Rigidbody2D>();
            isGrabbed = false;
            if (rb != null)
            {
                rb.velocity = new Vector2(transform.localScale.x, 1) * throwVelocity;
            }
        }
        else
        {
            Physics2D.queriesStartInColliders = false;
            touching = Physics2D.Raycast(transform.position - Vector3.right * transform.localScale.x, Vector2.right * transform.localScale.x, grabDistance);

            if (touching.collider != null && touching.collider.gameObject.tag.Equals("Grabbable"))
            {
                isGrabbed = true;
            }
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position - Vector3.right * transform.localScale.x, transform.position + Vector3.right * transform.localScale.x*grabDistance);
    }

}
