using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class SliderControl : MonoBehaviour
{

    // それぞれの入力ボタンを押したら説明の場所にどのステータスが上昇するか表示する処理の追加
    // リザルト画面で各ポイントの値を参照出来るようにする

    // スライダーのオブジェクト格納用
    [SerializeField] private Slider[] SliderObj;
    // スライダーの最大値、現在の入力値格納用
    private float Max = 100;
    private int count;
    public static int[] Now_value = new int[3];
    private int check;
    private int data;
    // 入力されたデータ格納用
    public TMP_InputField[] inputField;
    // テキスト用
    [SerializeField] string IndText;
    [SerializeField] string ComText;
    [SerializeField] string AgrText;
    [SerializeField] TextMeshProUGUI Explanation;
    [SerializeField] TextMeshProUGUI Remaining;

    private void Start()
    {
        // '％'入力用コンポーネント取得
        for (int i = 0; i < inputField.Length; i++)
        {
            inputField[i] = inputField[i].GetComponent<TMP_InputField>();
        }
    }
    private void Update()
    {
        Remaining.SetText("Remaing : {0}", 100 - data);
    }

    // 入力された数字に応じてスライダーを動かす処理
    public void SetData(int num)
    {
        int.TryParse(inputField[num].text, out check);
        // 100以上の値を入力されたら0にする
        if (check > 100 )
        {
            
            inputField[num].text = "0";
        }

        // Now_valueに入力された数字を変換
        //Now_value[num] = int.Parse(inputField[num].text);
        int.TryParse(inputField[num].text, out Now_value[num]);
        // countに入力された値の合計を代入
        count = Now_value.Sum();
        
        // 入力した値の合計値が100を越えた場合0にする
        if (count > 100)
        {
            inputField[num].text = "0";
        }
        // 入力された値の合計値が100以下の場合スライダーのvalueに値を代入
        else
        {
            data += Now_value[num];
            // スライダーの値に入力された値を代入
            SliderObj[num].value = Now_value[num];
        }

    }

    // 説明文表示処理
    public void SetExplanation(int select)
    {
        Explanation.SetText("");
        switch (select)
        {
            case 0:
                Explanation.SetText(IndText);
                break;
            case 1:
                Explanation.SetText(ComText);
                break;
            case 2:
                Explanation.SetText(AgrText);
                break;
        }
    }
}
