using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    [SerializeField] private GameObject cake_01, cake_02, cake_03, cake_04, cake_05;
    private bool isCollected = false;
    private bool isTurnedFalse = false;
    [SerializeField] private int cakeType = 1;


    public bool IsCollected { get => isCollected; set => isCollected = value; }
    public bool IsTurnedFalse { get => isTurnedFalse; set => isTurnedFalse = value; }
    public int CakeType { get => cakeType; set => cakeType = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CakeConvertor"))//&& !IsTurnedFalse && other.GetComponent<Cake>().CakeType == typeOfCakeToTransform
        {
            ConvertCake();
        }
        if (other.CompareTag("SellTrigger"))
        {
            gameObject.SetActive(false);
            //Sell process
        }
    }

    private void ConvertCake()
    {
        //print("converted");
        //IsTurnedFalse = true;
        //other.gameObject.SetActive(false);
        //Instantiate(chocolateCake, other.transform.position, Quaternion.identity, other.transform.parent);
        print("convertor enter");
        if (GameManager.CakeType == 0)//choco
        {
            DeactivateCake(cakeType);
            cakeType++;
            ActivateCake(cakeType);
            print("chaco converter");
        }
        else if (GameManager.CakeType == 1)//fruit
        {
            DeactivateCake(cakeType);
            if (cakeType == 1) { cakeType = 3; }
            cakeType++;
            ActivateCake(cakeType);
            print("fruit converter");
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
