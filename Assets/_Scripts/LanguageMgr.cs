using UnityEngine;

public class LanguageMgr
{
    private static LanguageMgr _instance;
    private LanguageMgr() { }

    private SystemLanguage language;

    public static LanguageMgr GetInstance
    {
        get
        {
            if (_instance == null)
                _instance = new LanguageMgr();
            return _instance;
        }
    }

    /// <summary>
    /// 设置语言
    /// </summary>
    /// <param name="lang"></param>
    public void SetLanguage(SystemLanguage lang)
    {
        //第一次使用的话，根据系统语言进行设置
        if (!PlayerPrefs.HasKey("Language"))
        {
            PlayerPrefs.SetInt("Language", (int)GetCurrentLangue());
        }
        else
        {
            PlayerPrefs.SetString("Language", lang.ToString());
        }
        ///更新UI
        ///TODO
    }

    public void SetLanguage()
    {
        SetLanguage(GetCurrentLangue());
    }

    /// <summary>
    /// 获取系统当前的语言
    /// </summary>
    public SystemLanguage GetCurrentLangue()
    {
        return Application.systemLanguage;
    }

    /// <summary>
    /// 获取语言库
    /// </summary>
    /// <returns></returns>
    public string GetLanguageData(SystemLanguage lang)
    {
        return Resources.Load(lang.ToString()).ToString();
    }
    /// <summary>
    /// 获取语言库，默认时调用
    /// </summary>
    /// <returns></returns>
    public string GetLanguageData()
    {
        return Resources.Load(GetCurrentLangue().ToString()).ToString();
    }
}

#region 用于Json
[System.Serializable]
public class TextsOfUI
{
    public WeaponPanel WeaponPanel = new WeaponPanel();
}
[System.Serializable]
public class WeaponPanel : WeapPanelParent
{
    public string WeaponIcon_Text;
    public string WeaponDiscrible_Name;
    public string WeaponDiscrible_Property_Property01;
    public string WeaponDiscrible_Property_Property01_Number;
    public string WeaponDiscrible_Property_Property02;
    public string WeaponDiscrible_Property_Property02_Number;
    public string WeaponDiscrible_Property_Property03;
    public string WeaponDiscrible_Property_Property03_Number;
    public string WeaponDiscrible_Property_Property04;
    public string WeaponDiscrible_Property_Property04_Number;
    public string WeaponDiscrible_Property_Property05;
    public string WeaponDiscrible_Property_Property05_Number;
    public string WeaponDiscrible_Property_Discrible;
}

public class WeapPanelParent
{
    public virtual string Text { get; set; }
}
#endregion