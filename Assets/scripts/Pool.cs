using System.Collections;
using System.Collections.Generic;
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

    public void InstantiateObject(Vector3 position)
    {
        if (poolStack.Count > 0)
        {
            currentObject = poolStack.Pop();
            currentObject.transform.position = position;
            currentObject.SetActive(true);
        }
        else
        {
            currentObject = Instantiate(prefab);
            currentObject.AddComponent<PoolObject>().Pool = this;
        }
        activeObjects.Add(currentObject);
    }

    public void InstantiateObject(Transform parent)
    {
        InstantiateObject(parent.position);
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        activeObjects.Remove(obj);
        poolStack.Push(obj);
    }

}
