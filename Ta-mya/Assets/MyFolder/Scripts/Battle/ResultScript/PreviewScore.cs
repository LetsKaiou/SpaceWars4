using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreviewScore : MonoBehaviour
{
    // ���X�N���v�g�̕ϐ��擾�p
    //public Player playercs;
    //public CreateShip createcs;

    // �J���|�C���g�\���p
    [SerializeField] private TextMeshProUGUI[] DeveropmentText;
    [SerializeField] private TextMeshProUGUI[] StatusText;
    [SerializeField] private TextMeshProUGUI[] NowStatusText;

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


    void Awake()
    {
        for (int i = 0; i < DeveropmentText.Length; i++)
        {
            // �J���|�C���g�̒l��\��
            DeveropmentText[i].SetText("Point : {0}", SliderControl.Now_value[i]);
            // �J���|�C���g�����ꂼ��̕ϐ��Ɋ��蓖�Ă鏈��
            DevelopNum[i] = SliderControl.Now_value[i];
            MultiDevelop[i] = DevelopNum[i];
            // ���ꂼ��̃X�e�[�^�X�v�Z����
            switch (i)
            {
                // �U����
                case 0:
                    // 10����1�̒l�ɂ��Ċi�[
                    Ind = MultiDevelop[0] / 10;
                    //Debug.Log("�H��:"+Ind);
                    break;
                // HP
                case 1:
                    // 5����1�̒l�ɂ��Ċi�[
                    Com = MultiDevelop[1] / 5;
                    //Debug.Log("����:" + Com);
                    break;
                // CT
                case 2:
                    // CT_multiply�̒l�Ŋ������l���i�[
                    Agr = MultiDevelop[2] * CT_multiply;
                    //Debug.Log("�_��:" + Agr);
                    break;
            }

            for (int skill = 0; skill < 4; skill++)
            {
                CreateShip.Attack[skill] = CreateShip.Attack[skill] + Ind;
            }

        }
        // �X�e�[�^�X���f����
        SaveSystem.Instance.MainShipData.HP = Com + SaveSystem.Instance.MainShipData.HP;
        for (int i = 0; i < 4; i++)
        {
            newCT[i] = Agr + CreateShip.CT[i];
            newAttack[i] = Ind + CreateShip.Attack[i];
            
        }
        // �X�e�[�^�X�\��
        StatusText[0].SetText("Point : {0}", Ind);
        StatusText[1].SetText("Point : {0}", Com);
        StatusText[2].SetText("Point : {0}", Agr);

        // �J���|�C���g���Z����
        SaveSystem.Instance.MainShipData.IndSum = SaveSystem.Instance.MainShipData.IndSum + Ind;
        SaveSystem.Instance.MainShipData.ComSum = SaveSystem.Instance.MainShipData.ComSum + Com;
        SaveSystem.Instance.MainShipData.AgrSum = SaveSystem.Instance.MainShipData.AgrSum + Agr;

        // ���݂̃X�e�[�^�X�\��
        NowStatusText[0].SetText("Point : {0}", SaveSystem.Instance.MainShipData.HP);

        // �l�̃Z�[�u
        SaveSystem.Instance.Save();

        Debug.Log("previwHP:" + Com);

        

    }
}
