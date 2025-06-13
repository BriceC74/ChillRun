using UnityEngine;

/// <summary>
/// Manages the player's movement by alternating arrow key presses.
/// </summary>
public class PlayerMovementAlternateArrows : MonoBehaviour
{
    [SerializeField] private float speedIncrement = 1f;
    private KeyCode lastKeyPressed;
    private FollowTrack followTrack;
    private Material playerMaterial;

    /// <summary>
    /// Initializes the component and subscribes to the race start event.
    /// </summary>
    void Start()
    {
        followTrack = GetComponent<FollowTrack>();
        playerMaterial = GetComponent<Renderer>().material;

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
    /// Updates the player's speed based on arrow key presses and adjusts the Fresnel power.
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

        float currentSpeed = followTrack.GetActualPlayerSpeed();
        float minPower = 0.3f;
        float maxPower = 5f;
        float fresnelPower = Mathf.Max(minPower, maxPower - currentSpeed);
        playerMaterial.SetFloat("_fresnel_power", fresnelPower);
    }

    /// <summary>
    /// Enables the component when the race starts.
    /// </summary>
    private void OnRaceStart()
    {
        enabled = true;
    }
}