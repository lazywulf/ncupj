using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SplineList))]
public class SplineListEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SplineList splineList = (SplineList)target;
        DrawDefaultInspector();
        EditorGUILayout.Space();

        if (GUILayout.Button("Add Spline"))
        {
            splineList.AddSpline();
        }

        if (GUILayout.Button("Delete Spline"))
        {
            splineList.DeleteSpline();
        }
    }
}
