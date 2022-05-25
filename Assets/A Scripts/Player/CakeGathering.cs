using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeGathering : MonoBehaviour
{
    [SerializeField] private Transform stackParent;
    
    private int collectedCakeNumber = 0;

    [SerializeField] private Vector3 localCakeCollectionPosition;
    [SerializeField] private Vector3 intervalBetweenCollectedCakes;
    private void OnTriggerEnter(Collider other)
    {
        //print("collectedCakeNumber:" + collectedCakeNumber);
        if (other.CompareTag("Cake") && !other.GetComponent<Cake>().IsCollected)// && !other.GetComponent<Cake>().IsCollected
        {
            //eðer cake'i topladýðýmýzý kontrol etmezsem ayný kek iki defa bu triggera düþüyor ve stackte bir boþluk oluyor. tam player box collider'ýn olduðu yerde
            other.GetComponent<Cake>().IsCollected = true; 
            other.transform.parent = stackParent;
            other.transform.localPosition = localCakeCollectionPosition;//+ (intervalBetweenCollectedCakes * collectedCakeNumber)
            collectedCakeNumber++;

            Cake.OnInteract?.Invoke(true, other.transform);

            MoneyManager.ChangeMoney(20);
        }
    }
}
