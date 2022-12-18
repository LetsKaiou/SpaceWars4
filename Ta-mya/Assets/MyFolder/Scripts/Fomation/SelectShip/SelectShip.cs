using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectShip : MonoBehaviour
{

    private FriendShipInfo statusInfo;
    // static�ϐ��錾
    public static string[] SelectShipNum = new string[4];
    // �I�����ꂽ�@�̂̐��J�E���g�p
    public int Count;
    // �{�^���đI���J�E���g�p
    private int DisCount;
    // �{�^���i�[�p
    [SerializeField] private Button[] buttun;
    // image�i�[�p
    [SerializeField] private Image[] image;
    public Image[] ShipImage;
    // image�ɓ����摜�i�[�p
    [SerializeField] private Sprite[] sprite;
    // Outline�i�[
    [SerializeField] private Animator[] animator;
    // �v���r���[�X�N���v�g�擾�p
    private GameObject Preview;
    private GameObject Button;
    // 4��I������Ă��邩�ǂ����m�F�p
    private bool Loop;
    [SerializeField] private ShipDatabase shipData;
    int check;
    public bool[] clickok = new bool[10];


    void Start()
    {

        statusInfo = new FriendShipInfo();
        statusInfo.Delete();
        statusInfo.Init();
        // ������
        string[] SelectShipNum = new string[] { "", "", "","" };
        //Animator[] animator = new Animator[3];
        Count = 0;
        Loop = false;
        

        foreach (DropShip dropShip in shipData.SkillList)
        {
            if (dropShip.isGet == true)
            {
                ShipImage[check].sprite = Resources.Load<Sprite>(statusInfo.Image[check + 1]);
                clickok[check] = true;
            }
            else
            {
                //SelectImage[check].enabled = false;
                ShipImage[check].sprite = Resources.Load<Sprite>(statusInfo.Image[check + 1]);
                ShipImage[check].color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
            }
            check++;
        }


        // �v���r���[�\���Ɏg�p
        Preview = GameObject.Find("ButtonCanvas");
        Button = GameObject.Find("Image");
        //Button.GetComponent<AnimationControl>().AnimStart();
    }

    private void Update()
    {
        Button.GetComponent<AnimationControl>().ShipAnimStart();
        //animator[Count].SetBool("select", true);
    }

    // �V���O���N���b�N���������̏���(�v���r���[�̕\��)
    public void Click(int ShipNumber)
    {
        if (clickok[ShipNumber - 1] == true)
        {
            Preview.GetComponent<FriendShipSelect>().Display(ShipNumber);
        }
        else
        {
            FriendShipSelect.instance.Display(0);
        }
        // �v���r���[�\���p�X�N���v�g�ɏ��𑗂�
        //Preview.GetComponent<FriendShipSelect>().Display(ShipNumber);
    }

    // �_�u���N���b�N���������̏���(�D��Ґ��ɒǉ�)
    public void DoubleClick(string ShipNum)
    {

        // 4�Ԗڂ̔z��܂œ��B�����烊�Z�b�g

        // �ēx�{�^����������悤�ɂ��鏈��
        if (Loop == true)
        {
            buttun[int.Parse(SelectShipNum[Count]) - 1].interactable = true;
        }
        // Count�Ԗڂ̔z��ɉ������{�^���̈������
        SelectShipNum[Count] = ShipNum;
        //Debug.Log(Count + "�Ԗڂ̔z���" + ShipNum + "���");
        // �{�^������
        

        //sprite[] = Resources.Load<Sprite>();
        //image = GetComponent<Image>();
        //image[Count].sprite = sprite[int.Parse(ShipNum)-1];
        if (clickok[int.Parse(ShipNum) - 1] == true)
        {
            buttun[int.Parse(ShipNum) - 1].interactable = false;    // �{�^���ɐG��Ȃ�����
            Button.GetComponent<AnimationControl>().ShipAnimStop();
            DisplayImage(int.Parse(ShipNum));

            // �J�E���g��i�߂�
            Count++;
            if (Count >= 4)
            {
                Count = 0;
                Loop = true;
            }
        }
    }
    public void DisplayImage(int Num)
    {
        if (clickok[Num - 1] == true)
        {
            // CSV����摜�������Ă��ĕ\��
            image[Count].sprite = Resources.Load<Sprite>(statusInfo.Image[Num]);
            // �J�E���g��i�߂�
            //Count++;
            //if (Count >= 4)
            //{
            //    Count = 0;
            //}
        }
    }

}
