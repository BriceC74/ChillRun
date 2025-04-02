using UnityEngine;


/// <summary>
/// Manages the player's movement by alternating arrow key presses.
/// </summary>
public class PlayerMovementAlternateArrows : MonoBehaviour
{

    [SerializeField] float speed = 1f;
    [SerializeField] float maxSpeed = 10f;
    Rigidbody rb;
    KeyCode lastKeyPressed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float actualSpeed = rb.linearVelocity.magnitude;
        if (actualSpeed > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            return;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && lastKeyPressed != KeyCode.LeftArrow)
        {
            rb.linearVelocity += Vector3.forward * speed;
            lastKeyPressed = KeyCode.LeftArrow;
        }
        if (Input.GetKey(KeyCode.RightArrow) && lastKeyPressed != KeyCode.RightArrow)
        {
            rb.linearVelocity += Vector3.forward * speed;
            lastKeyPressed = KeyCode.RightArrow;
        }
    }
}
