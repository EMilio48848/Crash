using UnityEngine;

public class InputController : MonoBehaviour
{
    public Vector2 Movement {get; private set;}
    public bool Jump {get; private set;}
    public bool Roll {get; private set;}
    private bool isActive = true;
    public bool IsActive {set => isActive = value;}
    private void Update()
    {
        if(!isActive)return;
        Movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Jump = Input.GetKeyDown(KeyCode.Space);
        Roll = Input.GetKeyDown(KeyCode.R);
    }
}
