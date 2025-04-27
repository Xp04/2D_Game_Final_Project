using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class update_player : MonoBehaviour    //player_dead
{
    private Vector2 startPosition;
    private Vector2 lastCheckpointPosition;
    
    // used to show/hide the checkpoint box
    public GameObject box;

    private void Start()
    {
        startPosition = transform.position;
        lastCheckpointPosition = startPosition;
        box.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bomb_enemy"))
        {
            //Destroy(this.gameObject);   // Just destroys the robot instantly
            Destroy(collision.gameObject);
            sound_manager.Instance.PlaySound3D("Bomb", transform.position); // Plays random sound effect from group of clips
            life_counter.instance.subLife();
        }

        if (collision.gameObject.CompareTag("power_up"))
        {
            Destroy(collision.gameObject);
            sound_manager.Instance.PlaySound3D("Life", transform.position);
            life_counter.instance.addLife();
        }
        
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

        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            checkpoint_tracker checkpoint = collision.gameObject.GetComponent<checkpoint_tracker>();
            // if this is the player's first time reaching the checkpoint...
            if (checkpoint != null && !checkpoint.activated)
            {
                box.SetActive(true); // show checkpoint box
                checkpoint.activated = true;
                lastCheckpointPosition = collision.transform.position;
                sound_manager.Instance.PlaySound3D("Checkpoint", transform.position);
            }
        }

        if (collision.gameObject.CompareTag("DialogueTrigger"))
        {  
            dialogue_trigger trigger = collision.gameObject.GetComponent<dialogue_trigger>();

            if (trigger != null)
            {
                trigger.TriggerDialogue();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            box.SetActive(false); // hide checkpoint box when leaving checkpoint area
        }
    }

    void Respawn()
    {
        transform.position = lastCheckpointPosition;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }
        
}
