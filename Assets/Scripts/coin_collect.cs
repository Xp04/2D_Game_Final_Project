using UnityEngine;

public class coin_collect : MonoBehaviour
{
    public ParticleSystem collectParticles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //Finds the player tag
        {
            if (collectParticles != null)
            {
                collectParticles.transform.parent = null; //Take particles out from coin, to make them last longer
                collectParticles.Play();
                Destroy(collectParticles.gameObject, collectParticles.main.duration); //Cleans up the particles for smoother disperse
            }

            Destroy(gameObject); //Dstroys the coin
        }
    }
}



