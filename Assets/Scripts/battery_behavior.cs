using UnityEngine;

public class Battery_behavior : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground")) 
        {
            //Destroy(gameObject);          //This was for my other game where the batteries would de-spawn when they hit the floor
        }
    }
}
