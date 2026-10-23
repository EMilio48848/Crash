using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private GameObject itemParticles;
    [SerializeField]
    private  string itemSoundName;

    public void Collect()
    {
        PoolManager.Instance.GetObject(itemParticles, transform.position);
        SoundManager.instance.Play(itemSoundName);
        gameObject.SetActive(false);
    }
}
