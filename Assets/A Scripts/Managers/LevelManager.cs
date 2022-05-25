using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private const string levelIndex = "level";
    private static int levelInfo=0;

    [SerializeField] private GameObject interactiveObjects;
    [Header("Levels Array")]
    [SerializeField] private Level[] levels;

    
    public static int LevelInfo { get => levelInfo; set => levelInfo = value; }

    private void Start()
    {
        Singelton();
        Player.OnSelectionComplete += CreateConvertors;

        LevelInfo = PlayerPrefs.GetInt(levelIndex);
        CreateLevel(2);
    }
    private void Singelton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void UpdateLevel()//call when finish line passed
    {
        LevelInfo++;
        int nextLevel = LevelInfo;
        //PlayerPrefs.SetInt(levelIndex, nextLevel);// close for test   
    }
    public void CreateNextLevel()//call when finish line passed
    {
        ObjectPooler.instance.DeactivateAllPools();

        CreateLevel(LevelInfo);
        //PlayerMovement.GameState = Screens.InGame;
        
    }

    public void CreateLevel(int levelIndex)
    {
        for(int i= 0;i< levels[levelIndex].collectibleCakePositions.Length;i++)
        {
            GameObject newCake = ObjectPooler.instance.GetPooledObject(GameObjects.Cake);
            
            newCake.transform.position = levels[levelIndex].collectibleCakePositions[i];
            newCake.SetActive(true);
        }
        Destroy(interactiveObjects);
        interactiveObjects = Instantiate(levels[levelIndex].interactiveObjectsSet);      
    }
    public void CreateConvertors(int levelIndex, GameObjects convertorType)
    {
        for (int i = 0; i < levels[levelIndex].otherObjectsPositions.Length; i++)
        {
            GameObject newObj = ObjectPooler.instance.GetPooledObject(convertorType);

            newObj.transform.position = levels[levelIndex].otherObjectsPositions[i];
            newObj.SetActive(true);
        }
    }
}
