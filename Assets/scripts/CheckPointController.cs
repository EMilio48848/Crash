using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform player;
    private Transform currentCheckpoint;
    private CharacterController characterController;
    public Transform CurrentCheckpoint {set {currentCheckpoint = value; } }
    private void Awake()
    {
        currentCheckpoint = startPoint;
        characterController = player.GetComponent<CharacterController>();
    }
    public void MovePlayerToCheckpoint()
    {
        characterController.enabled = false;
        player.position = currentCheckpoint.position;
        characterController.enabled = true;
    }
}
