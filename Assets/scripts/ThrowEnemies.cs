using UnityEngine;
using System.Collections;

public class ThrowEnemies : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float throwForce;
    [SerializeField]
    private float throwTime;
    public void ThrowEnemy(Transform enemy)
    {
        StartCoroutine(ThrowEnemyCoroutine(enemy));
    }

    private IEnumerator ThrowEnemyCoroutine(Transform enemy)
    {
        Vector3 direction = player.forward;
        float elapsedTime = 0f;
        while (elapsedTime < throwTime)
        {
            enemy.position += direction * throwForce * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        enemy.gameObject.SetActive(false);
    }
}
