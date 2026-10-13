using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private Stack<GameObject> poolStack = new Stack<GameObject>();
    private readonly HashSet<GameObject> activeObjects = new HashSet<GameObject>();
    public IReadOnlyCollection<GameObject> ActiveObjects => activeObjects;
    [SerializeField]
    private GameObject prefab;
    public GameObject Prefab {set {prefab = value;}}
    private GameObject currentObject;
    public GameObject CurrentObject => currentObject;

    public void InstantiateObject(Vector3 position, bool isTurnedOff = false)
    {
        if (poolStack.Count > 0)
        {
            currentObject = poolStack.Pop();
            currentObject.transform.position = position;
            if(!isTurnedOff)
            {
            currentObject.SetActive(true);
            }
        }
        else
        {
            currentObject = Instantiate(prefab);
            if(isTurnedOff)
            {
            currentObject.SetActive(false);
            }
            currentObject.AddComponent<PoolObject>().Pool = this;
        }
        currentObject.transform.SetParent(null);
        currentObject.transform.position = position;
        activeObjects.Add(currentObject);
    }

    public void InstantiateObject(Transform parent, bool isTurnedOff = false)
    {
        InstantiateObject(parent.position, isTurnedOff);
        currentObject.transform.SetParent(parent);
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        activeObjects.Remove(obj);
        poolStack.Push(obj);
    }

}
