using UnityEngine;
using System.Collections;

public class EnemyShooter : Enemy
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletPivot;
    [SerializeField]
    private float fireRate = 2f;
    [SerializeField]
    private float shootTime = 1f;
    private Lives target;

    public void SetTarget(GameObject targetObject)
    {
        target = targetObject.GetComponent<Lives>();
        StartCoroutine(Shoot());
    }

    public void ClearTarget()
    {
        target = null;
        StopAllCoroutines();
        characterAnimator.CrossFade("Idle", 0.1f);
    }

    private IEnumerator Shoot()
    {
        while (target != null && !target.IsDead)
        {
            transform.LookAt(target.transform);
            characterAnimator.CrossFade("Throw", 0.1f);
            yield return new WaitForSeconds(shootTime);
            GameObject bullet = PoolManager.Instance.GetObject(bulletPrefab,bulletPivot.position, true);
            bullet.transform.LookAt(target.transform);
            bullet.SetActive(true);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
