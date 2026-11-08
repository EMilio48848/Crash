using System;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private UnityEvent onGameStart;
    [SerializeField]
    private UnityEvent onGameRestart;
    [SerializeField]
    private UnityEvent onWinGame;

    public void WinGame()
    {
        onWinGame?.Invoke();
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        onGameStart?.Invoke();
    }
    public void RestartGame()
    {
        onGameRestart?.Invoke();
    }
}
