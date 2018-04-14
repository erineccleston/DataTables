using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Reflection;
using EditorGUITable;

public class DataTableWindow : EditorWindow
{
    private bool UnsavedChanges = false;
    private string SelectedFile = null;
    private string SelectedGUID = null;

    [MenuItem("Window/Data Table")]
    public static void ShowWindow()
    {
        GetWindow<DataTableWindow>("Data Table Editor");

        Debug.Log(Assembly.GetExecutingAssembly().FullName);
        string types = "";
        foreach (var type in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
            types += type.Name + " ";
        Debug.Log(types);
    }

	private void OnGUI()
    {
        if (Selection.assetGUIDs.Length == 1)
        {
            string newFile = AssetDatabase.GUIDToAssetPath(Selection.assetGUIDs[0]);
            string extension = newFile.Substring(newFile.Length - 4);

            if (extension == ".csv" && !UnsavedChanges)
            {
                SelectedFile = newFile;
                SelectedGUID = Selection.assetGUIDs[0];
            }
        }

        if (string.IsNullOrEmpty(SelectedFile))
            return;

        string[] file = File.ReadAllLines(SelectedFile);

        string[] header;// = file[0].Split(',');
        Type enumType = typeof(AnEnum);//Type.GetType(header[1]);
        Type objType = typeof(Tester);//Type.GetType(header[3]);

        string[] enumNames = Enum.GetNames(enumType);
        FieldInfo[] objFields = objType.GetFields();

        EditorGUILayout.BeginScrollView(Vector2.zero);

        //EditorGUILayout.BeginHorizontal();
        //GUILayout.Label(enumType.Name);
        //foreach (FieldInfo fi in objFields)
        //    GUILayout.Label(fi.Name);
        //EditorGUILayout.EndHorizontal();

        //foreach (string name in enumNames)
        //{
        //    EditorGUILayout.BeginHorizontal();
        //    GUILayout.Label(name);

        //    foreach (FieldInfo fi in objFields)
        //    {
        //        EditorGUILayout.TextField("");
        //    }

        //    EditorGUILayout.EndHorizontal();
        //}

        GUITableState gts = new GUITableState();
        //GUITable.DrawTable(new Rect(0, 0, 200, 200), gts, objType);

        EditorGUILayout.EndScrollView();


        titleContent = new GUIContent(SelectedFile);
        GUILayout.Label(SelectedGUID);
    }

    private void OnSelectionChange()
    {
        Repaint();
    }
}
