using UnityEngine;

/// <summary>
/// Makes the camera look at both the player and the enemy, adjusting its position and orientation.
/// </summary>
public class LookAtPlayerAndEnnemy : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 baseOffsetPosition = new Vector3(-3, 3, -5);
    [SerializeField] private Transform ennemyTransform;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private float heightMultiplier = 0.5f;

    /// <summary>
    /// Updates the camera's position and orientation to look at both the player and the enemy.
    /// </summary>
    void FixedUpdate()
    {
        if (playerTransform != null && ennemyTransform != null)
        {
            Vector3 midPoint = (playerTransform.position + ennemyTransform.position) / 2;

            float distance = Vector3.Distance(playerTransform.position, ennemyTransform.position);

            Vector3 offsetPosition = baseOffsetPosition + new Vector3(0, distance * heightMultiplier, 0);

            Vector3 targetPosition = midPoint + offsetPosition;

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

            Vector3 direction = midPoint - transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, smoothSpeed);
        }
    }
}