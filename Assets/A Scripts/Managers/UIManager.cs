using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Screens")]
    [SerializeField] private GameObject mainScreen;
    [SerializeField] private GameObject inGameScreen;
    [SerializeField] private GameObject successScreen;
    [SerializeField] private GameObject failScreen;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI inGameMoneyText;
    [SerializeField] private TextMeshProUGUI levelText;
    private void Start()
    {
        Singelton();
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
    public void UpdateLevelText(int level)
    {
        levelText.text = level.ToString();
    }
    public void OpenInGameScreen()
    {
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
    public void ShowMoneyChangeInGame(int newAmount)
    {
        inGameMoneyText.text = newAmount + " $";
    }
}
