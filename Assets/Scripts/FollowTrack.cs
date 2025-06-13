using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;

/// <summary>
/// Manages the player's movement along a predefined spline track.
/// </summary>
public class FollowTrack : MonoBehaviour
{
    [SerializeField] SplineContainer track;
    [SerializeField] float speed = 1f;
    [SerializeField] float maxSpeed = 10f;
    [SerializeField] float deceleration = 0.1f;
    private float currentDistance = 0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (track == null)
        {
            Debug.LogError("Track SplineContainer is not assigned.");
            return;
        }

        currentDistance += speed * Time.fixedDeltaTime;
        if (currentDistance > track.CalculateLength())
        {
            currentDistance = track.CalculateLength();
        }

        float3 newPositionFloat3 = track.EvaluatePosition(currentDistance / track.CalculateLength());
        float3 directionFloat3 = track.EvaluateTangent(currentDistance / track.CalculateLength());

        Vector3 newPosition = new Vector3(newPositionFloat3.x, newPositionFloat3.y, newPositionFloat3.z);
        Vector3 direction = new Vector3(directionFloat3.x, directionFloat3.y, directionFloat3.z).normalized;

        newPosition.y = rb.position.y;

        rb.MovePosition(newPosition);
        rb.AddForce(direction * speed, ForceMode.Acceleration);

        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }

        if (!Input.anyKey)
        {
            speed = Mathf.Max(speed - deceleration * Time.fixedDeltaTime, 0f);
        }
    }

    /// <summary>
    /// Gets the current speed of the player based on the distance traveled along the spline.
    /// </summary>
    /// <returns>The current speed of the player.</returns>
    public float GetActualPlayerSpeed()
    {
        return speed;
    }

    /// <summary>
    /// Sets the speed of the player.
    /// </summary>
    /// <param name="newSpeed">The new speed to set.</param>
    public float GetMaxSpeed()
    {
        return maxSpeed;
    }

    public void SetMaxSpeed(float newMaxSpeed)
    {
        maxSpeed = newMaxSpeed;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    /// <summary>
    /// Gets the progress percentage of the player along the spline track.
    /// </summary>
    /// <returns>The progress percentage of the player along the spline track.</returns>
    public float GetProgressPercentage()
    {
        if (track == null)
        {
            Debug.LogError("Track SplineContainer is not assigned.");
            return 0f;
        }

        float totalLength = track.CalculateLength();
        float percentage = currentDistance / totalLength * 100f;
        return percentage;
    }
}