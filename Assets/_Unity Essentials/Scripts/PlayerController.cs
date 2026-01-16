using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Moves forward/backward and rotates with WASD/Arrow keys.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Tooltip("Forward/back speed (units/sec).")]
    public float speed = 5f;

    [Tooltip("Turn speed (degrees/sec).")]
    public float rotationSpeed = 120f;

    [Tooltip("Jump force.")]
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // prevent tipping over
    }

    private void Update()
    {
        // Jump (New Input System)
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        Vector2 moveInput = Vector2.zero;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            moveInput.y = 1f;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            moveInput.y = -1f;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            moveInput.x = -1f;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            moveInput.x = 1f;

        // Movement
        Vector3 movement = transform.forward * moveInput.y * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        // Rotation
        float turnDirection = moveInput.y < 0 ? -moveInput.x : moveInput.x;
        float turn = turnDirection * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        rb.MoveRotation(rb.rotation * turnRotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
            isGrounded = true;
    }
}
