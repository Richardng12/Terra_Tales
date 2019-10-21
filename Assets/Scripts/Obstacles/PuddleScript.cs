using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleScript : MonoBehaviour
{
    private bool inPuddle = false;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(regen());
    }

    //Make the water puddle regenerate over time
    IEnumerator regen()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            if (gameObject.transform.localScale.x < 4)
            {
                gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0);
            }
        }
    }
    // Update to poll for if the user is in the puddle, and if his ammo isnt full, increment his water ammo
    void Update()
    {
        if (inPuddle)
        {
            player = GameObject.FindWithTag("Player");
            float time = Time.deltaTime;
            if (gameObject.transform.localScale.x > 0 && !player.GetComponent<ShootWater>().isFull())
            {
                gameObject.transform.localScale -= new Vector3(time, time, 0);
                player.GetComponent<ShootWater>().ReloadWaterGun();

            }
        }
    }

    //Check if player is in puddle
    private void OnTriggerEnter2D(Collider2D collision)
    {
            Debug.Log("In pudddle not player");

        if (collision.gameObject.tag.Equals("Player"))
        {
            inPuddle = true;
            Debug.Log("In pudddle");

        }
    }

    //When player exits puddle, set inPuddle to false
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag.Equals("Player"))
        {
            inPuddle = false;
        }
    }
}
