using UnityEngine;

/// <summary>
/// Makes the object attached to this script follow a target object with a specified offset and orientation.
/// </summary>
public class FollowTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offsetPosition = new Vector3(0, 1.5f, -2);
    void Update()
    {
        transform.position = target.position + offsetPosition;
        transform.LookAt(target);
    }
}
