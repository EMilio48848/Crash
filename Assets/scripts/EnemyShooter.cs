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
    [SerializeField]
    private Vector3 shootOffset;
    private Invincibility target;

    public void SetTarget(GameObject targetObject)
    {
        if(target != null) return;
        target = targetObject.GetComponent<Invincibility>();
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
        while (target != null)
        {
            if(!target.IsGhost)
            {
                characterAnimator.CrossFade("Throw", 0.1f, 0, 0f);
                yield return new WaitForSeconds(shootTime);
                GameObject bullet = PoolManager.Instance.GetObject(bulletPrefab,bulletPivot.position, true);
                bullet.transform.LookAt(target.transform.position + shootOffset);
                bullet.SetActive(true);
            }
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void Update()
    {
        if(target != null)
        {
            transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
        }
    }

    public override void Die()
    {
        ClearTarget();
        characterAnimator.CrossFade("Idle", 0.1f);
        base.Die();
    }
}
