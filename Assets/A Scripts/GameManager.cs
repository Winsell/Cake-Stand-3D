using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static CakeType cakeType;

    public static CakeType CakeType { get => cakeType; set => cakeType = value; }
}
