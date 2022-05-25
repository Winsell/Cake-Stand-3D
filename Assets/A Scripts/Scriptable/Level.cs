using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelConfiguration")]
public class Level : ScriptableObject
{
    //[Header("Collectible Cakes")]
    public Vector3[] collectibleCakePositions;
    public Vector3[] otherObjectsPositions;

    public GameObject interactiveObjectsSet;


}
