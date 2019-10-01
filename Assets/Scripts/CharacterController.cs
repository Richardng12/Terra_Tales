using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public float speed;
    private bool facingRight = true;

    private bool onGround;
    public Transform groundCheck;
    private float radiusCheck;
    public LayerMask whatIsGround;
    public bool hasWep = false;

    private Rigidbody2D rb;
    public Transform player;
    public Transform direction;
    public GameObject waterBubblePrefab;

    private int jumps = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Water Gun")){
            hasWep = true; 
        }
    }
    // Shoots water
    public void ShootWaterGun(){
        Debug.Log(true);
        if(hasWep){
            Instantiate(waterBubblePrefab, direction.position, direction.rotation);

        }
    }

    private void FixedUpdate()
    {
        // Checks if grounded
        onGround = Physics2D.OverlapCircle(groundCheck.position,radiusCheck,whatIsGround);
    }

    // Method to move the player
    public void Move(float moveInput)
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // If moving right and facing left then need to flip the image
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        // if moving left and facing right need to flip image back
        else if (facingRight && moveInput < 0)
        {
            Flip();

        }

    }

    // Method to jump
    public void Jump(bool keyPressed, float jumpSpeed){
        Debug.Log(jumps);
        if(keyPressed){

            if (jumps == 0)
            {
                return;
            }
            else if (jumps > 0)
            {
                jumps--;
                rb.velocity = Vector2.up * jumpSpeed;
            }
        }

    }

    // Checks if the jumps should reset
    private void Update()
    {
        if (onGround)
        {
            jumps = 1;
        }
    }

    private void Flip()
    {
        // Switches the player position
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        //Vector3 scale = transform.localScale;
        //scale.x *= -1;
        //transform.localScale = scale;
        player.Rotate(0f, 180f, 0f);
    }

    public Rigidbody2D GetRigidbody(){
        return rb;
    }
}
