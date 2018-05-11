using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ReflectTools : MonoBehaviour
{
    /// <summary>
    /// 动态创建一个类
    /// </summary>
    /// <param name="className"></param>
    public static object CreateInstacne(string className)
    {
        Type type = Type.GetType(className);
        if (type != null)
            return Activator.CreateInstance(type);
        return null;
    }

    /// <summary>
    /// 从另外一个类复制字段到另外一个类
    /// </summary>
    /// <param name="to">要改变字段的类</param>
    /// <param name="from">来源类</param>
    public static void SetFieldFromOtherClass(object to, object from)
    {
        int toCount = to.GetType().GetFields().Length;
        int fromCount = from.GetType().GetFields().Length;

        if (toCount != fromCount)
        {
            throw new Exception("目标类和来源类的字段个数不一致");
        }
        else
        {
            for (int i = 0; i < toCount; i++)
            {
                string fieldName = GetFieldsFromClass(to)[i].Name;
                SetFieldVaule(to, fieldName, from.GetType().GetField(fieldName).GetValue(from).ToString());
            }
        }
    }

    /// <summary>
    /// 获取某个字段
    /// </summary>
    /// <param name="myClass"></param>
    /// <param name="fieldName"></param>
    /// <returns></returns>
    public static FieldInfo[] GetFieldsFromClass(object myClass)
    {
        return myClass.GetType().GetFields();
    }

    /// <summary>
    /// 获取类中字段的值
    /// </summary>
    /// <param name="myClass"></param>
    /// <param name="fieldName"></param>
    /// <returns></returns>
    public static object GetFieldFromClass(object myClass, string fieldName)
    {
        return myClass.GetType().GetField(fieldName).GetValue(myClass);
    }
    /// <summary>
    /// 从fromClass获取字段赋值到toClass对应的字段上
    /// </summary>
    /// <param name="toClass"></param>
    /// <param name="fromClass"></param>
    /// <param name="toValue"></param>
    /// <param name="fromValue"></param>
    private static void SetFieldVaule(object toClass, string toValue,string fromValue)
    {
        toClass.GetType().GetField(toValue).SetValue(toClass, fromValue);
    }
}