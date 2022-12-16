using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FriendShipSelect : MonoBehaviour
{
    #region メモ
    // csvで読み込んできたデータを格納する変数の作成 〇
    // どの機体が選択されたのかを調べる変数作成 〇
    // どの機体が選択されたのかを調べる
    // 読み込んできたデータをStart関数内で格納 〇
    // 選択された機体のデータを格納
    // プレビューにステータスなどの表示(テキストを使う)
    // 選択された機体を生成
    // 参考元:https://wisteria-sophy.com/663/unity_basis9/
    #endregion

    private FriendShipInfo statusInfo;
    // どの戦艦にステータスを代入するか選択する変数(0～3の４機)
    private int count = 0;
    // どの戦艦が選ばれたか格納する変数 (戦闘シーン開始時に使う)
    private int[] SelectNum = new int[3];
    //　ステータス格納変数 (選択シーン、戦闘シーン開始時に使う)
    private int[] StatusIn = new int[3];
    // 戦艦の名前
    public string[] Name = new string[30];
    // 戦艦のHP
    public int[] HP = new int[3];
    // 戦艦の防御力
    public int[] DEF = new int[3];
    // 戦艦のスピード
    public int[] SPD = new int[3];
    // どのボタンを押されたか判定する変数
    private int number;
    // 押された番号を送信する用変数
    public static int ShipNumber;
    // テキスト格納
    [SerializeField] private TextMeshProUGUI NameText;
    [SerializeField] private TextMeshProUGUI HPText;
    [SerializeField] private TextMeshProUGUI DEFText;
    [SerializeField] private TextMeshProUGUI SPDText;
    public static FriendShipSelect instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        count = 0;
        statusInfo = new FriendShipInfo();
        statusInfo.Init();
        //CreateShip();
    }

    // 戦闘シーン開始時に味方機を生成する際に使用
    private void CreateShip()
    {
        // StatusInには代入するだけ、SelectNumはcount番目に選択された番号の情報を読み込む
        Name[count] = statusInfo.Name[SelectNum[count]];
        HP[count] = statusInfo.HP[SelectNum[count]];
        DEF[count] = statusInfo.DEF[SelectNum[count]];
        SPD[count] = statusInfo.SPD[SelectNum[count]];
        count++;
        //}
    }

    
    // プレビューに表示するための処理
    public void Display(int number)
    {
        NameText.text = statusInfo.Name[number];
        //NameText.SetText("{0}", statusInfo.Name[number]);
        HPText.SetText("HP:{0}", statusInfo.HP[number]);
        DEFText.SetText("DEF:{0}", statusInfo.DEF[number]);
        SPDText.SetText("SPD:{0}", statusInfo.SPD[number]);
    }


    // 値の代入処理
    private void SetData(int SelectNum)
    {
        ShipNumber = SelectNum;
    }

}
