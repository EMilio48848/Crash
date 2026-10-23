using UnityEngine;
using UnityEngine.Events;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private Continues continues;
    [SerializeField]
    private UnityEvent onContinueGame;
    [SerializeField]
    private UnityEvent onGameOver;
    [SerializeField]
    private float deathDelay;
    public void CheckGameOver()
    {
        continues.LoseContinue();
        Invoke(nameof(CheckContinues), deathDelay);
    }
    private void CheckContinues()
    {
        if(continues.HasContinues)
        {
            onContinueGame?.Invoke();
        }
        else
        {
            onGameOver?.Invoke();
        }
    }
}
