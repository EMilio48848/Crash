using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour
{
    private List<Renderer> renderers = new List<Renderer>();
    [SerializeField]
    private float blinkInterval = 0.1f;
    private void Awake()
    {
        renderers.AddRange(GetComponentsInChildren<Renderer>());
    }
    private void EnableRenderers(bool enabled)
    {
        foreach(var renderers in renderers)
        {
            renderers.enabled = enabled;
        }
    }
    public void StartBlink(float duration)
    {
        StartCoroutine(BlinkCoroutine(duration));
    }
    private IEnumerator BlinkCoroutine(float duration)
    {
        bool isActive = true;
        float elapsedTime = 0f;
        while(elapsedTime < duration)
        {
            EnableRenderers(isActive);
            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }
        EnableRenderers(true);
    }
    public void StopBlink()
    {
        StopAllCoroutines();
        EnableRenderers(true);
    }
}
