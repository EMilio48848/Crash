using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class ThrowEnemies : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float throwForce;
    [SerializeField]
    private float throwTime;
    [SerializeField]
    private UnityEvent onThrow;
    [SerializeField]
    private ParticlesConfi particlesConfi;
    public void ThrowEnemy(Transform enemy)
    {
        StartCoroutine(ThrowEnemyCoroutine(enemy));
    }

    private IEnumerator ThrowEnemyCoroutine(Transform enemy)
    {
        Vector3 direction = player.forward;
        float elapsedTime = 0f;
        onThrow?.Invoke();
        PoolManager.Instance.GetObject(particlesConfi.particlesPrefab, enemy.position + new Vector3(0f,particlesConfi.offsetParticlesY, 0f));
        while (elapsedTime < throwTime)
        {
            enemy.position += direction * throwForce * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        enemy.gameObject.SetActive(false);
    }
}
