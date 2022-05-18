using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int cakeType;

    public static int CakeType { get => cakeType; set => cakeType = value; }
}
