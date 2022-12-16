using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpecialPrevrew : MonoBehaviour
{
    public static SpecialPrevrew instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private Special_info specialInfo;
    [SerializeField] private int SpecialNum;
    // どの特殊攻撃にステータスを代入するか選択する変数(0～3の４つ)
    private int count = 0;
    // どの特殊攻撃が選ばれたか格納する変数 (戦闘シーン開始時に使う)
    private int[] SelectNum = new int[3];
    //　ステータス格納変数 (選択シーン、戦闘シーン開始時に使う)
    private int[] StatusIn = new int[3];
    public int Count;
    // 特殊攻撃の格納先
    public string[] Name = new string[30];
    public int[] Attack = new int[4];
    public float[] CT = new float[4];
    public int[] Range = new int[4];
    public string[] Explanatory = new string[30];
    [SerializeField] private Image[] image;
    [SerializeField] private Image[] SelectImage;
    // どのボタンを押されたか判定する変数
    private int number;
    // 押された番号を送信する用変数
    public static int ShipNumber;
    // テキスト格納
    [SerializeField] private TextMeshProUGUI NameText;
    [SerializeField] private TextMeshProUGUI ATKText;
    [SerializeField] private TextMeshProUGUI CTText;
    [SerializeField] private TextMeshProUGUI RANGEText;

    [SerializeField] private SkillDatabase skillData;
    int check;
    public bool[] clickok = new bool[20];


    void Start()
    {
        // CSVデータの参照
        count = 0;
        specialInfo = new Special_info();
        Debug.Log("SpcialPrevrew_Start");
        specialInfo.Init();
        foreach(DropSkill dropSkill in skillData.SkillList)
            {
            if(dropSkill.isGet == true)
            {
                Debug.Log(dropSkill.isGet);
                SelectImage[check].sprite = Resources.Load<Sprite>(specialInfo.Image[check + 1]);
                clickok[check] = true;
            }
            else
            {
                //SelectImage[check].enabled = false;
                SelectImage[check].sprite = Resources.Load<Sprite>(specialInfo.Image[check + 1]);
                SelectImage[check].color = new Color(0.2f,0.2f,0.2f,0.5f);
            }
            check++;
            }
        //}
        //SkillData.SkillList[0].isGet = true;
        //CreateShip();
    }

    // 戦闘シーン開始時に味方機を生成する際に使用
    private void CreateShip()
    {
        // StatusInには代入するだけ、SelectNumはcount番目に選択された番号の情報を読み込む
        Name[count] = specialInfo.Name[SelectNum[count]];
        Attack[count] = specialInfo.Attack[SelectNum[count]];
        CT[count] = specialInfo.CT[SelectNum[count]];
        Range[count] = specialInfo.Range[SelectNum[count]];
        count++;
        //}
    }


    // プレビューに表示するための処理
    public void Display(int number)
    {
        Debug.Log(specialInfo.Name[6]);
        NameText.text = specialInfo.Name[number];
        //NameText.SetText("{0}", statusInfo.Name[number]);
        ATKText.SetText("ATK:{0}", specialInfo.Attack[number]);
        CTText.SetText("CT:{0}", specialInfo.CT[number]);
        RANGEText.SetText("RANGE:{0}", specialInfo.Range[number]);
    }
    public void DisplayImage(int Num)
    {
        if (clickok[Num-1] == true)
        {
            // CSVから画像を持ってきて表示
            image[Count].sprite = Resources.Load<Sprite>(specialInfo.Image[Num]);
            Debug.Log(specialInfo.Image[Num]);
            // カウントを進める
            Count++;
            if (Count >= 4)
            {
                Count = 0;
            }
        }
    }

    // 値の代入処理
    private void SetData(int SelectNum)
    {
        ShipNumber = SelectNum;
    }
}
