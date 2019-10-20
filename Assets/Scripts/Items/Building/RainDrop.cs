using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDrop : MonoBehaviour
{
    public Sprite splash;

    private bool hasSplashed;
    // Start is called before the first frame update
    void Start()
    {
        hasSplashed = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if (!hasSplashed) {
            transform.Translate(0f, -0.05f, 0f);
        }    

        if (transform.position.y < -5) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        CharacterController character = collision.gameObject.GetComponent<CharacterController>();
        if (!collision.gameObject.tag.Equals("Cloud") && !collision.gameObject.tag.Equals("City") && !collision.gameObject.tag.Equals("RubberBoots")) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = splash;
            StartCoroutine(waitForSplash());
            if (character != null && !hasSplashed) {
                character.LoseHealth();
                Debug.Log("Take dmg");
            }
            hasSplashed = true;
        }
        if (collision.CompareTag("Boundary"))
        {
            hasSplashed = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = splash;
            StartCoroutine(waitForSplash());
        }
        // if (character != null);
        // {
        //     hasSplashed = true;
        //     character.LoseHealth();
        //     this.gameObject.GetComponent<SpriteRenderer>().sprite = splash;
        //     StartCoroutine(waitForSplash());
        // }
        // if (collision.gameObject.tag.Equals("WaterBullet")) {
        //     hasSplashed = true;
        //     this.gameObject.GetComponent<SpriteRenderer>().sprite = splash;
        //     StartCoroutine(waitForSplash());
        //     Debug.Log("HI");
        // }
    }

    IEnumerator waitForSplash() {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
