using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static UnityAction<int, GameObjects> OnSelectionComplete;

    private bool isPassedTheSelectionGate = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!isPassedTheSelectionGate)
        {
            if (other.CompareTag("Choco"))
            {
                GameManager.SelectedCakeType = CakeType.Choco;
                OnSelectionComplete?.Invoke(LevelManager.LevelInfo, GameObjects.ChocoConvertor);
                isPassedTheSelectionGate = true;
            }
            else if (other.CompareTag("Fruit"))
            {
                GameManager.SelectedCakeType = CakeType.Fruit;
                OnSelectionComplete?.Invoke(LevelManager.LevelInfo, GameObjects.FruitConventor);
                isPassedTheSelectionGate = true;
            }
        }

        if (other.tag == "Finish" && PlayerMovement.GameState==Screens.InGame)
        {

            //PlayerMovement.IsPlaying = false;
            PlayerMovement.GameState = Screens.Success;
            UIManager.instance.OpenSuccessScreen();
            StackController.instance.ClearStack();
            LevelManager.instance.UpdateLevel();
            LevelManager.instance.CreateNextLevel();

            isPassedTheSelectionGate = false;
        }


    }
}
