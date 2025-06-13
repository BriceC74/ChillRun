using UnityEngine;

/// <summary>
/// Manages the player's movement by alternating arrow key presses.
/// </summary>
public class PlayerMovementAlternateArrows : MonoBehaviour
{
    [SerializeField] private float speedIncrement = 1f;
    private KeyCode lastKeyPressed;
    private FollowTrack followTrack;

    /// <summary>
    /// Initializes the component and subscribes to the race start event.
    /// </summary>
    void Start()
    {
        followTrack = GetComponent<FollowTrack>();

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
    /// Updates the player's speed based on arrow key presses.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && lastKeyPressed != KeyCode.LeftArrow)
        {
            float newSpeed = followTrack.GetActualPlayerSpeed() + speedIncrement;
            followTrack.SetSpeed(Mathf.Min(newSpeed, followTrack.GetMaxSpeed()));
            lastKeyPressed = KeyCode.LeftArrow;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && lastKeyPressed != KeyCode.RightArrow)
        {
            float newSpeed = followTrack.GetActualPlayerSpeed() + speedIncrement;
            followTrack.SetSpeed(Mathf.Min(newSpeed, followTrack.GetMaxSpeed()));
            lastKeyPressed = KeyCode.RightArrow;
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