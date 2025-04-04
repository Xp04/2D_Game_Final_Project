using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour
{
    // Movement variables
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float groundCheckRadius = 0.2f;
    
    // Dash variables
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;
    private bool isDashing = false;
    private bool canDash = true;

    // Components
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Ground check
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    // State tracking
    private bool isGrounded;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(moveInput)); // Update speed animation

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && moveInput != 0)
        {
            StartCoroutine(Dash());
        }

        if (moveInput > 0)
            spriteRenderer.flipX = false;
        else if (moveInput < 0)
            spriteRenderer.flipX = true;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetBool("IsGrounded", isGrounded); // Update grounded state animation
        animator.SetBool("isJumping", !isGrounded); // Set Jump to true when not grounded
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        animator.SetTrigger("Jump"); // Trigger jump animation
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        animator.SetTrigger("Dash"); // Trigger dash animation

        float originalSpeed = moveSpeed;
        moveSpeed = dashSpeed;

        yield return new WaitForSeconds(dashDuration);

        moveSpeed = originalSpeed;
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
