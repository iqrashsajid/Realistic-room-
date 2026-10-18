using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 1.5f, -3f);
    public float smoothSpeed = 10f;
    public float lookHeight = 1f;

    void LateUpdate()
    {
        if (target == null) return;

        float s = target.lossyScale.y;
        Vector3 scaledOffset = offset * s;
        Vector3 desiredPosition = target.position + Quaternion.Euler(0f, target.eulerAngles.y, 0f) * scaledOffset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target.position + Vector3.up * lookHeight * s);
    }
}