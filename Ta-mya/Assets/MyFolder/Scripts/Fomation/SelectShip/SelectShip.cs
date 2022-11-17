using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectShip : MonoBehaviour
{

    // static変数宣言
    public static string[] SelectShipNum = new string[4];
    // 選択された機体の数カウント用
    public int Count;
    // ボタン再選択カウント用
    private int DisCount;
    // ボタン格納用
    [SerializeField] private Button[] buttun;
    // image格納用
    [SerializeField] private Image[] image;
    // imageに入れる画像格納用
    [SerializeField] private Sprite[] sprite;
    // Outline格納
    [SerializeField] private Animator[] animator;
    // プレビュースクリプト取得用
    private GameObject Preview;
    private GameObject Button;
    // 4回選択されているかどうか確認用
    private bool Loop;

    void Start()
    {
        // 初期化
        string[] SelectShipNum = new string[] { "", "", "","" };
        //Animator[] animator = new Animator[3];
        Count = 0;
        Loop = false;

        // プレビュー表示に使用
        Preview = GameObject.Find("ButtonCanvas");
        Button = GameObject.Find("Image");
        //Button.GetComponent<AnimationControl>().AnimStart();
    }

    private void Update()
    {
        Button.GetComponent<AnimationControl>().ShipAnimStart();
        //animator[Count].SetBool("select", true);
    }

    // シングルクリックをした時の処理(プレビューの表示)
    public void Click(int ShipNumber)
    {
        // プレビュー表示用スクリプトに情報を送る
        Preview.GetComponent<FriendShipSelect>().Display(ShipNumber);
    }

    // ダブルクリックをした時の処理(船を編成に追加)
    public void DoubleClick(string ShipNum)
    {

        // 4番目の配列まで到達したらリセット

        // 再度ボタンを押せるようにする処理
        if (Loop == true)
        {
            buttun[int.Parse(SelectShipNum[Count]) - 1].interactable = true;
        }
        // Count番目の配列に押したボタンの引数代入
        SelectShipNum[Count] = ShipNum;
        //Debug.Log(Count + "番目の配列に" + ShipNum + "代入");
        // ボタン処理
        buttun[int.Parse(ShipNum) - 1].interactable = false;    // ボタンに触れなくする

        //sprite[] = Resources.Load<Sprite>();
        //image = GetComponent<Image>();
        image[Count].sprite = sprite[int.Parse(ShipNum)-1];

        Button.GetComponent<AnimationControl>().ShipAnimStop();


        // カウントを進める
        Count++;
        if (Count >= 4)
        {
            Count = 0;
            Loop = true;
        }
    }

}
