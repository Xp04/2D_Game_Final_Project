using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class update_player : MonoBehaviour    //player_dead
{
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
}
