using System;
using Unity.VisualScripting;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField]
    private GameObject rewardObject;
    [SerializeField]
    private GameObject breakParticles;
    [SerializeField]
    private Collider zoneCollider;
    [SerializeField]
    private string breakSoundName;

    public void CheckCharacter(Transform character)
    {
        if(IsCharacterOnTop(character))
        {
            Break();
        }
        
    }
    public void Break()
    {
        PoolManager.Instance.GetObject(rewardObject, transform.position);
        PoolManager.Instance.GetObject(breakParticles, transform.position);
        SoundManager.instance.Play(breakSoundName);
        gameObject.SetActive(false);
    }
    private bool IsCharacterOnTop(Transform character)
    {
        Bounds zoneBounds = zoneCollider.bounds;
        bool isAboveTop = MathF.Abs(character.position.y - zoneBounds.max.y) < 0.1f;
        return isAboveTop;
    }
}
