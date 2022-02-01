using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacter : MonoBehaviour
{
    public float Healt = 100;
    public static MyCharacter Instance;

    private void Awake()
    {
        Instance = this;
    }
}
