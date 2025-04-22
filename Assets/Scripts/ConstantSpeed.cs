using UnityEngine;

/// <summary>
/// Manages the player's movement by alternating arrow key presses.
/// </summary>
public class ConstantSpeed : MonoBehaviour
{
    [SerializeField] float speedIncrement = 1f;
    private FollowTrack followTrack;

    void Start()
    {
        followTrack = GetComponent<FollowTrack>();
    }

    void FixedUpdate()
    {
        float newSpeed = followTrack.GetActualPlayerSpeed() + speedIncrement;
        followTrack.SetSpeed(Mathf.Min(newSpeed, followTrack.GetMaxSpeed()));
    }
}
