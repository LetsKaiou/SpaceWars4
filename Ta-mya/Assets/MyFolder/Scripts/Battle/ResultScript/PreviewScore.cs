using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreviewScore : MonoBehaviour
{
    // ���X�N���v�g�̕ϐ��擾�p
    public Player playercs;
    public CreateShip createcs;

    // �J���|�C���g�\���p
    [SerializeField] private TextMeshProUGUI[] DeveropmentText;
    private int[] DevelopNum = new int[3];

    // �J���|�C���g����X�e�[�^�X�ύX�p
    public  int[] MultiDevelop = new int[3];
    [SerializeField] private int CT_multiply;
    [SerializeField] private TextMeshProUGUI[] StatusUpText;
    // ���ꂼ��̊J���|�C���g�i�[
    public static int Ind;  // �H�ƁF����U���̍U����
    public static int Com;  // ���ƁF���C���D�̗̑�
    public static int Agr;  // �_�ƁF����U����CT


    void Start()
    {
        for (int i = 0; i < DeveropmentText.Length; i++)
        {
            // �J���|�C���g�̒l��\��
            DeveropmentText[i].SetText("Point : {0}", SliderControl.Now_value[i]);
            // �J���|�C���g�����ꂼ��̕ϐ��Ɋ��蓖�Ă鏈��
            DevelopNum[i] = SliderControl.Now_value[i];
            MultiDevelop[i] = DevelopNum[i];
            switch (i)
            {
                case 0:
                    // 10����1�̒l�ɂ��Ċi�[
                    Ind = MultiDevelop[0] / 10;
                    break;
                case 1:
                    // 5����1�̒l�ɂ��Ċi�[
                    Com = MultiDevelop[1] / 5;
                    break;
                case 2:
                    // CT_multiply�̒l�Ŋ������l���i�[
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
