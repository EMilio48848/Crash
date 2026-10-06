using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Animator characterAnimator;
    [SerializeField]
    private GameObject hitPaticles;
    public GameObject HitParticles => hitPaticles;
    private Collider enemyCollider;
    protected bool isAlive;
    private void Awake()
    {
        enemyCollider = GetComponent<Collider>();
    }
    protected virtual void OnEnable()
    {
        isAlive = true;
        enemyCollider.enabled = true;
    }
    public void Die()
    {
        isAlive = false;
        enemyCollider.enabled = false;
    }
}
