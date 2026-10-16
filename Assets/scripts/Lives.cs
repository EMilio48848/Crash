using UnityEngine;
using UnityEngine.Events;

public class Lives : MonoBehaviour
{
    [SerializeField]
    private int startingLives;
    [SerializeField]
    private UnityEvent onLoseLive;
    [SerializeField]
    private UnityEvent onDeath;
    [SerializeField]
    private UnityEvent startInvincibility;
    private int invincibilityLimit = 3;
    private int currentLives;
    public bool IsDead => currentLives <= 0;
    public void Initialize()
    {
        currentLives = startingLives;
    }
    public void AddLife(int amount)
    {
        if(currentLives == (invincibilityLimit - 1))
        {
            startInvincibility?.Invoke();
        }
        else
        {
            currentLives += amount;
        }
    }
    public void LoseLife()
    {
        currentLives--;
        if(currentLives <= 0)
        {
            onDeath?.Invoke();
        }else
        {
            onLoseLive?.Invoke();
        }
    }
    public void Kill()
    {
        currentLives = 0;
        onDeath?.Invoke();
    }
}
