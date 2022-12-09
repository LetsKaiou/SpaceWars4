using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreviewScore : MonoBehaviour
{
    // 他スクリプトの変数取得用
    public Player playercs;
    public CreateShip createcs;

    // 開発ポイント表示用
    [SerializeField] private TextMeshProUGUI[] DeveropmentText;
    private int[] DevelopNum = new int[3];

    // 開発ポイントからステータス変更用
    public  int[] MultiDevelop = new int[3];
    [SerializeField] private int CT_multiply;
    [SerializeField] private TextMeshProUGUI[] StatusUpText;
    // それぞれの開発ポイント格納
    public static int Ind;  // 工業：特殊攻撃の攻撃力
    public static int Com;  // 商業：メイン船の体力
    public static int Agr;  // 農業：特殊攻撃のCT


    void Start()
    {
        for (int i = 0; i < DeveropmentText.Length; i++)
        {
            // 開発ポイントの値を表示
            DeveropmentText[i].SetText("Point : {0}", SliderControl.Now_value[i]);
            // 開発ポイントをそれぞれの変数に割り当てる処理
            DevelopNum[i] = SliderControl.Now_value[i];
            MultiDevelop[i] = DevelopNum[i];
            switch (i)
            {
                case 0:
                    // 10分の1の値にして格納
                    Ind = MultiDevelop[0] / 10;
                    break;
                case 1:
                    // 5分の1の値にして格納
                    Com = MultiDevelop[1] / 5;
                    break;
                case 2:
                    // CT_multiplyの値で割った値を格納
                    Agr = MultiDevelop[2] * CT_multiply;
                    break;
            }

            for (int skill = 0; skill < 4; skill++)
            {
                createcs.Attack[skill] = createcs.Attack[skill] + Ind;
            }


            Com = Com + playercs.GetHp();


        }
    }
}
