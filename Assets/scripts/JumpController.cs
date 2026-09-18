using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField]
    private InputController inputController;
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    private float jumpVelocity = 8f;
    [SerializeField]
    private float gravity = -15f;
    private float verticalVelocity;
    public float VerticalVelocity => verticalVelocity;

    private void Update()
    {
        if(characterController.isGrounded)
        {
            if(verticalVelocity < 0f)
            {
                verticalVelocity = -2f;
            }
            if(inputController.Jump)
            {
                verticalVelocity = jumpVelocity;
            }
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
    }
}
