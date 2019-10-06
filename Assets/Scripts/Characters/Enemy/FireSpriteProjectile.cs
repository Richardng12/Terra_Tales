using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpriteProjectile : MonoBehaviour
{
     
    private CharacterController player;
    private Vector3 target;
    //Speed of the bullet
    public float speed;

    private Rigidbody2D rb;

    private float time = 3f;

    void Start() { 
        Invoke("DestroyFireProjectile", time);
        //rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
            //Invoke("DestroyFireProjectile", time);
        target = player.transform.position - transform.position;
        target.z = 0;
        target.Normalize();
     
    }

    void Update() {
            //rb.velocity = transform.right * speed;
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
            Destroy(this.gameObject);
        }
    }





    private void DestroyFireProjectile(){
        Debug.Log("Destroyed");
        Destroy(this.gameObject);
    }
    
    

}
