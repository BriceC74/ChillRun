using System;
using UnityEngine;

/// <summary>
/// Manages the player's movement by alternating arrow key presses.
/// </summary>
public class ConstantSpeed : MonoBehaviour
{
    private DateTime endTime;
    private bool shouldResetMaxSpeed = false;
    [SerializeField] private float speedIncrement = 1f;
    private FollowTrack followTrack;

    public Transform playerPosition;

    private float initialMaxSpeed;

    /// <summary>
    /// Initializes the component and subscribes to the race start event.
    /// </summary>
    void Start()
    {
        followTrack = GetComponent<FollowTrack>();
        initialMaxSpeed = followTrack.GetMaxSpeed();

        StartRace startRace = FindFirstObjectByType<StartRace>();
        if (startRace != null)
        {
            startRace.OnRaceStart += OnRaceStart;
        }
        else
        {
            Debug.LogError("StartRace component not found in the scene.");
        }

        enabled = false;
    }

    /// <summary>
    /// Updates the player's speed and max speed based on proximity to the player position.
    /// </summary>
    void FixedUpdate()
    {
        float newSpeed = followTrack.GetActualPlayerSpeed() + speedIncrement;
        followTrack.SetSpeed(Mathf.Min(newSpeed, followTrack.GetMaxSpeed()));

        Vector3 delta = transform.position - playerPosition.position;
        if (delta.x < 1 && delta.y < 1 && delta.z < 1)
        {
            followTrack.SetMaxSpeed(followTrack.GetMaxSpeed() + 0.1f);

            endTime = DateTime.Now.AddSeconds(2);
            shouldResetMaxSpeed = true;
        }
        if (endTime <= DateTime.Now && shouldResetMaxSpeed)
        {
            followTrack.SetMaxSpeed(initialMaxSpeed);
            shouldResetMaxSpeed = false;
        }
    }

    /// <summary>
    /// Enables the component when the race starts.
    /// </summary>
    private void OnRaceStart()
    {
        enabled = true;
    }
}