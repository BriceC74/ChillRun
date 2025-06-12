using UnityEngine;

public class LookAtPlayerAndEnnemy : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Vector3 baseOffsetPosition = new Vector3(-3, 3, -5);
    [SerializeField] Transform ennemyTransform;
    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] float heightMultiplier = 0.5f;

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