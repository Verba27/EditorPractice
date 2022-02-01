using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyEditorWindow : EditorWindow
{
    private string userData;
    private Color userColor;
    private void OnEnable()
    {
        Debug.Log("myEditorWindow OnEnable");
    }

    [MenuItem("Window/MyEditorWindow")]
    private static void OpenMyEditorWindow()
    {
        GetWindow<MyEditorWindow>();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("CubeColorChanger"))
        {
            Debug.Log(userData);
            ChangeColor();
        }
        GUILayout.Label("myLabel");
        userData = GUILayout.TextField(userData);
        userColor = EditorGUILayout.ColorField(userColor);
    }

    void ChangeColor()
    {
        GameObject cubeGO = GameObject.Find("CubeBlu");
        if (!cubeGO){return;}
        Debug.Log("HI");
        MeshRenderer cubeMR = cubeGO.GetComponent<MeshRenderer>();
        if (!cubeMR){return;}
        Debug.Log("HI");
        Material cubeMat = cubeMR.sharedMaterial;
        if (!cubeMat){return;}
        Debug.Log("HI");
        cubeMat.SetColor("_Color", userColor);
        
    }
}
