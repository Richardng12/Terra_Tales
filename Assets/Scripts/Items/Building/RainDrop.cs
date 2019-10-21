using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDrop : MonoBehaviour
{
    
    // splash properties for cosmetic effect
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
        // if the rain drop has splashed, stop falling
        if (!hasSplashed) {
            transform.Translate(0f, -0.05f, 0f);
        }    

        if (transform.position.y < -5) {
            Destroy(gameObject);
        }
    }

    // method defines which objects will cause the rain drops to splash upon collision
    private void OnTriggerEnter2D(Collider2D collision) {
        CharacterController character = collision.gameObject.GetComponent<CharacterController>();
        if (!collision.gameObject.tag.Equals("Cloud") && !collision.gameObject.tag.Equals("City") && !collision.gameObject.tag.Equals("RubberBoots")) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = splash;
            StartCoroutine(waitForSplash());
            
            // if collision with character, take damage too
            if (character != null && !hasSplashed) {
                character.LoseHealth();
            }
            hasSplashed = true;
        }
        if (collision.CompareTag("Boundary"))
        {
            hasSplashed = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = splash;
            StartCoroutine(waitForSplash());
        }
    }

    // allow splash effect to linger for a second
    IEnumerator waitForSplash() {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
