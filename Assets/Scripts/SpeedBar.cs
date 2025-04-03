using UnityEngine;
using UnityEngine.UI;

public class SpeedBar : MonoBehaviour
{
    [SerializeField] FollowTrack followTrack;
    [SerializeField] Image speedBar;
    [SerializeField] Image speedBarBackground;

    void Update()
    {
        if (followTrack != null && speedBar != null && speedBarBackground != null)
        {
            float currentSpeed = followTrack.GetActualPlayerSpeed();
            float maxSpeed = followTrack.GetMaxSpeed();

            float fillAmount = Mathf.Clamp01(currentSpeed / maxSpeed);

            Debug.Log("currentSpeed: " + currentSpeed);
            Debug.Log("maxSpeed: " + maxSpeed);
            Debug.Log("fillAmount: " + fillAmount);

            speedBar.fillAmount = fillAmount;
        }
        else
        {
            Debug.LogError("One or more references are not assigned.");
        }
    }
}
