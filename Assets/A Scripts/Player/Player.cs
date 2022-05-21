using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Choco"))
        {
            GameManager.CakeType = CakeType.Choco;
            //print("chaco");
        }
        else if(other.CompareTag("Fruit"))
        {
            GameManager.CakeType = CakeType.Fruit;
            //print("fruþe");
        }
    }
}
