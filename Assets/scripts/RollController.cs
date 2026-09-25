using UnityEngine;
using UnityEngine.Events;

public class RollController : MonoBehaviour
{
    [SerializeField]
    private InputController inputController;
    [SerializeField]
    private UnityEvent onRoll;
    [SerializeField]
    private float rollDuration = 1f;
    [SerializeField]
    private GameObject roolEffectPrefab;
    [SerializeField]
    private float effectOffsetY = 0.5f;


    private bool isRolling = false;


    private void Update()
    {
        if(inputController.Roll)
        {
            Roll();
        }
    }
    private void Roll()
    {
        PoolManager.Instance.GetObject(roolEffectPrefab, transform.position + (Vector3.up * effectOffsetY));
        isRolling = true;
        onRoll?.Invoke();
        Invoke(nameof(EndRoll), rollDuration);
    }

    private void EndRoll()
    {
        isRolling = false;
    }

}
