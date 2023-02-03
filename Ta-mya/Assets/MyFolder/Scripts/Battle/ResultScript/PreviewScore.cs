using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PreviewScore : MonoBehaviour
{
    // ���X�N���v�g�̕ϐ��擾�p
    //public Player playercs;
    //public CreateShip createcs;

    // �Z�[�u�p�̓��͏ȗ�
    private SaveSystem System => SaveSystem.Instance;
    private MainShipData Data => System.MainShipData;

    public static PreviewScore instance;

    private Special_info specialInfo;

    // �I�������}�b�v�Ɋւ�����
    private bool isBigmap;

    // �J���|�C���g�\���p
    [SerializeField] private TextMeshProUGUI[] StatusText = new TextMeshProUGUI[3];
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI[] DevlopSumText = new TextMeshProUGUI[3];
    [SerializeField] private TextMeshProUGUI[] NowStatusText = new TextMeshProUGUI[3];
    [SerializeField] private Image[] Yajirusi = new Image[3];

    private int[] DevelopNum = new int[3];

    // �J���|�C���g����X�e�[�^�X�ύX�p
    public int[] MultiDevelop = new int[3];
    public float AgrDevelop; 
    [SerializeField] private float CT_multiply = 0.1f;
    public static int newHP;
    public static int[] newAttack = new int[4];
    public static float[] newCT = new float[4];

    // ���ꂼ��̊J���|�C���g�i�[
    public static int Ind;  // �H�ƁF����U���̍U����
    public static int Com;  // ���ƁF���C���D�̗̑�
    public static float Agr;  // �_�ƁF����U����CT

    // �A�j���[�V����
    [SerializeField] private Animator anim;

    // �o�g���ɏ��������ǂ����̔���
    [SerializeField] private int LosePoint = 2;
    private int ScorePoint;
    private string Rank;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        #region �X�R�A�v�Z����
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


        #region �J���|�C���g�v�Z����
        for (int i = 0; i < 3; i++)
        {
            // �J���|�C���g�����ꂼ��̕ϐ��Ɋ��蓖�Ă鏈��
            DevelopNum[i] = SliderControl.Now_value[i];
            MultiDevelop[i] = DevelopNum[i];
            // ���ꂼ��̃X�e�[�^�X�v�Z����
            if(GoResult.isWin == true)
            {
                switch (i)
                {
                    // �U����
                    case 0:
                        // 10����1�̒l�ɂ��Ċi�[
                        Ind = MultiDevelop[0] / 10;
                        StatusText[i].SetText("Point : {0}", Ind);
                        //Debug.Log("�H��:"+Ind);
                        break;
                    // HP
                    case 1:
                        // 5����1�̒l�ɂ��Ċi�[
                        Com = MultiDevelop[1] / 5;
                        StatusText[i].SetText("Point : {0}", Com);
                        //Debug.Log("����:" + Com);
                        break;
                    // CT
                    case 2:
                        // CT_multiply�̒l�Ŋ������l���i�[
                        Agr = MultiDevelop[2] * CT_multiply;
                        Debug.Log("�_��:" + Agr);
                        StatusText[i].SetText("Point : {0}", Agr);
                        break;
                }
            }
            else
            {
                switch (i)
                {
                    // �U����
                    case 0:
                        MultiDevelop[0] = MultiDevelop[0] / LosePoint;
                        // 10����1�̒l�ɂ��Ċi�[
                        Ind = MultiDevelop[0] / 10;
                        StatusText[i].SetText("Point : {0}", Ind);
                        //Debug.Log("�H��:"+Ind);
                        break;
                    // HP
                    case 1:
                        MultiDevelop[1] = MultiDevelop[1] / LosePoint;
                        // 5����1�̒l�ɂ��Ċi�[
                        Com = MultiDevelop[1] / 5;
                        StatusText[i].SetText("Point : {0}", Com);
                        //Debug.Log("����:" + Com);
                        break;
                    // CT
                    case 2:
                        MultiDevelop[1] = MultiDevelop[1] / LosePoint;
                        // CT_multiply�̒l�Ŋ������l���i�[
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


        // �X�e�[�^�X���f����
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

        // �e�L�X�g�\��
        DevlopSumText[0].SetText("BeforeATK : {0}", Data.IndSum);
        DevlopSumText[1].SetText("BeforeDEF : {0}", Data.ComSum);
        DevlopSumText[2].SetText("BeforeCT : {0}", Data.AgrSum);

        // �J���|�C���g���Z����
        Data.IndSum = Data.IndSum + Ind;
        Data.ComSum = Data.ComSum + Com;
        Data.AgrSum = Data.AgrSum + Agr;

        // 1.5�b��ɖ���\��
        Invoke("DisplayYajirusi", 1.5f);
        //Invoke("StartAnim", 1.6f);

        // 2�b���NowStatus�\��
        Invoke("DisplayNowStatus", 2);

        // �l�̃Z�[�u
        SaveSystem.Instance.Save();
    }

    private void DisplayYajirusi()
    {
        for (int i = 0; i < Yajirusi.Length; i++)
        {
            Yajirusi[i].enabled = true;
        }
        anim.SetBool("isStart", true);
    }

    private void DisplayNowStatus()
    {
        // �e�L�X�g�\��
        NowStatusText[0].SetText("NowATK : {0}", Data.IndSum);
        NowStatusText[1].SetText("NowDEF : {0}", Data.ComSum);
        NowStatusText[2].SetText("NowCT : {0}", Data.AgrSum);

    }

}
