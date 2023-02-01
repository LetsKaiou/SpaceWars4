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

    // 選択したマップに関する情報
    private bool isBigmap;

    // 開発ポイント表示用
    [SerializeField] private TextMeshProUGUI[] StatusText = new TextMeshProUGUI[3];
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI[] DevlopSumText = new TextMeshProUGUI[3];
    [SerializeField] private TextMeshProUGUI[] NowStatusText = new TextMeshProUGUI[3];

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

    // バトルに勝ったかどうかの判定
    public bool isWin;
    [SerializeField] private int LosePoint = 2;
    private int ScorePoint;
    private string Rank;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        #region スコア計算処理
        ScorePoint = (int)Player.ScoreHP + (int)CreateShip.ScoreTime;

        if (ScorePoint >= 150)
        {
            Rank = "S";
            ScoreText.text = Rank;
        }
        else if (ScorePoint >= 100)
        {
            Rank = "A";
            ScoreText.text = Rank;
        }
        else if (ScorePoint >= 50)
        {
            Rank = "B";
            ScoreText.text = Rank;
        }
        //else
        //{
        //    Rank = "C";
        //    ScoreText.text = Rank;
        //}
        Debug.Log(Rank);
        #endregion


        #region 開発ポイント計算処理
        for (int i = 0; i < 3; i++)
        {
            // 開発ポイントをそれぞれの変数に割り当てる処理
            DevelopNum[i] = SliderControl.Now_value[i];
            MultiDevelop[i] = DevelopNum[i];
            // それぞれのステータス計算処理
            if(isWin == true)
            {
                switch (i)
                {
                    // 攻撃力
                    case 0:
                        // 10分の1の値にして格納
                        Ind = MultiDevelop[0] / 10;
                        StatusText[i].SetText("Point : {0}", Ind);
                        //Debug.Log("工業:"+Ind);
                        break;
                    // HP
                    case 1:
                        // 5分の1の値にして格納
                        Com = MultiDevelop[1] / 5;
                        StatusText[i].SetText("Point : {0}", Com);
                        //Debug.Log("商業:" + Com);
                        break;
                    // CT
                    case 2:
                        // CT_multiplyの値で割った値を格納
                        Agr = MultiDevelop[2] * CT_multiply;
                        Debug.Log("農業:" + Agr);
                        StatusText[i].SetText("Point : {0}", Agr);
                        break;
                }
            }
            else
            {
                switch (i)
                {
                    // 攻撃力
                    case 0:
                        MultiDevelop[0] = MultiDevelop[0] / LosePoint;
                        // 10分の1の値にして格納
                        Ind = MultiDevelop[0] / 10;
                        StatusText[i].SetText("Point : {0}", Ind);
                        //Debug.Log("工業:"+Ind);
                        break;
                    // HP
                    case 1:
                        MultiDevelop[1] = MultiDevelop[1] / LosePoint;
                        // 5分の1の値にして格納
                        Com = MultiDevelop[1] / 5;
                        StatusText[i].SetText("Point : {0}", Com);
                        //Debug.Log("商業:" + Com);
                        break;
                    // CT
                    case 2:
                        MultiDevelop[1] = MultiDevelop[1] / LosePoint;
                        // CT_multiplyの値で割った値を格納
                        Agr = MultiDevelop[2] * CT_multiply;
                        StatusText[i].SetText("Point : {0}", Agr);
                        break;
                }
            }

            for (int skill = 0; skill < 4; skill++)
            {
                CreateShip.Attack[skill] = CreateShip.Attack[skill] + Ind;
            }
            
        }
        #endregion


        // ステータス反映処理
        Data.HP  = Com + Data.HP;
        if(Data.CT <= 10)
        {
            Data.CT = Agr + Data.CT;
        }
        else if (Data.CT >= 10)
        {
            Debug.Log("IN");
            Data.CT = 10;
        }
        Data.ATK = Ind + Data.ATK;
        //for (int i = 0; i < 4; i++)
        //{
        //    newCT[i] = CreateShip.CT[i] - CreateShip.CT[i] * Agr;
        //    newAttack[i] = Ind + CreateShip.Attack[i];
        //    Debug.Log("NewCT:" + newCT[i]);
        //    Debug.Log("NewAttack:" + newAttack[i]);

        //}


        // ステータス表示
        //StatusText[0].SetText("Point : {0}", Ind);
        //StatusText[1].SetText("Point : {0}", Com);
        //StatusText[2].SetText("Point : {0}", Agr);

        // テキスト表示
        DevlopSumText[0].SetText("BeforeATK : {0}", Data.IndSum);
        DevlopSumText[1].SetText("BeforeDEF : {0}", Data.ComSum);
        DevlopSumText[2].SetText("BeforeCT : {0}", Data.AgrSum);

        // 開発ポイント加算処理
        Data.IndSum = Data.IndSum + Ind;
        Data.ComSum = Data.ComSum + Com;
        Data.AgrSum = Data.AgrSum + Agr;

        // テキスト表示
        NowStatusText[0].SetText("NowATK : {0}", Data.IndSum);
        NowStatusText[1].SetText("NowDEF : {0}", Data.ComSum);
        NowStatusText[2].SetText("NowCT : {0}", Data.AgrSum);


        // 獲得した特殊攻撃の画像表示


        // 値のセーブ
        SaveSystem.Instance.Save();


    }
}
