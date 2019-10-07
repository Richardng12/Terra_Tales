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
        Invoke("DestroyWaterBubble", time);
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * waterSpeed;

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // ICharacter fire = collision.gameObject.GetComponent<ICharacter>();
        // if (fire != null)
        // {
        //     fire.LoseHealth();
        //     Destroy(this.gameObject);
        // }
        if (!collision.gameObject.tag.Equals("Obstacles") && !collision.gameObject.tag.Equals("Items") && (!collision.gameObject.tag.Equals("Grabbable")))
        {
            Destroy(this.gameObject);
        }

    }

    private void DestroyWaterBubble(){
        Destroy(this.gameObject);
    }
}
