using UnityEngine;
using System.Collections.Generic;
using TypeReferences;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class DataTable : ScriptableObject
{
    [SerializeField] [HideInInspector] [ClassExtends(typeof(Enum))]
    private ClassTypeReference EnumType;
    [SerializeField] [HideInInspector] [ClassExtends(typeof(DataTableRow))] //[ClassImplements(typeof(DataTableRow))]
    private ClassTypeReference ObjectType;
    [SerializeField] [HideInInspector]
    private List<DataTableRow> Rows;
    [SerializeField] [HideInInspector]
    private bool Init = true;

    public Type GetEnumType()
    {
        return EnumType.Type;
    }

    public Type GetObjectType()
    {
        return ObjectType.Type;
    }

#if UNITY_EDITOR
    [MenuItem("Assets/Create/Data Table")]
    public static void CreateDataTableAsset()
    {
        ProjectWindowUtil.CreateAsset(CreateInstance<DataTable>(), "New " + typeof(DataTable).Name + ".asset");
    }

    private void OnValidate()
    {
        if (EnumType && ObjectType && Init)
        {
            Debug.Log("Initializing DataTable of types " + EnumType.Type.Name + " and " + ObjectType.Type.Name);
            Rows = new List<DataTableRow>();
            foreach (string name in Enum.GetNames(EnumType.Type))
            {
                Rows.Add(Activator.CreateInstance(ObjectType.Type) as DataTableRow);
            }
            Init = false;
            foreach(TestRow<AnEnum> weh in Rows)
                Debug.LogWarning(weh.F);
        }
    }
    #endif
}

[Serializable] public class DataTableRow { }

//public interface DataTableRow { }

[Serializable]
public class TestRow<T> : DataTableRow
{
    public int I = 3;
    public float F = 3.14f;
    public char C = 'c';
}

//public sealed class DataTableRow// : ScriptableObject
//{
//    public readonly string EnumName;
//    public readonly object EnumValue;
//    public readonly ScriptableObject Row;

//    public DataTableRow(string enumName, object enumValue, ScriptableObject row)
//    {
//        EnumName = enumName;
//        EnumValue = enumValue;
//        Row = row;
//    }

//    //private string EnumName = null;
//    //private object EnumValue = null;
//    //private ScriptableObject Row = null;

//    //public void Init(string enumName, object enumValue, ScriptableObject row)
//    //{
//    //    if (EnumName == null && EnumValue == null && !Row)
//    //    {
//    //        EnumName = enumName;
//    //        EnumValue = enumValue;
//    //        Row = row;
//    //    }
//    //}
//}
