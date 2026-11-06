using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Blink))]

public class Invincibility : MonoBehaviour
{
    [SerializeField]
    private float invincibilityDuration;
    [SerializeField]
    private float ghostDuration;
    private bool isInvincible;
    private bool isGhost;
    [SerializeField]
    private UnityEvent onInvincibilityStart;
    [SerializeField]
    private UnityEvent onInvincibilityEnd;
    public bool IsInvincible => isInvincible;
    public bool IsGhost => isGhost;
    private Blink playerBlink;
    private void Awake()
    {
        playerBlink = GetComponent<Blink>();
    }
    public void Initialize()
    {
        isInvincible = false;
        isGhost = false;
    }
    public void Kill()
    {
        isGhost = true;
        isInvincible = false;
    }
    public void ActivateGhost()
    {
        playerBlink.StartBlink(ghostDuration);
        isGhost = true;
        Invoke(nameof(EndGhost), ghostDuration);
    }
    public void EndGhost()
    {
        isGhost = false;
    }
    public void ActivateInvincibility()
    {
        playerBlink.StartBlink(invincibilityDuration);
        isInvincible = true;
        onInvincibilityStart?.Invoke();
        Invoke(nameof(EndInvincibility), invincibilityDuration);
    }
    public void EndInvincibility()
    {
        isInvincible = false;
        onInvincibilityEnd?.Invoke();
    }
}
