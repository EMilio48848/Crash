using UnityEngine;
using UnityEngine.Events;

public class JumpController : MonoBehaviour
{
    [SerializeField]
    private InputController inputController;
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    private UnityEvent onJump;
    [SerializeField]
    private float jumpVelocity = 8f;
    [SerializeField]
    private float gravity = -15f;
    private float verticalVelocity;
    public float VerticalVelocity => verticalVelocity;
    private bool hasGravity = true;

    public bool HasGravity
    {
        set
        {
            hasGravity = value;
            if(!hasGravity)
            {
                verticalVelocity = 0f;
            }
        }
    }

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
                Jump();
            }
        }
        else
        {
            if(hasGravity)
            {
                verticalVelocity += gravity * Time.deltaTime;
            }
        }
    }
    public void Jump()
    {
        onJump?.Invoke();
        verticalVelocity = jumpVelocity;
    }
}
