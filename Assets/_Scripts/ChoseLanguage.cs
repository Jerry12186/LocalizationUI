using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseLanguage : MonoBehaviour
{
    public Dropdown languages;

    private void Start()
    {
        languages.value = 0;
        languages.onValueChanged.AddListener(
            (x) => 
            {
                if (x == 0)
                {
                    Debug.Log("简体中文");
                    UIMgr._instance.RefreshUI(SystemLanguage.Chinese);
                }
                else if (x == 1)
                {
                    Debug.Log("English");
                    UIMgr._instance.RefreshUI(SystemLanguage.English);
                }
            });
    }

   
}
