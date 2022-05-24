using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler instance;
     
    [SerializeField] private int amountToPool;

    [Header("Objects")]
    [SerializeField] private GameObject cake;
    [SerializeField] private GameObject fruitConvertor;
    [SerializeField] private GameObject chocoConvertor;
    
    [Header("Object Pools")]
    [SerializeField] private List<GameObject> pooledCakes;
    [SerializeField] private List<GameObject> pooledFruitConventor;
    [SerializeField] private List<GameObject> pooledChocoConventor;
    /*
    [Header("Parent Transforms")]
    [SerializeField] private Transform cakeParent;
    [SerializeField] private Transform fruitConvertorParent;
    [SerializeField] private Transform chocoConvertorParent;*/
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        CreatePool(cake, out pooledCakes, amountToPool);
        CreatePool(fruitConvertor, out pooledFruitConventor, 5);
        CreatePool(chocoConvertor, out pooledChocoConventor, 5);
        // CreatePool(cakeType02, out pooledObjects02);
    }

    private void CreatePool(GameObject objectToPool, out List<GameObject> pooledObjects, int amountToPool)//Transform parent
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

    public GameObject GetPooledObject(GameObjects pooledObjectName)
    {
        List<GameObject> pooledObjects = null;
        switch (pooledObjectName)
        {
            case GameObjects.Cake:
                pooledObjects = pooledCakes;
                break;
            case GameObjects.FruitConventor:
                pooledObjects = pooledFruitConventor;
                break;
            case GameObjects.ChocoConvertor:
                pooledObjects = pooledChocoConventor;
                break;
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

    public void DeactivateThePool(List<GameObject> pool)
    {
        foreach(var obj in pool)
        {
            obj.SetActive(false);
        }
    }
    public void DeactivateAllPools()
    {
        DeactivateThePool(pooledCakes);
        DeactivateThePool(pooledChocoConventor);
        DeactivateThePool(pooledFruitConventor);
    }
}
