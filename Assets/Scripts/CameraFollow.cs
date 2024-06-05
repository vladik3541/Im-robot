using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float smoothSpeed;
    [SerializeField] private Vector3 offSet;
    [SerializeField] private Transform target;
    private Vector3 velocity;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 direction = Vector3.SmoothDamp(transform.position, target.position + offSet, ref velocity, smoothSpeed * Time.fixedDeltaTime);
        transform.position = direction;
    }
}
