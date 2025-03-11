using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour
{
    // Movement variables
    [SerializeField] private float moveSpeed = 5f;           // horizontal movement speed       
    [SerializeField] private float jumpForce = 10f;          // jump strength
    [SerializeField] private float groundCheckRadius = 0.2f; // radius for ground check
    //SerializedField keeps the variable as pricate in the code but allows it to be edited in the engine

    // Dash variables
    [SerializeField] private float dashSpeed = 15f;      // Speed during dash (higher than normal speed)
    [SerializeField] private float dashDuration = 0.2f;  // How long the dash lasts (in seconds)
    [SerializeField] private float dashCooldown = 1f;    // Time before the player can dash again
    private bool isDashing = false;   // Tracks whether the player is currently dashing
    private bool canDash = true;      // Tracks if the player is allowed to dash

    // Components
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    // Ground check
    [SerializeField] private LayerMask groundLayer;          // layer for ground objects
    [SerializeField] private Transform groundCheck;          // position to check if grounded

    // State tracking
    private bool isGrounded;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Left Shift Pressed!");
        }
        // flips player sprite
        if (moveInput > 0)
            spriteRenderer.flipX = false;
        else if (moveInput < 0)
            spriteRenderer.flipX = true;

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && moveInput != 0)
        {
            Debug.Log("Dash key pressed!");
            StartCoroutine(Dash());
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);     // checks if the player is grounded
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);                    // horizontal movement
        Debug.Log("Current Speed: " + moveSpeed);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private IEnumerator Dash()
    {
        Debug.Log("Dash started!");
        canDash = false; // Prevent dashing again immediately
        isDashing = true; // Set dashing state

        float originalSpeed = moveSpeed; // Save the player's normal speed
        moveSpeed = dashSpeed; // Temporarily increase speed

        yield return new WaitForSeconds(dashDuration); // Wait for dash to finish

        moveSpeed = originalSpeed; // Restore normal speed
        isDashing = false; // End dash

        Debug.Log("Dash ended!");

        yield return new WaitForSeconds(dashCooldown); // Wait for cooldown
        canDash = true; // Allow dashing again
    }
}