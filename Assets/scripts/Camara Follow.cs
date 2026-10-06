using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float walkSmoothTime = 0.15f;
    [SerializeField]
    private float jumpSmoothTime = 0.3f;
    private Vector3 offset;
    private Vector3 velocity;
    private void Start()
    {
        offset = transform.position - target.position;
    }
    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        float x = Mathf.SmoothDamp(transform.position.x, targetPosition.x, ref velocity.x, walkSmoothTime);
        float y = Mathf.SmoothDamp(transform.position.y, targetPosition.y, ref velocity.y, jumpSmoothTime);
        float z = Mathf.SmoothDamp(transform.position.z, targetPosition.z, ref velocity.z, walkSmoothTime);
        transform.position = new Vector3(x,y,z);
    }
}
