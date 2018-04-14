using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Runtime.Serialization;
using System;

[Serializable]
public enum AnEnum
{
    one, two
}

[Serializable]
public struct AnStruct
{
    public int weh;
}

[Serializable]
public abstract class DTR { }

[Serializable]
public struct TestO
{
    public string stringProperty;
    public float floatProperty;
}

[Serializable]
public class Tester : MonoBehaviour
{

    [TypeReferences.ClassExtends(typeof(System.Enum))]
    public TypeReferences.ClassTypeReference Type;

    public int weh;
    public float hew;

    public List<TestRow<AnEnum>> tso1;//List<TestRow> tso;


    void Awake()
    {
        //tso.Add(ScriptableObject.CreateInstance<TestSO>());
        //tso.Add(ScriptableObject.CreateInstance<TestSO>());
        //tso.Add(ScriptableObject.CreateInstance<TestSO>());
        //tso.Add(ScriptableObject.CreateInstance<TestSO>());
        //tso.Add(ScriptableObject.CreateInstance<TestSO>());
        tso1.Add(new TestRow<AnEnum>());
        tso1.Add(new TestRow<AnEnum>());
        tso1.Add(new TestRow<AnEnum>());
        tso1.Add(new TestRow<AnEnum>());
        tso1.Add(new TestRow<AnEnum>());
        //tso = new TestRow[] { new TestRow(), new TestRow(), new TestRow(), new TestRow(), new TestRow() };
    }

    private void Start()
    {
        //System.Type.GetTypeFromHandle(typeof(TestEnum).TypeHandle);
        //SerializationInfo si = new SerializationInfo(typeof(TestEnum), IFormatterConverter.)
        //typeof(TestEnum).TypeHandle.GetObjectData()
        //print(typeof(TestEnum).GUID.ToString());
        //System.Guid.NewGuid().ToString();

        //print(typeof(Tester).AssemblyQualifiedName);
        print(System.Type.GetTypeHandle(typeof(AnEnum)).GetHashCode());

        Debug.Log(Assembly.GetExecutingAssembly().FullName);
        string types = "";
        //foreach (var type in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
        //    types += type.Name + " ";
        Debug.Log(types);

        Type BaseType = typeof(AnEnum);
        Type type = typeof(AnEnum);
        Debug.Log((BaseType.IsValueType && !BaseType.IsEnum) ? !type.IsEnum : true);

    }
}

public enum TestEnum { zero, one, two, three, four }

[Serializable]
public class TestSO : ScriptableObject
{
    public int I;
    public float F;
}
