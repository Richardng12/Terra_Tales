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
        if (collision.gameObject.name.Equals("Player"))
        {
            hasSplashed = true;
            Debug.Log("take rain dmg");
            this.gameObject.GetComponent<SpriteRenderer>().sprite = splash;
            waitForCD();
        }
    }
    IEnumerator waitForCD() {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
