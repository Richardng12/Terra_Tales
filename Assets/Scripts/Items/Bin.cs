using System.Collections;
using UnityEngine;

public class Bin : MonoBehaviour, IBins
{
    GameObject collidedObject;
    public GameObject player;
    CharacterController character;
    public GameObject oceanTrackerObject;
    GrabObject grabObject;
    private OceanTracker oceanTracker;
    public string binItem;
    string taskCompleted = "TaskComplete";

    void Start()
    {
        if (oceanTracker != null)
        {
            oceanTracker = oceanTrackerObject.GetComponent<OceanTracker>();
        }
        character = player.GetComponent<CharacterController>();
        grabObject = player.GetComponent<GrabObject>();

    }
    // Checks if the rubbish is of the same type as the bin
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

    // Destroys the rubbish that was collided with the bin
    public void DestroyRubbish()
    {
        if (collidedObject.GetComponent<TrashScript>() != null)
        {
            collidedObject.GetComponent<TrashScript>().OnDestroy();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        CheckCollision(collision);
    }

    public void CheckCollision(Collider2D collision)
    {
        collidedObject = null;
        // If the collsion object is a rubbish type which is grabbable and the player
        // has released it
        if (collision != null)
        {
          
            Debug.Log(grabObject);
            if (collision.gameObject.tag.Equals("Grabbable") && !grabObject.GetIsGrabbed())
            {
                Debug.Log("asdjnfihsdgjbhvfhisgbuoghbj");
                collidedObject = collision.gameObject;
                if (CheckRubbish())
                {
                    AudioManager.instance.Play(taskCompleted);
                    // If the rubbish is the right type it should update the counter
                    if(oceanTracker!= null)
                    oceanTracker.UpdateAndDisplayTaskCounter(binItem);

                }
                else
                {
                    Debug.Log(collidedObject.name);
                    if(oceanTracker!= null)
                    oceanTracker.ShowWrongRubbishPrompt();
                }
                DestroyRubbish();
            }
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        CheckCollision(collision);
    }
}