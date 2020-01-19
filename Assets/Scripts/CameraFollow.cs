using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float followSpeed = 10;
    public float lookSpeed = 10;

    private Vector3 velocity = Vector3.zero;

    public void LookAtTarget()
    {
        Vector3 lookDir = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lookDir, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, lookSpeed * Time.deltaTime);
    }

    public void MoveToTarget()
    {
        Vector3 desiredPos = target.position + target.forward * offset.z + target.right * offset.x + target.up * offset.y;

        transform.position = Vector3.Lerp(transform.position, desiredPos, followSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        LookAtTarget();
        MoveToTarget();
    }
}
