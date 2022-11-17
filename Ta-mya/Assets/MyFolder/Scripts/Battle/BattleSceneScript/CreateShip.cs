using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateShip : MonoBehaviour
{
    private Special_info specialInfo;
    private FriendShipInfo frindInfo;
    private child childcs;

    [SerializeField] private Vector3[] CreatePos = new Vector3[4];
    [SerializeField] private GameObject[] CreateShips;
    [SerializeField] GameObject[] Clones = new GameObject[6];
    private int[] Num = new int[4];

    // CSVデータ格納用変数
    [SerializeField] private Image[] image;
    private string[] Name = new string[100];         // 名前
    private int[] Attack = new int[100];             // 攻撃力
    public float[] CT = new float[100];             // クールタイム
    private int[] Range = new int[100];              // 射程(弾が消えるまでの時間)
    private string[] Explanatory = new string[100];  // 特殊攻撃の説明文

    public int[] HP = new int[4];
    public int[] DEF = new int[4];
    public int[] SPD = new int[4];

    void Awake()
    {
        specialInfo = new Special_info();
        frindInfo = new FriendShipInfo();
        Debug.Log("CreateShips_awake");
        specialInfo.Delete();   // 一度データを削除
        specialInfo.Init();     // 再度読み込み
        frindInfo.Delete();   // 一度データを削除
        frindInfo.Init();     // 再度読み込み

        // 画像の表示処理
        for (int i = 0; i < Select_Special.SelectSpecial.Length; i++)
        {

            // CSVから画像を持ってきて表示
            image[i].sprite = Resources.Load<Sprite>(specialInfo.Image[int.Parse(Select_Special.SelectSpecial[i])]);
            ReadInfo(i);
        }

        // 味方船生成処理
        for (int i = 0; i < SelectShip.SelectShipNum.Length; i++)
        {
            Num[i] = int.Parse(SelectShip.SelectShipNum[i]);
            ReadStatus(i);
        }

        for (int i = 0; i < 4; i++)
        {
            Clones[i] = Instantiate(CreateShips[i], CreatePos[i], Quaternion.identity);
            Debug.Log("i" + i);
            // 当たり判定取得用のタグとステータスを生成時に割り当てる
            switch (i)
            {
                case 0:
                    Clones[i].tag = "FriendShip1";
                    Clones[i].gameObject.GetComponent<child>().SetStatus(HP[i]);
                    break;
                case 1:
                    Clones[i].tag = "FriendShip2";
                    Clones[i].gameObject.GetComponent<child>().SetStatus(HP[i]);
                    break;
                case 2:
                    Clones[i].tag = "FriendShip3";
                    Clones[i].gameObject.GetComponent<child>().SetStatus(HP[i]);
                    break;
                case 3:
                    Clones[i].tag = "FriendShip4";
                    Clones[i].gameObject.GetComponent<child>().SetStatus(HP[i]);
                    break;
            }

        }

    }

    // 特殊攻撃のCSVデータを格納する処理
    public void ReadInfo(int num)
    {
        Attack[num] = specialInfo.Attack[int.Parse(Select_Special.SelectSpecial[num])];
        CT[num] = specialInfo.CT[int.Parse(Select_Special.SelectSpecial[num])];
        Range[num] = specialInfo.Range[int.Parse(Select_Special.SelectSpecial[num])];

    }
    // 味方機のCSVデータを格納する処理
    public void ReadStatus(int num)
    {
        HP[num] = frindInfo.HP[int.Parse(SelectShip.SelectShipNum[num])];
        DEF[num] = frindInfo.DEF[int.Parse(SelectShip.SelectShipNum[num])];
        SPD[num] = frindInfo.SPD[int.Parse(SelectShip.SelectShipNum[num])];
        Debug.Log("CreateShip" + HP[0]);
    }

    // データを別のスクリプトから参照できるようにする
    public float GetCT(int CTNum)
    {
        Debug.Log(CTNum);
        Debug.Log(CT[CTNum]);
        return CT[CTNum];
    }
}
