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
            sound_manager.Instance.PlaySound3D("Bomb", transform.position); // Plays random sound effect from group of clips
            life_counter.instance.subLife();
        }
        /*
        if (collision.gameObject.CompareTag("power_up"))
        {
            Destroy(collision.gameObject);
            score_manager.instance.addPoints();
        }
         */
        
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            sound_manager.Instance.PlaySound3D("Coin", transform.position);
            life_counter.instance.addPoints(); //Adds points to the counter once coin is collected
        }

        if (collision.gameObject.CompareTag("Mace"))
        {
            sound_manager.Instance.PlaySound3D("Mace", transform.position);
            life_counter.instance.subLife(); //Deducts from the life counter once player comes into contact with "Mace"
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pit"))
        {
            sound_manager.Instance.PlaySound3D("Fall", transform.position);
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
