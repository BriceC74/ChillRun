using System;
using TMPro;
using UnityEngine;

/// <summary>
/// Manages the player's movement by alternating arrow key presses.
/// </summary>
public class ConstantSpeed : MonoBehaviour
{
    DateTime endTime;
    bool shouldResetMaxSpeed = false;
    [SerializeField] float speedIncrement = 1f;
    private FollowTrack followTrack;

    public Transform playerPosition;

    float initialMaxSpeed;

    void Start()
    {
        followTrack = GetComponent<FollowTrack>();
        initialMaxSpeed = followTrack.GetMaxSpeed();

        // Subscribe to the OnRaceStart event
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

    private void OnRaceStart()
    {
        enabled = true;
    }
}
