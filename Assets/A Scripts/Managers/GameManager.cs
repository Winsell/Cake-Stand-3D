using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    /*
    private static Screens gameState;
    public static Screens GameState { get => gameState; set => gameState = value; }*/

    private static CakeType selectedCakeType;
    public static CakeType SelectedCakeType { get => selectedCakeType; set => selectedCakeType = value; }

    public static GameManager instance;
    private void Awake()
    {
        Singelton();
    }
    public void StartGame()
    {
        PlayerMovement.instance.transform.position = Vector3.zero;
        Player.animationState(AnimationState.Walking);
        PlayerMovement.GameState = Screens.InGame;      
        UIManager.instance.OpenInGameScreen();
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
    public void HandleWinning()
    {
        Player.animationState(AnimationState.Dancing);
        PlayerMovement.GameState = Screens.Success;
        StackController.instance.ClearStack();
        LevelManager.instance.UpdateLevel();
        LevelManager.instance.CreateNextLevel();
        StartCoroutine(OpenSuccessScreenWithDelay());
    }

    private IEnumerator OpenSuccessScreenWithDelay()
    {
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.OpenSuccessScreen();
        Player.animationState(AnimationState.Idle);

    }


}
