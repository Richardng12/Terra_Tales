using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public float speed;
    private float moveInput;
    private bool facingRight = true;

    private bool onGround;
    public Transform groundCheck;
    private float radiusCheck;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;

    private int extraJumps = 1;
    public float jumpVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        // Gets the movement in the certain direction
        moveInput = Input.GetAxis("Horizontal");
        // assoicates velocity of the rigidbody with the velocity and the prev movement
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Checks if grounded
        onGround = Physics2D.OverlapCircle(groundCheck.position,radiusCheck,whatIsGround);
        // If moving right and facing left then need to flip the image
        if(facingRight == false && moveInput > 0){
            Flip();
        }
        // if moving left and facing right need to flip image back
        else if(facingRight && moveInput < 0){
            Flip();

        }

    }
    private void Update()
    {
         
        if (onGround)
        {
            extraJumps = 1;
        }

        if (extraJumps == 0)
        {
            return;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0){
            extraJumps--;
            rb.velocity = Vector2.up * jumpVelocity;
        }
       

    }

    private void Flip()
    {
        // Switches the player position
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
