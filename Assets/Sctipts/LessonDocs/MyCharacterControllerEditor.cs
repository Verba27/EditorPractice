using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MyCharacterController))]
public class MyCharacterControllerEditor : Editor
{
    private MyCharacterController mcc;
    private SerializedObject m_Object;
    private SerializedProperty m_Speed;
    
    private void OnEnable()
    {
        mcc = target as MyCharacterController;
        m_Object = new SerializedObject(target);
        m_Speed = m_Object.FindProperty("Speed");
        
    }

    /*private void OnSceneGUI()
    {
        Handles.ArrowHandleCap(0, mcc.transform.position, mcc.transform.rotation, 5, EventType.Repaint);
    }*/

    private void OnSceneGUI()
    {
        Vector2 screenPOint = HandleUtility.WorldToGUIPoint(mcc.transform.position);
        Rect rect = new Rect(screenPOint.x - 50, screenPOint.y - 40, 10, 100);
        GUI.Box(rect, mcc.Name);
    }

    public override void OnInspectorGUI()
    {
        Event evnt = Event.current;
        //mcc.Speed = EditorGUILayout.FloatField(mcc.Speed);
        m_Object.Update();
        EditorGUILayout.PropertyField(m_Speed);
        if (m_Speed.floatValue < 0)
        {
            m_Speed.floatValue = 0;
        }
        GUILayout.Label("FreeSpace");
        Rect rect = GUILayoutUtility.GetRect(0, 50, GUILayout.ExpandWidth(true));
        GUI.Box(rect, "CLICK HERE!!!!!!! THIS IS FIELD TO CLICK");
        if (rect.Contains(evnt.mousePosition))
        {
            if (evnt.type == EventType.MouseDown && evnt.button == 1)
            {
                Debug.Log("MOUSE PRESSD WORK ONLY ON FIELD");
                Event.current.Use();
            }
        }
        m_Object.ApplyModifiedProperties();
    }
}
