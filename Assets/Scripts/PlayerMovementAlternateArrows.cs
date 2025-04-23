using UnityEngine;

public class PlayerMovementAlternateArrows : MonoBehaviour
{
    [SerializeField] float speedIncrement = 1f;
    private KeyCode lastKeyPressed;
    private FollowTrack followTrack;

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

    private void OnRaceStart()
    {
        enabled = true;
    }
}
