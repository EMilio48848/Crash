using NUnit.Framework;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    [SerializeField]
    private float invincibilityDuration;
    [SerializeField]
    private float ghostDuration;
    private bool isInvincible;
    private bool isGhost;
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
}
