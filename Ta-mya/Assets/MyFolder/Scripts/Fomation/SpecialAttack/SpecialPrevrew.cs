using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SpecialPrevrew : MonoBehaviour
{

    static TextAsset csvFile;
    // �ꎞ�i�[��̃��X�g
    public static List<string[]> SpecialList = new List<string[]>();

    // �Z�[�u�p�̓��͏ȗ�
    private SaveSystem System => SaveSystem.Instance;
    private MainShipData Data => System.MainShipData;

    public static SpecialPrevrew instance;

    private Special_info specialInfo;
    [SerializeField] private int SpecialNum;
    // �ǂ̓���U���ɃX�e�[�^�X�������邩�I������ϐ�(0�`3�̂S��)
    private int count = 0;
    // �ǂ̓���U�����I�΂ꂽ���i�[����ϐ� (�퓬�V�[���J�n���Ɏg��)
    private int[] SelectNum = new int[3];
    //�@�X�e�[�^�X�i�[�ϐ� (�I���V�[���A�퓬�V�[���J�n���Ɏg��)
    private int[] StatusIn = new int[3];
    public int Count;
    // ����U���̊i�[��
    public string[] Name = new string[30];
    public  static int[] Attack = new int[4];
    public float[] CT = new float[4];
    public int[] Range = new int[4];
    public string[] Explanatory = new string[30];
    [SerializeField] private Image[] image;
    [SerializeField] private Image[] SelectImage;
    // �ǂ̃{�^���������ꂽ�����肷��ϐ�
    private int number;
    // �����ꂽ�ԍ��𑗐M����p�ϐ�
    public static int ShipNumber;
    // �e�L�X�g�i�[
    [SerializeField] private TextMeshProUGUI NameText;
    [SerializeField] private TextMeshProUGUI ATKText;
    [SerializeField] private TextMeshProUGUI CTText;
    [SerializeField] private TextMeshProUGUI RANGEText;

    [SerializeField] private SkillDatabase skillData;
    int check;
    public bool[] clickok = new bool[20];

    private bool isAttack;
    private bool isOnce = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        System.Load();

        // CSV�f�[�^�̎Q��
        count = 0;
        specialInfo = new Special_info();
        Debug.Log("SpcialPrevrew_Start");
        specialInfo.Delete();
        specialInfo.Init();
        foreach(DropSkill dropSkill in skillData.SkillList)
            {
            if(dropSkill.isGet == true)
            {
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
    }

    // �퓬�V�[���J�n���ɖ����@�𐶐�����ۂɎg�p
    private void CreateShip()
    {
        // StatusIn�ɂ͑�����邾���ASelectNum��count�ԖڂɑI�����ꂽ�ԍ��̏���ǂݍ���
        Name[count] = specialInfo.Name[SelectNum[count]];
        Attack[count] = specialInfo.Attack[SelectNum[count]];
        Debug.Log("previw"+Attack[0]);
        CT[count] = specialInfo.CT[SelectNum[count]];
        Range[count] = specialInfo.Range[SelectNum[count]];
        count++;
        //}
    }


    // �v���r���[�ɕ\�����邽�߂̏���
    public void Display(int number)
    {
        NameText.text = specialInfo.Name[number];
        Debug.Log(skillData.SkillList[number - 1].SkillType);
        //NameText.SetText("{0}", statusInfo.Name[number]);
        // �N���b�N��������U���̃^�C�v��Attack��������U���͕\��
        if(skillData.SkillList[number-1].SkillType == DropSkill.Type.Attack)
        {
            ATKText.SetText("ATK:{0}", specialInfo.Attack[number] + Data.ATK);
            RANGEText.SetText("RANGE:{0}", specialInfo.Range[number]);
        }
        else if(skillData.SkillList[number - 1].SkillType == DropSkill.Type.Skill)
        {
            ATKText.SetText("Effect:{0}", specialInfo.Attack[number] + Data.ATK);
            RANGEText.SetText("Time:{0}", specialInfo.Range[number]);
        }
        CTText.SetText("CT:{0}", specialInfo.CT[number] - Data.CT);
    }
    public void DisplayImage(int Num)
    {
        if (clickok[Num-1] == true)
        {
            // CSV����摜�������Ă��ĕ\��
            image[Count].sprite = Resources.Load<Sprite>(specialInfo.Image[Num]);
            // �J�E���g��i�߂�
            Count++;
            if (Count >= 4)
            {
                Count = 0;
            }
        }
    }

    // �l�̑������
    private void SetData(int SelectNum)
    {
        ShipNumber = SelectNum;
    }

    static void CsvReader()
    {

    }


}
