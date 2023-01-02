using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreviewScore : MonoBehaviour
{
    // 他スクリプトの変数取得用
    //public Player playercs;
    //public CreateShip createcs;

    // セーブ用の入力省略
    private SaveSystem System => SaveSystem.Instance;
    private MainShipData Data => System.MainShipData;

    public static PreviewScore instance;

    private Special_info specialInfo;

    // 開発ポイント表示用
    [SerializeField] private TextMeshProUGUI[] DeveropmentText;
    [SerializeField] private TextMeshProUGUI[] StatusText;
    [SerializeField] private TextMeshProUGUI[] NowStatusText;
    [SerializeField] private TextMeshProUGUI[] DevlopSumText;

    private int[] DevelopNum = new int[3];

    // 開発ポイントからステータス変更用
    public int[] MultiDevelop = new int[3];
    public float AgrDevelop; 
    [SerializeField] private float CT_multiply = 0.1f;
    public static int newHP;
    public static int[] newAttack = new int[4];
    public static float[] newCT = new float[4];

    // それぞれの開発ポイント格納
    public static int Ind;  // 工業：特殊攻撃の攻撃力
    public static int Com;  // 商業：メイン船の体力
    public static float Agr;  // 農業：特殊攻撃のCT

    // データベース格納用
    //[SerializeField] private SkillDatabase skillData;
    ////private int[] isFalseNum = new int[20];
    //private int count;
    //public static List<int> isFalseNum = new List<int>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        for (int i = 0; i < DeveropmentText.Length; i++)
        {
            // 開発ポイントの値を表示
            DeveropmentText[i].SetText("Point : {0}", SliderControl.Now_value[i]);
            // 開発ポイントをそれぞれの変数に割り当てる処理
            DevelopNum[i] = SliderControl.Now_value[i];
            MultiDevelop[i] = DevelopNum[i];
            // それぞれのステータス計算処理
            switch (i)
            {
                // 攻撃力
                case 0:
                    // 10分の1の値にして格納
                    Ind = MultiDevelop[0] / 10;
                    //Debug.Log("工業:"+Ind);
                    break;
                // HP
                case 1:
                    // 5分の1の値にして格納
                    Com = MultiDevelop[1] / 5;
                    //Debug.Log("商業:" + Com);
                    break;
                // CT
                case 2:
                    // CT_multiplyの値で割った値を格納
                    Agr = MultiDevelop[2] * CT_multiply;
                    Debug.Log("農業:" + Agr);
                    break;
            }

            for (int skill = 0; skill < 4; skill++)
            {
                CreateShip.Attack[skill] = CreateShip.Attack[skill] + Ind;
            }

        }
        // ステータス反映処理
        Data.HP  = Com + Data.HP;
        Data.CT  = Agr + Data.CT;
        Data.ATK = Ind + Data.ATK;
        //for (int i = 0; i < 4; i++)
        //{
        //    newCT[i] = CreateShip.CT[i] - CreateShip.CT[i] * Agr;
        //    newAttack[i] = Ind + CreateShip.Attack[i];
        //    Debug.Log("NewCT:" + newCT[i]);
        //    Debug.Log("NewAttack:" + newAttack[i]);

        //}


        // ステータス表示
        StatusText[0].SetText("Point : {0}", Ind);
        StatusText[1].SetText("Point : {0}", Com);
        StatusText[2].SetText("Point : {0}", Agr);

        // 開発ポイント加算処理
        Data.IndSum = Data.IndSum + Ind;
        Data.ComSum = Data.ComSum + Com;
        Data.AgrSum = Data.AgrSum + Agr;

        // テキスト表示
        DevlopSumText[0].SetText("IndSum : {0}", Data.IndSum);
        DevlopSumText[1].SetText("ComSum : {0}", Data.ComSum);
        DevlopSumText[2].SetText("AgrSum : {0}", Data.AgrSum);

        // 現在のステータス表示
        NowStatusText[0].SetText("Point : {0}", Data.HP);

        // 獲得した特殊攻撃の画像表示


        // 値のセーブ
        SaveSystem.Instance.Save();

        Debug.Log("previwHP:" + Com);

        

    }
}
