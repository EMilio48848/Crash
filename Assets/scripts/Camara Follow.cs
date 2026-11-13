using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float walkSmoothTime = 0.15f;
    [SerializeField]
    private float jumpSmoothTime = 0.3f;
    [SerializeField]
    private float downLimit = -1f;
    [SerializeField]
    private float lookAheadDistance = 1.2f;
    [SerializeField]
    private float lookAheadSmoothTime = 0.45f;
    private Vector3 offset;
    private Vector3 velocity;
    private Vector3 lookAheadOffset;
    private Vector3 lookAheadVelocity; 
    private void Awake()
    {
        offset = transform.position - target.position;
    }
    private void LateUpdate()
    {
        Vector3 targetDirection = target.forward;
        targetDirection.y = 0f;
        if(targetDirection.magnitude > 0.001f)
        {
            targetDirection.Normalize();
        }
        Vector3 desiredLookAhead = targetDirection * lookAheadDistance;
        lookAheadOffset = Vector3.SmoothDamp(lookAheadOffset, desiredLookAhead, ref lookAheadVelocity, lookAheadSmoothTime);
        Vector3 targetPosition = target.position + offset + lookAheadOffset;
        float x = Mathf.SmoothDamp(transform.position.x, targetPosition.x, ref velocity.x, walkSmoothTime);
        float y = Mathf.SmoothDamp(transform.position.y, targetPosition.y, ref velocity.y, jumpSmoothTime);
        float z = Mathf.SmoothDamp(transform.position.z, targetPosition.z, ref velocity.z, walkSmoothTime);
        transform.position = new Vector3(x,Mathf.Max(y,downLimit), z);
    }
}
