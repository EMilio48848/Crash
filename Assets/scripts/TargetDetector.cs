using UnityEngine;
using UnityEngine.Events;

public class TargetDetector : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<GameObject> onTargetDetected;
    [SerializeField]
    private UnityEvent<GameObject> onTargetLost;
    [SerializeField]
    private string targetTag;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(targetTag))
        {
            onTargetDetected.Invoke(other.gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(targetTag))
        {
            onTargetLost.Invoke(other.gameObject);
        }
    }
}
