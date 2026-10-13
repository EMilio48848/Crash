using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Lives : MonoBehaviour
{
    [SerializeField]
    private int startingLives;
    [SerializeField]
    private UnityEvent<float> onLoseLive;
    [SerializeField]
    private UnityEvent onDeath;
    [SerializeField]
    private UnityEvent<float> startInvincibility;
    [SerializeField]
    private UnityEvent endInvincibility;
    [SerializeField]
    private float invincibilityDuration = 2f;
    [SerializeField]
    private float fullinvincibilityDuration = 4f;
    private int invincibilityLimit = 3;
    private bool isInvincible;
    private bool isDead;
    public bool IsInvicible => isInvincible;
    private int currentLives;
    public void Initialize()
    {
        currentLives = startingLives;
        isInvincible = false;
        isDead = false;
    }
    public void AddLife(int amount)
    {
        if(currentLives == (invincibilityLimit - 1))
        {
            StartCoroutine(FullInvincibilityCoroutine());
        }
        else
        {
            currentLives += amount;
        }
    }
    public void LoseLife()
    {
        if(isInvincible || isDead) return;
        currentLives--;
        if(currentLives <= 0)
        {
            isDead = true;
            onDeath?.Invoke();
        }else
        {
            StartCoroutine(InvincibilityCoroutine());
        }
    }
    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        onLoseLive?.Invoke(invincibilityDuration);
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }
    private IEnumerator FullInvincibilityCoroutine()
    {
        isDead = true;
        onLoseLive?.Invoke(fullinvincibilityDuration);
        yield return new WaitForSeconds(fullinvincibilityDuration);
        isDead = false;
    }
    public void Kill()
    {
        isDead = true;
        currentLives = 0;
        onDeath?.Invoke();
    }
}
