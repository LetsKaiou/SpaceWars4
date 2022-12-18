using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateShip : MonoBehaviour
{
    // ���̃X�N���v�g�̕ϐ��Q�Ɨp
    private Special_info specialInfo;
    private FriendShipInfo frindInfo;
    private child childcs;
    public SP_Bullet sp_bullet;

    // ���C���͂̈ʒu�l���p
    //[SerializeField] private GameObject MainShip;
    private Vector3[] MainPos = new Vector3[4];

    // ��������D�̏��
    [SerializeField] private Vector3[] CreatePos = new Vector3[4];
    [SerializeField] private GameObject[] CreateShips;
    [SerializeField] GameObject[] Clones = new GameObject[6];
    private int[] Num = new int[4];

    // CSV�f�[�^�i�[�p�ϐ�
    [SerializeField] private Image[] image;
    private string[] Name = new string[100];                // ���O
    public static int[] Attack = new int[100];              // �U����
    public static float[] CT = new float[100];              // �N�[���^�C��
    public float[] Range = new float[100];                  // �˒�(�e��������܂ł̎���)
    private string[] Explanatory = new string[100];         // ����U���̐�����

    public int[] HP = new int[4];
    public int[] DEF = new int[4];
    public int[] SPD = new int[4];

    void Awake()
    {
        specialInfo = new Special_info();
        frindInfo = new FriendShipInfo();
        specialInfo.Delete();  // ��x�f�[�^���폜
        specialInfo.Init();    // �ēx�ǂݍ���
        frindInfo.Delete();    // ��x�f�[�^���폜
        frindInfo.Init();      // �ēx�ǂݍ���


        // �e�I�u�W�F�N�g��T��
        GameObject parentObject = GameObject.FindGameObjectWithTag("Player");

        // ����U���̉摜�\������
        for (int i = 0; i < Select_Special.SelectSpecial.Length; i++)
        {
            // CSV����摜�������Ă��ĕ\��
            image[i].sprite = Resources.Load<Sprite>(specialInfo.Image[int.Parse(Select_Special.SelectSpecial[i])]);
            ReadInfo(i);
        }

        // �����D�̃X�e�[�^�X�Q�Ə���
        for (int i = 0; i < SelectShip.SelectShipNum.Length; i++)
        {
            Num[i] = int.Parse(SelectShip.SelectShipNum[i]);
            ReadStatus(i);
        }

        for (int i = 0; i < 4; i++)
        {
            Clones[i] = Instantiate(CreateShips[i], CreatePos[i], Quaternion.identity);
            // �����蔻��擾�p�̃^�O�ƃX�e�[�^�X�𐶐����Ɋ��蓖�Ă�
            switch (i)
            {
                case 0:
                    Clones[i].tag = "FriendShip1";
                    Clones[i].transform.parent = parentObject.transform;
                    Clones[i].gameObject.GetComponent<child>().SetStatus(HP[i]);
                    break;
                case 1:
                    Clones[i].tag = "FriendShip2";
                    Clones[i].transform.parent = parentObject.transform;
                    Clones[i].gameObject.GetComponent<child>().SetStatus(HP[i]);
                    break;
                case 2:
                    Clones[i].tag = "FriendShip3";
                    Clones[i].transform.parent = parentObject.transform;
                    Clones[i].gameObject.GetComponent<child>().SetStatus(HP[i]);
                    break;
                case 3:
                    Clones[i].tag = "FriendShip4";
                    Clones[i].transform.parent = parentObject.transform;
                    Clones[i].gameObject.GetComponent<child>().SetStatus(HP[i]);
                    break;
            }

           
        }
    }

    // ����U����CSV�f�[�^���i�[���鏈��
    public void ReadInfo(int num)
    {

        Attack[num] = specialInfo.Attack[int.Parse(Select_Special.SelectSpecial[num])];
        CT[num] = specialInfo.CT[int.Parse(Select_Special.SelectSpecial[num])];
        Range[num] = specialInfo.Range[int.Parse(Select_Special.SelectSpecial[num])];
    }
    // �����@��CSV�f�[�^���i�[���鏈��
    public void ReadStatus(int num)
    {
        HP[num] = frindInfo.HP[int.Parse(SelectShip.SelectShipNum[num])];
        DEF[num] = frindInfo.DEF[int.Parse(SelectShip.SelectShipNum[num])];
        SPD[num] = frindInfo.SPD[int.Parse(SelectShip.SelectShipNum[num])];
    }

    // ����U���̍U���͂�Ԃ�
    public int GetSPAttack(int Num)
    {
        return Attack[Num];
    }
    // ����U����CT��Ԃ�
    public float GetCT(int CTNum)
    {
        return CT[CTNum];
    }
    // ����U���Ɏ˒���Ԃ�
    public float GetSPRange(int Num)
    {
        return Range[Num];
    }
    // �q�@�̃X�s�[�h��Ԃ�
    public int GetSPD(int Num)
    {
        return SPD[Num];
    }

}
