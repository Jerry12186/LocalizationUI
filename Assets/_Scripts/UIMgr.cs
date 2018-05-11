using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{
    List<string> uiNames;
    TextsOfUI texts;

    private void Awake()
    {
        uiNames = new List<string>();
        //把UI下面的子物体全部找到
        for (int i = 0; i < transform.childCount; i++)
        {
            uiNames.Add(transform.GetChild(i).name);
        }

        //Type type = Type.GetType("WeaponPanel");
        texts = new TextsOfUI();
        texts = JsonUtility.FromJson<TextsOfUI>(LanguageMgr.GetInstance.GetLanguageData());




        //for (int i = 0; i < myClass.GetType().GetFields().Length; i++)
        //{
        //    string fieldName = myClass.GetType().GetFields()[i].Name;
        //    myClass.GetType().GetField(fieldName).SetValue(myClass, texts.WeaponPanel.GetType().GetField(fieldName).GetValue(texts.WeaponPanel).ToString());
        //}
        ////myClass.GetType().GetField("WeaponIcon_text").SetValue(myClass, "wangwangwang");
        ////string str = (string)myClass.GetType().GetField("WeaponIcon_text").GetValue(myClass);
        ////Debug.Log(str);
        //for (int i = 0; i < myClass.GetType().GetFields().Length; i++)
        //{
        //    string fieldName = myClass.GetType().GetFields()[i].Name;
        //    string str = (string)myClass.GetType().GetField(fieldName).GetValue(myClass);
        //    Debug.Log(fieldName + "---------" + str);
        //}

    }

    private void Start()
    {
        //WeaponPanel WeaponIcon_Text---------清泉流响
        //Type type = Type.GetType("WeaponPanel");
        //string name = type.Name + "/" + "WeaponIcon_Text";
        //Debug.Log(name.Replace("_", "/"));
        //Transform t = transform.Find(name.Replace("_", "/"));
        //t.GetComponent<Text>().text = "草泥马的清泉流响";

        InitUI();
    }

    /// <summary>
    /// 初始化UI
    /// 如果没有设置语言，默认显示与系统一致的语言
    /// </summary>
    private void InitUI()
    {
        TextsOfUI uiText = new TextsOfUI();

        for (int i = 0; i < uiNames.Count; i++)
        {
            object myClass = ReflectTools.CreateInstacne(uiNames[i]);
            //把Json转换的类，转到myClass中
            ReflectTools.SetFieldFromOtherClass(myClass, texts.WeaponPanel);
            //Debug.Log((string)ReflectTools.GetFieldFromClass(myClass, "WeaponDiscrible_Property_Discrible"));
            string className = Type.GetType(uiNames[i]).Name;
            for (int j = 0; j < ReflectTools.GetFieldsFromClass(myClass).Length; j++)
            {
                string transName = className + "/" + ReflectTools.GetFieldsFromClass(myClass)[j].Name;
                transform.Find(transName.Replace("_", "/")).GetComponent<Text>().text = (string)ReflectTools.GetFieldFromClass(myClass, ReflectTools.GetFieldsFromClass(myClass)[j].Name);
            }

        }
    }

    public void RefreshUI()
    {
       
    }
}