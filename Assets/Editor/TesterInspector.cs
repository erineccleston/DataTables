using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using EditorGUITable;

[CustomEditor(typeof(Tester))]
public class TesterInspector : Editor
{
    GUITableState tableState;

    void OnEnable()
    {
        tableState = new GUITableState("tableState");
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        tableState = GUITableLayout.DrawTable(tableState, serializedObject.FindProperty("tso"));
    }
}
