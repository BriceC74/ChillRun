using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

/// <summary>
/// Manages camera visual effects based on player and enemy progress along their tracks.
/// </summary>
public class CameraVFX : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] FollowTrack playerTrack;
    [SerializeField] Transform ennemyTransform;
    [SerializeField] FollowTrack ennemyTrack;
    [SerializeField] Volume globalVolume;
    [SerializeField] float deltaVignetteLength = 5f;
    [SerializeField] float deltaLensDistortionLength = 2f;

    private Vignette vignette;
    private LensDistortion lensDistortion;

    /// <summary>
    /// Initializes the camera visual effects.
    /// </summary>
    void Start()
    {
        if (globalVolume.profile.TryGet(out vignette))
        {
            vignette.intensity.value = 0;
        }

        if (globalVolume.profile.TryGet(out lensDistortion))
        {
            lensDistortion.intensity.value = 0;
        }
    }

    /// <summary>
    /// Updates the camera visual effects based on player and enemy progress.
    /// </summary>
    void FixedUpdate()
    {
        if (vignette != null)
        {
            float playerProgress = playerTrack.GetProgressPercentage();
            float ennemyProgress = ennemyTrack.GetProgressPercentage();

            if (ennemyProgress > playerProgress)
            {
                float progressDifference = ennemyProgress - playerProgress;
                float vignetteIntensity = Mathf.Clamp(progressDifference / deltaVignetteLength, 0f, 0.5f);
                vignette.intensity.value = vignetteIntensity;

                if (progressDifference >= deltaLensDistortionLength && progressDifference <= deltaLensDistortionLength + 5f)
                {
                    float lensDistortionIntensity = Mathf.Lerp(0, -1, (progressDifference - deltaLensDistortionLength) / 5f);
                    lensDistortion.intensity.value = lensDistortionIntensity;
                }
                else
                {
                    lensDistortion.intensity.value = 0;
                }
            }
            else
            {
                vignette.intensity.value = 0;
                lensDistortion.intensity.value = 0;
            }
        }
    }
}