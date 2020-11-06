using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getWord : MonoBehaviour
{

    //InputFieldを格納するための変数
    InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        //InputFieldコンポーネントを取得
        inputField = GameObject.Find("InputField").GetComponent<InputField>();
    }


    public void GetInputName()
    {
        //InputFieldからテキスト情報を取得する
        string key_word = inputField.text;

        WordToURL wtu = new WordToURL();
        //wtu.GetName(key_word);
        StartCoroutine(wtu.getHTML(key_word));

        //入力フォームのテキストを空にする
        inputField.text = "";
    }
}
