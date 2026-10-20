using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform player;
    private Transform currentCheckpoint;
    public Transform CurrentCheckpoint {set {currentCheckpoint = value; } }
    private void Awake()
    {
        currentCheckpoint = startPoint;
    }
    public void MovePlayerToCheckpoint()
    {
        player.position = currentCheckpoint.position;
    }
}
