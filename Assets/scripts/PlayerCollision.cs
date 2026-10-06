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
    private RollController rollController;
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
                  if(TryGetComponent(out Enemy enemy))
                  {
                        if(rollController.IsRolling)
                        {
                        enemy.Die();
                        onEnemyHit?.Invoke(enemy.transform);
                        }
                  }
                  else
                  {
                        PoolManager.Instance.GetObject(enemy.HitParticles, transform.position);
                        onPlayerLose?.Invoke();
                  }
            }
      }
}
