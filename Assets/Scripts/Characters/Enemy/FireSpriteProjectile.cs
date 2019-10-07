using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpriteProjectile : MonoBehaviour
{
     
     //Variables to reference player
    private CharacterController player;
    private Vector3 target;
    //Speed of the bullet
    public float speed;
    //Get reference to rigid body
    private Rigidbody2D rb;
    //Projectile travel distance
    private float time = 3f;

    void Start() { 
        //Invoke DestroyFireProjectile after the time has passed
        Invoke("DestroyFireProjectile", time);
        //Get reference to player
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        //Get vector 3 projectile target position
        target = player.transform.position - transform.position;
        target.z = 0;
        target.Normalize();
     
    }

    void Update() {
        //Move the projectile
        transform.position = transform.position + target * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other) {

        //Collision with the player
        if (other.CompareTag("Player")) {
            //Player loses health
            player.LoseHealth();
            //Destroy when collided
            Destroy(this.gameObject);
        } 

        if (other.CompareTag("Boundary"))
        {
            //Destroy when a boundary is hit
            Destroy(this.gameObject);
        }
    }

    //Method to destroy projectile
    private void DestroyFireProjectile(){
        Destroy(this.gameObject);
    }
    
    

}
