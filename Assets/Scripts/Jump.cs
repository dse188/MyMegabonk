using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Jump Settings")]
    [SerializeField] float jumpForce;
    [SerializeField] int maxJumps;  // Will be moved to player stats later
    [SerializeField] float cayoteTime;

    [Header("Ground Check")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundRadius;
    [SerializeField] LayerMask groundMask;

    Rigidbody rb;
    PlayerInputHandler input;

    int jumpsRemaining;
    bool wasGrounded;
    float lastGroundedTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInputHandler>();
        jumpsRemaining = maxJumps;
    }

    private void Update()
    {
        bool grounded = IsGrounded();

        if (grounded)
        {
            lastGroundedTime = Time.time;


            // Reset jumps when you land
            if (!wasGrounded)
                jumpsRemaining = maxJumps;
        }

        if (input.JumpTriggered && CanJump(grounded))
        {
            DoJump();
            input.ConsumeJump();
        }

        wasGrounded = grounded;
    }

    bool CanJump(bool grounded)
    {
        bool withinCayote = Time.time - lastGroundedTime <= cayoteTime;
        return jumpsRemaining > 0 && (grounded || withinCayote || jumpsRemaining < maxJumps);
    }

    void DoJump()
    {
        // Consume the press so holding doesn't spam (since input sets JumpPressed true while held)
        input.GetType();

        Vector3 v = rb.linearVelocity;
        if (v.y < 0f) v.y = 0f;
        rb.linearVelocity = v;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        jumpsRemaining--;
    }

    bool IsGrounded()
    {
        Vector3 pos = groundCheck ? groundCheck.position : transform.position;
        return Physics.CheckSphere(pos, groundRadius, groundMask, QueryTriggerInteraction.Ignore);
    }

    // Call this later from stats to change jump count dynamically
    public void SetMaxJumps(int value)
    {
        maxJumps = Mathf.Max(1, value);
        jumpsRemaining = Mathf.Min(jumpsRemaining, maxJumps);
    }
}
