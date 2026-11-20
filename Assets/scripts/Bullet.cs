using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float lifeTime = 6f;
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private UnityEvent onDetonate;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.isTrigger)
        {
            Detonate();
        }
    }

    public void Detonate()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        onDetonate?.Invoke();
        StopAllCoroutines();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        rb.linearVelocity = transform.forward * speed;
        StartCoroutine(DestroyAfterLifeTime());
    }

    private IEnumerator DestroyAfterLifeTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Detonate();
    }
}
