using UnityEngine;
using UnityEngine.Events;

public class InputDetection : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onGamepadConnected;
    [SerializeField]
    private UnityEvent onGamepadDisconnected;
    public bool IsGamepadConnected {get; private set; }

    private void Start()
    {
        IsGamepadConnected = CheckGamepadConnection();
        if(IsGamepadConnected)
        {
            onGamepadConnected?.Invoke();
        }
    }

    private void Update()
    {
        bool isConnected = CheckGamepadConnection();
        if(isConnected == IsGamepadConnected)
        {
            return;
        }
        IsGamepadConnected = isConnected;
        if(IsGamepadConnected)
        {
            onGamepadConnected?.Invoke();
        }
        else
        {
            onGamepadDisconnected?.Invoke();
        }
    }

    private bool CheckGamepadConnection()
    {
        foreach(var joystick in Input.GetJoystickNames())
        {
            if(!string.IsNullOrEmpty(joystick))
            {
                return true;
            }
        }
        return false;
    }
}
