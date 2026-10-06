using NUnit.Framework;
using UnityEngine;

public class EnemyWalker : Enemy
{
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform endPoint;
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float rotationSpeed = 360f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 targetPosition;
    private void Start()
    {
        startPosition = startPoint.position;
        endPosition = endPoint.position;
        targetPosition = endPosition;
    }
    private void Update()
    {
        if(!isAlive) return;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            TurnAround();
        }
    }
    private void UpdateDirection()
    {
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0f;
        if (direction.magnitude <= 0.001f) return;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    private void TurnAround()
    {
        targetPosition = targetPosition == endPosition ? startPosition : endPosition;
    }
}
