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
        if (other.CompareTag("CakeConvertor"))//&& !IsTurnedFalse && other.GetComponent<Cake>().CakeType == typeOfCakeToTransform
        {
            ConvertCake();
        }
        if (other.CompareTag("SellTrigger"))
        {
            gameObject.SetActive(false);
            OnInteract?.Invoke(false, transform);//RemoveFromStack();
            //Sell process
        }
    }
    /*
    public void Interact()
    {
        if (!IsCollected)
        {
            ConvertCake();
        }
        else
        {
            //RemoveFromStack();
            gameObject.SetActive(false);
            //Sell process
        }

        //OnInteract?.Invoke(_isPickedUp, transform);// if OnInteract is null, returns null instead of throwing an exception; otherwise invokes
    }*/

    private void ConvertCake()
    {
        //print("converted");
        //IsTurnedFalse = true;
        //other.gameObject.SetActive(false);
        //Instantiate(chocolateCake, other.transform.position, Quaternion.identity, other.transform.parent);
       // print("convertor enter");
        if (GameManager.CakeType == CakeType.Choco)//choco
        {
            DeactivateCake(cakeForm);
            cakeForm++;
            ActivateCake(cakeForm);
            //print("chaco converter");
        }
        else if (GameManager.CakeType == CakeType.Fruit)//fruit
        {
            DeactivateCake(cakeForm);
            if (cakeForm == 1) { cakeForm = 3; }
            cakeForm++;
            ActivateCake(cakeForm);
            //print("fruit converter");
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
