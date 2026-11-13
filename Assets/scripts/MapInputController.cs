using UnityEngine;
using UnityEngine.Events;

public class MapInputController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<MapDirection> onInputChanged;
    [SerializeField]
    private UnityEvent onSelectLevel;
    private bool isActive = true;
    public bool IsActive {set => isActive = value; }

    private void Update()
    {
        if(!isActive) return;
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            onInputChanged.Invoke(MapDirection.Up);
        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            onInputChanged.Invoke(MapDirection.Down);
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            onInputChanged.Invoke(MapDirection.Left);
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            onInputChanged.Invoke(MapDirection.Right);
        if(Input.GetKeyDown(KeyCode.Space))
            onSelectLevel.Invoke();
    }
}
