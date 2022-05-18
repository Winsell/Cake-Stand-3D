using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Levels Array")]
    [SerializeField] private Level[] levels;

    private void Start()
    {
        CreateLevel(0);
    }

    public void CreateLevel(int levelIndex)
    {
        for(int i= 0;i< levels[levelIndex].collectibleCakePositions.Length;i++)
        {
            GameObject newCake = ObjectPooler.instance.GetPooledObject("pooledObjects01");
            
            newCake.transform.position = levels[levelIndex].collectibleCakePositions[i];
            newCake.SetActive(true);
        }
       
    }
}
