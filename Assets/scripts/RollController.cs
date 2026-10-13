using System.Collections;
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
    private float cooldown = 0.5f;
    [SerializeField]
    private Collider rollCollider;
    [SerializeField]
    private GameObject rollEffectPrefab;
    [SerializeField]
    private float effectOffsetY = 0.5f;
    private bool isRolling = false;
    public bool IsRolling => isRolling;
    private bool canRoll = true;

    private void Awake()
    {
        rollCollider.enabled = false;
        canRoll = true;
    }

    private void Update()
    {
        if(canRoll &&! isRolling && inputController.Roll)
        {
            Roll();
        }
    }
    private void Roll()
    {
        rollCollider.enabled = true;
        canRoll = false;
        Transform rollParticles = PoolManager.Instance.GetObject(rollEffectPrefab, transform). transform;
        rollParticles.localPosition+= new Vector3(0f, effectOffsetY, 0f);
        
        isRolling = true;
        onRoll?.Invoke();
        StartCoroutine(RollCoroutine());
    }

    private IEnumerator RollCoroutine()
    {
        yield return new WaitForSeconds(rollDuration);
        isRolling = false;
        rollCollider.enabled = false;
        yield return new WaitForSeconds(cooldown);
        canRoll = true;
    }

}
