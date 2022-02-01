using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyMenues : MonoBehaviour
{
    [MenuItem("MyTools/HelloMenu")]
    public static void HelloMenu()
    {
        Debug.Log("HelloMenu");
    }
}
