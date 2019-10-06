using System.Collections;
using UnityEngine;

public class Bin : MonoBehaviour, IBins
{
    GameObject collidedObject;
    public GameObject player;
    public GameObject oceanTrackerObject;
    private OceanTracker oceanTracker;
    public string binItem;

    void Start()
    {
        oceanTracker = oceanTrackerObject.GetComponent<OceanTracker>();
    }

    public bool CheckRubbish()
    {
        if (collidedObject.name.Equals(binItem))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DestroyRubbish()
    {
        collidedObject.GetComponent<TrashScript>().OnDestroy();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterController character = player.GetComponent<CharacterController>();
        GrabObject grabObject = player.GetComponent<GrabObject>();

        // If the collsion object is a rubbish type which is grabbable and the player
        // has released it
        if (collision.gameObject.tag.Equals("Grabbable") && !grabObject.GetIsGrabbed() )
        {
            Debug.Log(grabObject.GetIsGrabbed());

            collidedObject = collision.gameObject;
            if (CheckRubbish())
            {
                oceanTracker.UpdateAndDisplayTaskCounter(binItem);
            }
            else
            {
                // Character gets prompted of wrong rubbish placement
            }
            DestroyRubbish();

        }
    }
}
