using UnityEngine;

public class bomb_behavior : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground")) 
        {
            //Destroy(gameObject);      //This was for my other game where the bombs would de-spawn when they hit the floor
        }
    }
}
