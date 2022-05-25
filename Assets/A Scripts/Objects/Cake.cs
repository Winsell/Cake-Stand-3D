using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    public static Action<bool, Transform> OnInteract;

    [SerializeField] private GameObject cake_01, cake_02, cake_03, cake_04, cake_05;
    private bool isCollected = false;
    private bool isTurnedFalse = false;
    [SerializeField] private int cakeForm = 1;


    public bool IsCollected { get => isCollected; set => isCollected = value; }
    public bool IsTurnedFalse { get => isTurnedFalse; set => isTurnedFalse = value; }
    public int CakeForm { get => cakeForm; set => cakeForm = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FirstConvertor"))//&& !IsTurnedFalse && other.GetComponent<Cake>().CakeType == typeOfCakeToTransform
        {
            DeactivateCake(cakeForm);
            ConvertToSecondForm();
            ActivateCake(cakeForm);
            MoneyManager.ChangeMoney(15);
        }
        else if (other.CompareTag("SecondConvertor"))
        {
            DeactivateCake(cakeForm);
            ConvertToThirdFrom();
            ActivateCake(cakeForm);
            MoneyManager.ChangeMoney(15);
        }
        if (other.CompareTag("SellTrigger"))
        {
            ReturnToObjectPool();
            OnInteract?.Invoke(false, transform);//RemoveFromStack; 
            MoneyManager.ChangeMoney(20);
            // todo: Sell process
        }
        if (other.CompareTag("Obstacle"))
        {
            ReturnToObjectPool();
            OnInteract?.Invoke(false, transform);//RemoveFromStack; 
            MoneyManager.ChangeMoney(-20);
        }
    }
    private void OnDisable()
    {
        DeactivateCake(cakeForm);
        ActivateCake(1);
        IsCollected = false;
    }
    public void ReturnToObjectPool()
    {
        gameObject.SetActive(false);
        
        //DeactivateCake(cakeForm);
        //ActivateCake(1);
        //parent'ýný tekrar object pool yapmak gerekir mi? 


    }



    private void ConvertToSecondForm()
    {
        if (GameManager.SelectedCakeType == CakeType.Choco)//choco
        {
            cakeForm = 2;
        }
        else if (GameManager.SelectedCakeType == CakeType.Fruit)//fruit
        {
            cakeForm = 4;
        }
    }
    private void ConvertToThirdFrom()
    {
        if (GameManager.SelectedCakeType == CakeType.Choco)//choco
        {
            cakeForm = 3;
        }
        else if (GameManager.SelectedCakeType == CakeType.Fruit)//fruit
        {
            cakeForm = 5;
        }
    }
    private void DeactivateCake(int type)
    {
        switch (type)
        {
            case 1:
                cake_01.SetActive(false);
                break;
            case 2:
                cake_02.SetActive(false);
                break;
            case 3:
                cake_03.SetActive(false);
                break;
            case 4:
                cake_04.SetActive(false);
                break;
            case 5:
                cake_05.SetActive(false);
                break;
        }
    }

    private void ActivateCake(int type)
    {
        switch (type)
        {
            case 1:
                cake_01.SetActive(true);
                break;
            case 2:
                cake_02.SetActive(true);
                break;
            case 3:
                cake_03.SetActive(true);
                break;
            case 4:
                cake_04.SetActive(true);
                break;
            case 5:
                cake_05.SetActive(true);
                break;
        }
    }
}
