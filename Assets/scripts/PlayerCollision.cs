using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<int> onCoinsCollected;

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
      }
}
