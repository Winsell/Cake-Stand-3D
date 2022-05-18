using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler instance;
   
    
    [SerializeField] private int amountToPool;
    [SerializeField] private GameObject cakeType01, cakeType02;
    //[SerializeField] private Transform cakeTransform01, cakeTransform02;

    [SerializeField] private List<GameObject> pooledObjects01, pooledObjects02;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        CreatePool(cakeType01, out pooledObjects01);
       // CreatePool(cakeType02, out pooledObjects02);
    }

    private void CreatePool(GameObject objectToPool, out List<GameObject> pooledObjects)//Transform parent
    {
        // Loop through list of pooled objects,deactivating them and adding them to the list 
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            obj.transform.SetParent(transform); // set as children of Spawn Manager
        }
    }

    public GameObject GetPooledObject(string pooledObjectName)
    {
        List<GameObject> pooledObjects = null;
        if (pooledObjectName == "pooledObjects01")
        {
            pooledObjects = pooledObjects01;
        }
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        // otherwise, return null   
        return null;
    }
}
