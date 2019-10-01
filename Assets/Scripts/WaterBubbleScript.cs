using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBubbleScript : MonoBehaviour
{
    public float waterSpeed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private float time = 1.5f;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }

    private void DestroyWaterBubble(){
        Destroy(this.gameObject);
    }
}
