using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the speed bar UI element based on the player's speed.
/// </summary>
public class SpeedBar : MonoBehaviour
{
    [SerializeField] private FollowTrack followTrack;
    [SerializeField] private Image speedBar;
    [SerializeField] private Image speedBarBackground;

    /// <summary>
    /// Updates the speed bar UI based on the player's current speed.
    /// </summary>
    void FixedUpdate()
    {
        if (followTrack != null && speedBar != null && speedBarBackground != null)
        {
            float currentSpeed = followTrack.GetActualPlayerSpeed();
            float maxSpeed = followTrack.GetMaxSpeed();

            float fillAmount = Mathf.Clamp01(currentSpeed / maxSpeed);

            speedBar.fillAmount = fillAmount;
        }
        else
        {
            Debug.LogError("One or more references are not assigned.");
        }
    }
}