using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeGathering : MonoBehaviour
{
    
    private int collectedCakeNumber = 0;

    [SerializeField] private Vector3 localCakeCollectionPosition;
    [SerializeField] private Vector3 intervalBetweenCollectedCakes;
    private void OnTriggerEnter(Collider other)
    {
        //print("collectedCakeNumber:" + collectedCakeNumber);
        if (other.CompareTag("Cake"))// && !other.GetComponent<Cake>().IsCollected
        {
            //other.GetComponent<Cake>().IsCollected = true;
            other.transform.parent = transform;
            other.transform.localPosition = localCakeCollectionPosition + (intervalBetweenCollectedCakes * collectedCakeNumber);
            collectedCakeNumber++;
        }
    }
}
