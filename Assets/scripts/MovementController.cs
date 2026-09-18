using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private InputController inputController;
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    private JumpController jumpController;
    [SerializeField]
    private float movementSpeed = 5f;
    [SerializeField]
    private float rotationSpeed = 10f;

    private void Update()
    {
        Vector2 input = inputController.Movement;
        Vector3 movement = new Vector3(input.x, jumpController.VerticalVelocity, input.y);
        Vector3 movementDirection = new Vector3(input.x, 0f, input.y);
        if(movementDirection.sqrMagnitude > 0f)
        {
            RotateTowards(movementDirection);
        }
        characterController.Move(movement * movementSpeed * Time.deltaTime);
    }

    private void RotateTowards(Vector3 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
