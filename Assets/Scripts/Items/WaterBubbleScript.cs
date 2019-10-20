using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBubbleScript : MonoBehaviour
{
    public float waterSpeed = 130.0f;
    private Rigidbody2D rb;
    private float time = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // Destroys water bubble after a certain time
        Invoke("DestroyWaterBubble", time);
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Gives teh waterbubble a velocity when shot
        rb.velocity = transform.right * waterSpeed;

    }
    // Checks types of collisions of the water bubble from the water gun
    void OnTriggerEnter2D(Collider2D collision)
    {
        // If there is a character hit the character loses health and destroys
        // the water bubble 
        ICharacter enemy= collision.gameObject.GetComponent<ICharacter>();
        if (enemy != null)
        {
            enemy.LoseHealth();
            Destroy(this.gameObject);
        }
        // This lets the water bubble travel through obstacles items and 
        // grabbable objects

        if (!collision.gameObject.tag.Equals("Obstacles") && 
        !collision.gameObject.tag.Equals("Items") &&
             !collision.gameObject.tag.Equals("Grabbable") && !collision.gameObject.tag.Equals("City") && 
             !collision.gameObject.tag.Equals("RubberBoots"))
        {
            Destroy(this.gameObject);
        }

    }

    private void DestroyWaterBubble(){
        Destroy(this.gameObject);
    }
}
