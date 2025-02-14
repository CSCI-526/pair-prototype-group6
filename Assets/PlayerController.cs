using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float inputDelay = 0.5f;  // Delay time for inputs

    private Rigidbody2D rb;
    private bool isGrounded;

    // For delayed input processing
    private float delayedHorizontalInput = 0f;
    private bool isDelayedZone = false;
    private Coroutine horizontalDelayCoroutine;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDelayedZone)
        {
            // When in the delayed zone, start a delayed jump coroutine on jump key press.
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                StartCoroutine(DelayedJump());
            }
        }
        else
        {
            // Normal jump processing when not in a delay zone.
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }
        }
    }

    void FixedUpdate()
    {
        if (isDelayedZone)
        {
            // Apply the buffered horizontal input.
            rb.velocity = new Vector2(delayedHorizontalInput * moveSpeed, rb.velocity.y);
        }
        else
        {
            // Normal horizontal movement.
            float moveInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DelayZone"))
        {
            isDelayedZone = true;
            // Start processing horizontal input with delay.
            if (horizontalDelayCoroutine == null)
            {
                horizontalDelayCoroutine = StartCoroutine(HandleHorizontalInputDelay());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("DelayZone"))
        {
            isDelayedZone = false;
            // Stop the horizontal input delay coroutine.
            if (horizontalDelayCoroutine != null)
            {
                StopCoroutine(horizontalDelayCoroutine);
                horizontalDelayCoroutine = null;
            }
            // Reset buffered input.
            delayedHorizontalInput = 0f;
        }
    }

    // This coroutine repeatedly samples the horizontal input,
    // waits for the delay, then updates the buffered value.
    IEnumerator HandleHorizontalInputDelay()
    {
        while (isDelayedZone)
        {
            float realInput = Input.GetAxisRaw("Horizontal");
            yield return new WaitForSeconds(inputDelay);
            delayedHorizontalInput = realInput;
        }
    }

    // This coroutine handles jump input delay.
    IEnumerator DelayedJump()
    {
        yield return new WaitForSeconds(inputDelay);
        // Check if still in delayed zone and on the ground before jumping.
        if (isDelayedZone && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
