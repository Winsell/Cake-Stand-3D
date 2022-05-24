using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static CakeType selectedCakeType;

    public static CakeType SelectedCakeType { get => selectedCakeType; set => selectedCakeType = value; }


}
