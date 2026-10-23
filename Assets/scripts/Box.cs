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
    private string breakSoundName;
    [SerializeField]
    private Vector3 rewardOffset;

    public void Break()
    {
        PoolManager.Instance.GetObject(rewardObject, transform.position + rewardOffset);
        PoolManager.Instance.GetObject(breakParticles, transform.position);
        SoundManager.instance.Play(breakSoundName);
        gameObject.SetActive(false);
    }
}
