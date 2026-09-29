using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private int coinValue = 1;
    [SerializeField]
    private GameObject coinEffectPrefab;
    public int CoinValue => coinValue;
    public void onGrabbed()
    {
        PoolManager.Instance.GetObject(coinEffectPrefab, transform.position);
        gameObject.SetActive(false);
    }
}
