using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    [ContextMenuItem("Foo", "Foo")]
    [Range(-100,100)]
    public float Speed;
    public float Health;
    public string Name;
    public Vector3 Direction;
    public List<Color> colors;
    public Dictionary<string, int> myTags;

    [MenuItem("Context/MyCharacterController/Foo")]
    static void Foo()
    {
        
    }
}
