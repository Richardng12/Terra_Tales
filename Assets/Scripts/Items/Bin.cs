using System.Collections;
using UnityEngine;

public class Bin : MonoBehaviour, IBins
{
    GameObject collidedObject;
    public GameObject player;
    public string binItem;

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
        //If the collsion object is a rubbish type which is grabbable
        if (collision.gameObject.tag.Equals("Grabbable"))
        {
            CharacterController character = player.GetComponent<CharacterController>();
            GrabObject grabObject = player.GetComponent<GrabObject>();
            //Set player isGrabbed to false
            grabObject.SetGrabbed(false);
            collidedObject = collision.gameObject;
            if (CheckRubbish())
            {
                //Add point counter
            }
            else
            {
                // Character loses health due to wrong rubbish placement
                character.LoseHealth();
            }
            DestroyRubbish();

        }
    }
}
