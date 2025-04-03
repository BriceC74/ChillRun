using UnityEngine;


/// <summary>
/// Manages the player's movement by alternating arrow key presses.
/// </summary>
public class PlayerMovementAlternateArrows : MonoBehaviour
{
    [SerializeField] float speedIncrement = 1f;
    private KeyCode lastKeyPressed;
    private FollowTrack followTrack;

    void Start()
    {
        followTrack = GetComponent<FollowTrack>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && lastKeyPressed != KeyCode.LeftArrow)
        {
            followTrack.SetSpeed(followTrack.GetActualPlayerSpeed() + speedIncrement);
            lastKeyPressed = KeyCode.LeftArrow;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && lastKeyPressed != KeyCode.RightArrow)
        {
            followTrack.SetSpeed(followTrack.GetActualPlayerSpeed() + speedIncrement);
            lastKeyPressed = KeyCode.RightArrow;
        }
    }
}
