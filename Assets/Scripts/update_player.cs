using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class update_player : MonoBehaviour    //player_dead
{
    private Vector2 startPosition;
    private void Start()
    {
        startPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bomb_enemy"))
        {
            //Destroy(this.gameObject);     // Just destroys the robot instantly
            Destroy(collision.gameObject);
            life_counter.instance.subLife();
        }
        /*
         if (collision.gameObject.CompareTag("power_up"))
        {
            Destroy(collision.gameObject);
            score_manager.instance.addPoints();
        }
         */
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pit"))
        {
            life_counter.instance.subLife();
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = startPosition;  // Move to start position
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;  // Stop movement
    }
        
}
