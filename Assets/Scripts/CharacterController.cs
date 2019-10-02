using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    private bool facingRight = true;

    private bool onGround = true;
    public Transform groundCheck;
    public float radiusCheck;
    public LayerMask whatIsGround;
    bool hasWep = false;
    public int health = 5;

    private Rigidbody2D rb;
    public Transform player;
    public Transform direction;
    public GameObject waterBubblePrefab;
    public Animator move;

    public float rateOfFire;
    float timeToFire = 0;

    private int jumps = 1;

    bool isInVuln = false;
    float timeBeenInvulnerable = 0;
    readonly float inVulnerableTimer = 1;
    Renderer renderer;
    Color c ;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<Renderer>();
        c = renderer.material.color;


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Water Gun")){
            hasWep = true; 
        }
    }
    private void CheckInvulnerability() {
        if (timeBeenInvulnerable >= 2) {
            c.a = 1f;
            renderer.material.color = c;
            isInVuln = false;
            timeBeenInvulnerable = 0;
          }
        else
        {
            timeBeenInvulnerable = timeBeenInvulnerable + Time.deltaTime;
            c.a = 0.5f;
            renderer.material.color = c;
        }


    }

    // Checks if the jumps should reset
    private void Update()
    {
        if (onGround)
        {
            jumps = 1;
        }
        if (!Input.GetButton("Horizontal"))
        {
            move.SetBool("Moving", false);
        }
        if (!Input.GetButton("Jump"))
        {
            move.SetBool("Jumping", false);
        }
        // Checks invulnerability if player is invulnerable
        Debug.Log(health);
        if (isInVuln)
         {
            Debug.Log("INVULNERABLE");
            CheckInvulnerability();
         }
        else
        {
            Debug.Log("NOT INVULNERABLE");

        }
    }
    private void FixedUpdate()
    {
        // Checks if grounded
        onGround = Physics2D.OverlapCircle(groundCheck.position,radiusCheck,whatIsGround);

    }
    public void LoseHealth()
    {
        // If character isnt invulnerable
        if (!isInVuln)
        {
            if (health > 0)
            {
                health--;
                isInVuln = true;
            }
            else
            {
                health = 5;
            }
        }
    }

    // Shoots water gun  by instantianting a waterBubble object
    // dependent on couple of variables
    public void CheckFireRate()
    {
        if (hasWep)
        {
            if (rateOfFire == 0)
            {
                Shoot();
            }
            else
            {
                if (Time.time > timeToFire){
                    timeToFire = Time.time + 1 / rateOfFire;
                    Shoot();
                    }
                }
        }
    }
    private void Shoot()
    {
        Instantiate(waterBubblePrefab, direction.position, direction.rotation);
    }

    // Method to move the player
    public void Move(float moveInput, float speed)
    {
        move.SetBool("Moving", true);
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
        if (keyPressed){
            if (jumps == 0)
            {
                return;
            }
            else if (jumps > 0)
            {
                move.SetBool("Jumping", true);
                jumps--;
                rb.velocity = Vector2.up * jumpSpeed;
            }

        }

    }

    private void Flip()
    {
        // Switches the player position
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 scale = player.localScale;
        scale.x *= -1;
        player.localScale = scale;
        direction.Rotate(0f, 180f, 0f); 

    }

    public Rigidbody2D GetRigidbody(){
        return rb;
    }
}
