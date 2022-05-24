using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject mainScreen;
    [SerializeField] private GameObject inGameScreen;
    [SerializeField] private GameObject successScreen;
    [SerializeField] private GameObject failScreen;

    private void Start()
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
    public void StartGame()
    {
        PlayerMovement.instance.transform.position = Vector3.zero;
        PlayerMovement.GameState = Screens.InGame;
        inGameScreen.SetActive(true);
    }
    public void OpenMainScreen()
    {
        mainScreen.SetActive(true);       
    }
    public void OpenSuccessScreen()
    {
        //PlayerMovement.GameState = Screens.Success;
        successScreen.SetActive(true);
        inGameScreen.SetActive(false);
    }
    public void OpenFailScreen()
    {
        PlayerMovement.GameState = Screens.Fail;
        failScreen.SetActive(true);
        inGameScreen.SetActive(false);
    }

}
