using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreviewScore : MonoBehaviour
{
    // 他スクリプトの変数取得用
    //public Player playercs;
    //public CreateShip createcs;

    // 開発ポイント表示用
    [SerializeField] private TextMeshProUGUI[] DeveropmentText;
    [SerializeField] private TextMeshProUGUI[] StatusText;
    [SerializeField] private TextMeshProUGUI[] NowStatusText;

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


    void Awake()
    {
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
                    //Debug.Log("農業:" + Agr);
                    break;
            }

            for (int skill = 0; skill < 4; skill++)
            {
                CreateShip.Attack[skill] = CreateShip.Attack[skill] + Ind;
            }

        }
        // ステータス反映処理
        SaveSystem.Instance.MainShipData.HP = Com + SaveSystem.Instance.MainShipData.HP;
        for (int i = 0; i < 4; i++)
        {
            newCT[i] = Agr + CreateShip.CT[i];
            newAttack[i] = Ind + CreateShip.Attack[i];
            
        }
        // ステータス表示
        StatusText[0].SetText("Point : {0}", Ind);
        StatusText[1].SetText("Point : {0}", Com);
        StatusText[2].SetText("Point : {0}", Agr);

        // 開発ポイント加算処理
        SaveSystem.Instance.MainShipData.IndSum = SaveSystem.Instance.MainShipData.IndSum + Ind;
        SaveSystem.Instance.MainShipData.ComSum = SaveSystem.Instance.MainShipData.ComSum + Com;
        SaveSystem.Instance.MainShipData.AgrSum = SaveSystem.Instance.MainShipData.AgrSum + Agr;

        // 現在のステータス表示
        NowStatusText[0].SetText("Point : {0}", SaveSystem.Instance.MainShipData.HP);

        // 値のセーブ
        SaveSystem.Instance.Save();

        Debug.Log("previwHP:" + Com);

        

    }
}
