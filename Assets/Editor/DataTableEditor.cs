using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using EditorGUITable;

[CustomEditor(typeof(DataTable))]
public class DataTableEditor : Editor
{
    SerializedProperty ET, OT, I, R;

    GUITableState tableState;

    private void OnEnable()
    {
        tableState = new GUITableState("DTETS");

        ET = serializedObject.FindProperty("EnumType");
        OT = serializedObject.FindProperty("ObjectType");
        I = serializedObject.FindProperty("Init");
        R = serializedObject.FindProperty("Rows");
    }

    public override void OnInspectorGUI()
    {
        if (!I.boolValue)
            GUI.enabled = false;
        EditorGUILayout.PropertyField(ET);
        EditorGUILayout.PropertyField(OT);
        GUI.enabled = true;

        serializedObject.ApplyModifiedPropertiesWithoutUndo();
        serializedObject.Update();

        if (!I.boolValue)
        {
            Debug.LogFormat("{0} {1}", R, "");// R.GetArrayElementAtIndex(0));
            R.
            tableState = GUITableLayout.DrawTable(tableState, R);
            //string[] names = System.Array.ConvertAll(((DataTable)target).GetObjectType().GetFields(), (fi) => fi.Name);
            //tableState = GUITableLayout.DrawTable(tableState, R.GetArrayElementAtIndex(0), new List<string>(names));
            //DrawCustomEntries();
            //Debug.Log(R.GetArrayElementAtIndex(0).propertyPath);
            //Debug.Log(R.GetArrayElementAtIndex(0).propertyType);
            //Debug.Log(R.GetArrayElementAtIndex(0).type);
            //EditorGUILayout.PropertyField(R.GetArrayElementAtIndex(0).GetEnumerator().Current);
        }

    }

    //private void DrawCustomEntries()
    //{
    //    List<TableColumn> columns = new List<TableColumn>()
    //    {
    //        new TableColumn("Enum")
    //        //new TableColumn("String", 60f),
    //        //new TableColumn("Float", 50f),
    //        //new TableColumn("Object", 110f),
    //        //new TableColumn("", TableColumn.Width(100f), TableColumn.EnabledTitle(false)),
    //    };

    //    System.Type ot = ((DataTable)target).GetObjectType();
    //    foreach (var fi in ot.GetFields())
    //        columns.Add(new TableColumn(fi.Name));

    //    List<List<TableEntry>> rows = new List<List<TableEntry>>();

    //    Debug.Log(R.GetArrayElementAtIndex(1).objectReferenceValue.GetType());

    //    Debug.Log(R.propertyPath);
    //    string firstElementPath = R.propertyPath + ".Array.data[0]";
    //    foreach (SerializedProperty prop in R.serializedObject.FindProperty(firstElementPath))
    //    {
    //        string subPropName = prop.propertyPath.Substring(firstElementPath.Length + 1);
    //        // Avoid drawing properties more than 1 level deep
    //        //if (!subPropName.Contains("."))
    //        //    properties.Add(subPropName);
    //        Debug.Log("SPN " + subPropName);
    //    }

        //SimpleExample targetObject = (SimpleExample)serializedObject.targetObject;

        //for (int i = 0; i < targetObject.simpleObjects.Count; i++)
        //{
        //    SimpleExample.SimpleObject entry = targetObject.simpleObjects[i];
        //    rows.Add(new List<TableEntry>()
        //    {
        //        new LabelEntry (entry.stringProperty),
        //        new PropertyEntry (serializedObject, string.Format("simpleObjects.Array.data[{0}].floatProperty", i)),
        //        new PropertyEntry (serializedObject, string.Format("simpleObjects.Array.data[{0}].objectProperty", i)),
        //        new ActionEntry ("Reset", () => entry.Reset ()),
        //    });
        //}

        //tableState = GUITableLayout.DrawTable(tableState, columns, rows);
    //}

    //void DrawSimple()
    //{
    //    tableState = GUITableLayout.DrawTable(tableState, serializedObject.FindProperty("Rows"));
    //}

    //void DrawObjectsTable()
    //{

    //    GUILayout.Label("Simply Display the Whole list (click to sort, drag to resize)", EditorStyles.boldLabel);

    //    DrawSimple();

    //    GUILayout.Space(20f);

    //    GUILayout.BeginHorizontal();
    //    GUILayout.Label("Customize the properties", EditorStyles.boldLabel, GUILayout.Width(170f));
    //    if (GUILayout.Button("Window Example", GUILayout.Width(120f)))
    //        EditorWindow.GetWindow<CustomPropertiesWindow>().Show();
    //    GUILayout.EndHorizontal();

    //    GUILayout.Space(10f);

    //    GUILayout.BeginHorizontal();
    //    GUILayout.Label("Customize the columns", EditorStyles.boldLabel, GUILayout.Width(170f));
    //    if (GUILayout.Button("Window Example", GUILayout.Width(120f)))
    //        EditorWindow.GetWindow<CustomColumnsWindow>().Show();
    //    GUILayout.EndHorizontal();

    //    GUILayout.Space(10f);

    //    GUILayout.BeginHorizontal();
    //    GUILayout.Label("Customize the selectors", EditorStyles.boldLabel, GUILayout.Width(170f));
    //    if (GUILayout.Button("Window Example", GUILayout.Width(120f)))
    //        EditorWindow.GetWindow<CustomSelectorsWindow>().Show();
    //    GUILayout.EndHorizontal();

    //    GUILayout.Space(10f);

    //    GUILayout.BeginHorizontal();
    //    GUILayout.Label("Customize the entries", EditorStyles.boldLabel, GUILayout.Width(170f));
    //    if (GUILayout.Button("Window Example", GUILayout.Width(120f)))
    //        EditorWindow.GetWindow<CustomEntriesWindow>().Show();
    //    GUILayout.EndHorizontal();

    //    GUILayout.FlexibleSpace();

    //}

}
