using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    // LateUpdate is called once per frame, after all Update methods have been called
    void LateUpdate()
    {
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
