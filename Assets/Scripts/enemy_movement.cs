using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDistance = 3f;

    private Vector3 startPos;
    private bool movingRight = true;


    void Start()
    {
        startPos = transform.position;
    }

    
    void Update()
    {
        float movement = moveSpeed * Time.deltaTime;

        if (movingRight)
        {
            transform.Translate(Vector2.right * movement);

            if (transform.position.x >= startPos.x + moveDistance)
            {
                movingRight = false;
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else
        {
            transform.Translate(Vector2.left * movement);

            if (transform.position.x <= startPos.x - moveDistance)
            {
                movingRight = true;
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}
