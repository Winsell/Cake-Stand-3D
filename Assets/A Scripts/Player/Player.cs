using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static UnityAction<int, GameObjects> OnSelectionComplete;

    private bool isPassedTheSelectionGate = false;

    [SerializeField] private Animator animator;

    public static Action<AnimationState> animationState;
    private void OnEnable()
    {
        animationState += UpdateAnimationState;
    }
    private void OnDisable()
    {
        animationState -= UpdateAnimationState;
    }
    private void UpdateAnimationState(AnimationState state)
    {
        switch (state)
        {
            case AnimationState.Idle:
                animator.SetBool("isWalking", false);
                animator.SetTrigger("restart");
                break;
            case AnimationState.Walking:
                animator.SetBool("isWalking", true);
                break;               
            case AnimationState.Falling:
                animator.SetTrigger("isDefeated");
                break;
            case AnimationState.Dancing:
                animator.SetTrigger("isSucceeded");
                break;
        }
    }
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
            GameManager.instance.HandleWinning();
            /*
            //PlayerMovement.IsPlaying = false;
            PlayerMovement.GameState = Screens.Success;
            UIManager.instance.OpenSuccessScreen();
            StackController.instance.ClearStack();
            LevelManager.instance.UpdateLevel();
            LevelManager.instance.CreateNextLevel();*/

            isPassedTheSelectionGate = false;
        }


    }
}
public enum AnimationState
{
    Idle,
    Walking,
    Falling,
    Dancing
}
