using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDrop : MonoBehaviour
{
    public Sprite splash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, -0.05f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("take rain dmg");
            this.gameObject.GetComponent<SpriteRenderer>().sprite = splash;
            Destroy(gameObject);
        }
    }
}
