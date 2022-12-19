using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select_Special : MonoBehaviour
{
    private Special_info specialInfo;
    // static変数宣言
    public static string[] SelectSpecial = new string[4];
    // 選択された特殊攻撃の数カウント用
    public int Count;
    // ボタン再選択カウント用
    private int DisCount;
    // ボタン格納用
    [SerializeField] private Button[] buttun = new Button[20];
    // image格納用
    [SerializeField] private Image[] image;
    // imageに入れる画像格納用
    [SerializeField] private Sprite[] sprite;
    // Outline格納
    [SerializeField] private Animator[] animator;
    // スクリプト取得用
    private GameObject Preview;
    private GameObject Button;
    // 4回選択されているかどうか確認用
    private bool Loop;
    // 解放されている特殊攻撃のカウント用
    private int OpenSkill;
    
    void Start()
    {
        
        // 初期化
        string[] SelectSpecial = new string[] { "", "", "", "" };
        //buttun = new Button[OpenSkill];
        //Animator[] animator = new Animator[3];
        Count = 0;
        Loop = false;
        specialInfo = new Special_info();
        Debug.Log("Select_Specials_Start");
        //animator[Count].SetBool("select", false);
        Debug.Log("a");
        // プレビュー表示に使用
        Preview = GameObject.Find("SceneImage");
        Button = GameObject.Find("SP_Button1");
        //Button.GetComponent<AnimationControl>().AnimStart();

    }

    private void Update()
    {
        Button.GetComponent<AnimationControl>().SpAnimStart();
        //Button.GetComponent<AnimationControl>().ShipAnimStart();
    }

    // シングルクリックをした時の処理(プレビューの表示)
    public void Click(int SpecialNumber)
    {
        if (SpecialPrevrew.instance.clickok[SpecialNumber - 1] == true)
        {
            Preview.GetComponent<SpecialPrevrew>().Display(SpecialNumber);
        }
        else
        {
            SpecialPrevrew.instance.Display(0);
        }

        // プレビュー表示用スクリプトに情報を送る
        //Preview.GetComponent<SpecialPrevrew>().Display(SpecialNumber);
    }

    // ダブルクリックをした時の処理(船を編成に追加)
    public void DoubleClick(string SpecialNum)
    {
        // 4番目の配列まで到達したらリセット

        // 再度ボタンを押せるようにする処理
        if (Loop == true)
        {
            buttun[int.Parse(SelectSpecial[Count]) - 1].interactable = true;
        }
        // Count番目の配列に押したボタンの引数代入
        SelectSpecial[Count] = SpecialNum;
        //Debug.Log(Count + "番目の配列に" + ShipNum + "代入");
        // ボタン処理

        // プレビュー表示用スクリプトに情報を送る
        if (SpecialPrevrew.instance.clickok[int.Parse(SpecialNum) - 1] == true)
        {
            buttun[int.Parse(SpecialNum) - 1].interactable = false;    // ボタンに触れなくする
            Preview.GetComponent<SpecialPrevrew>().DisplayImage(int.Parse(SpecialNum));
            Button.GetComponent<AnimationControl>().SpAnimStop();
            // カウントを進める
            Count++;
            if (Count >= 4)
            {
                Count = 0;
                Loop = true;
            }
        }

    }
}
