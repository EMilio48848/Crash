using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<int> onCoinsCollected;
    [SerializeField]
    private UnityEvent<Transform> onEnemyHit;
    [SerializeField]
    private UnityEvent onPlayerLose;
    [SerializeField]
    private UnityEvent onFall;
    [SerializeField]
    private UnityEvent<Transform> onCheckpointCollected;
    [SerializeField]
    private RollController rollController;
    private Invincibility invincibility;
    private JumpController jumpController;
    private void Awake()
    {
        invincibility = GetComponent<Invincibility>();
        jumpController = GetComponent<JumpController>();
    }
    private void OnTriggerEnter(Collider other)
      {
            if(other.CompareTag("Coin"))
            {
                  if(other.TryGetComponent(out Coin coin))
                  {
                        onCoinsCollected?.Invoke(coin.CoinValue);
                        coin.onGrabbed();
                  }
            }
            else if(other.CompareTag("Enemy"))
            {
                  if(invincibility.IsGhost || invincibility.IsInvincible)return;
                  if(other.TryGetComponent(out Enemy enemy))
                  {
                        if(rollController.IsRolling)
                        {
                        enemy.Die();
                        onEnemyHit?.Invoke(enemy.transform);
                        }
                        else
                        {
                        PoolManager.Instance.GetObject(enemy.HitParticles, transform.position);
                        onPlayerLose?.Invoke();
                        }
                  }
            }
            else if(other.CompareTag("Box"))
            {
                  if(other.TryGetComponent(out Box box))
                  {
                        if(rollController.IsRolling)
                        {
                              box.Break();
                        }
                  }
            }
            else if(other.CompareTag("Checkpoint"))
            {
                  if(other.TryGetComponent(out Item item))
                  {
                        onCheckpointCollected?.Invoke(item.transform);
                        item.Collect();
                  }
            }
            else if(other.CompareTag("Cliff"))
            {
                  jumpController.HasGravity = false;
                  onFall?.Invoke();
            }
      }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
      if(hit.collider.CompareTag("Box"))
      {
            if(hit.collider.TryGetComponent(out Box box))
            {
                  if(IsCharacterOnTop(hit))
                  {
                        box.Break();
                        jumpController.Jump();
                  }
            }
      }
    }
    private bool IsCharacterOnTop(ControllerColliderHit hit) 
      {
            return hit.normal.y > 0.5f;
      }
}
