using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour, ICharacter
{

    private bool facingRight = true;

    private bool onGround = true;
    public Transform groundCheck;
    public float radiusCheck;
    public LayerMask whatIsGround;
    public int health = 5;

    public Transform direction;

    private Rigidbody2D rb;
    public Transform player;
    public Animator move;

    private bool canDoubleJump = true;
    private bool firstJump = true;
    bool isInVuln = false;
    float timeBeenInvulnerable = 0;
    readonly float inVulnerableTimer = 2;
    Renderer renderer;
    Color c;

    //City scene
    string jumpSound = "Jump";

    AudioManager audioManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        audioManager = AudioManager.instance;
        Time.timeScale = 1f;
        renderer = GetComponent<Renderer>();
        c = renderer.material.color;


    }

    private void OnEnable()
    {
        Publisher.StartListening("IncreasePlayerHealth", IncreaseHealth);
    }

    private void OnDisable()
    {
        Publisher.StopListening("IncreasePlayerHealth", IncreaseHealth);
    }
    // Collision 2D

    // Checks if the character is invulnerable and changes the renderer colour
    // to show the player that it is invulnerable
    private void CheckInvulnerability()
    {
        if (timeBeenInvulnerable >= inVulnerableTimer)
        {
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
    // Also checks for animation frames
    private void Update()
    {

        if (onGround && !canDoubleJump)
        {
            firstJump = true;
        }
        // Checks invulnerability if player is invulnerable
        if (isInVuln)
        {
            CheckInvulnerability();
        }

    
    
          
    }
    private void FixedUpdate()
    {
        // Checks if grounded
        onGround = Physics2D.OverlapCircle(groundCheck.position, radiusCheck, whatIsGround);

    }
    // Character loses health if not invulnerable
    public void LoseHealth()
    {
        // If character isnt invulnerable
        if (!isInVuln)
        {
            if (health >= 1)
            {
                health--;
                isInVuln = true;
            }
        }
    }

    public void IncreaseHealth()
    {
        if(health != 5)
        {
            health++;
        }
    }

    public bool OnGround()
    {
        return onGround;
    }



    // Method to move the player
    public void Move(float moveInput, float speed)
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
    public bool Jump(bool keyPressed, float jumpSpeed)
    {
        if (keyPressed)
        {
            if (onGround || firstJump)
            {
                audioManager.Play(jumpSound);
                rb.velocity = Vector2.up * jumpSpeed;
                canDoubleJump = true;
                firstJump = false;
                return true;
            }
            else
            {
                if (canDoubleJump)
                {
                    // Plays the jump sound
                    audioManager.Play(jumpSound);
                    rb.velocity = Vector2.up * jumpSpeed;
                    canDoubleJump = false;
                    return true;
                }
            }
        }
        return false;

    }

    private void Flip()
    {
        // Switches the player position
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1 to flip the player
        Vector3 scale = player.localScale;
        scale.x *= -1;
        player.localScale = scale;
        direction.Rotate(0f, 180f, 0f);

    }

    public Rigidbody2D GetRigidbody()
    {
        return rb;
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }

   
}
