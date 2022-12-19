using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select_Special : MonoBehaviour
{
    private Special_info specialInfo;
    // static�ϐ��錾
    public static string[] SelectSpecial = new string[4];
    // �I�����ꂽ����U���̐��J�E���g�p
    public int Count;
    // �{�^���đI���J�E���g�p
    private int DisCount;
    // �{�^���i�[�p
    [SerializeField] private Button[] buttun = new Button[20];
    // image�i�[�p
    [SerializeField] private Image[] image;
    // image�ɓ����摜�i�[�p
    [SerializeField] private Sprite[] sprite;
    // Outline�i�[
    [SerializeField] private Animator[] animator;
    // �X�N���v�g�擾�p
    private GameObject Preview;
    private GameObject Button;
    // 4��I������Ă��邩�ǂ����m�F�p
    private bool Loop;
    // �������Ă������U���̃J�E���g�p
    private int OpenSkill;
    
    void Start()
    {
        
        // ������
        string[] SelectSpecial = new string[] { "", "", "", "" };
        //buttun = new Button[OpenSkill];
        //Animator[] animator = new Animator[3];
        Count = 0;
        Loop = false;
        specialInfo = new Special_info();
        Debug.Log("Select_Specials_Start");
        //animator[Count].SetBool("select", false);
        Debug.Log("a");
        // �v���r���[�\���Ɏg�p
        Preview = GameObject.Find("SceneImage");
        Button = GameObject.Find("SP_Button1");
        //Button.GetComponent<AnimationControl>().AnimStart();

    }

    private void Update()
    {
        Button.GetComponent<AnimationControl>().SpAnimStart();
        //Button.GetComponent<AnimationControl>().ShipAnimStart();
    }

    // �V���O���N���b�N���������̏���(�v���r���[�̕\��)
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

        // �v���r���[�\���p�X�N���v�g�ɏ��𑗂�
        //Preview.GetComponent<SpecialPrevrew>().Display(SpecialNumber);
    }

    // �_�u���N���b�N���������̏���(�D��Ґ��ɒǉ�)
    public void DoubleClick(string SpecialNum)
    {
        // 4�Ԗڂ̔z��܂œ��B�����烊�Z�b�g

        // �ēx�{�^����������悤�ɂ��鏈��
        if (Loop == true)
        {
            buttun[int.Parse(SelectSpecial[Count]) - 1].interactable = true;
        }
        // Count�Ԗڂ̔z��ɉ������{�^���̈������
        SelectSpecial[Count] = SpecialNum;
        //Debug.Log(Count + "�Ԗڂ̔z���" + ShipNum + "���");
        // �{�^������

        // �v���r���[�\���p�X�N���v�g�ɏ��𑗂�
        if (SpecialPrevrew.instance.clickok[int.Parse(SpecialNum) - 1] == true)
        {
            buttun[int.Parse(SpecialNum) - 1].interactable = false;    // �{�^���ɐG��Ȃ�����
            Preview.GetComponent<SpecialPrevrew>().DisplayImage(int.Parse(SpecialNum));
            Button.GetComponent<AnimationControl>().SpAnimStop();
            // �J�E���g��i�߂�
            Count++;
            if (Count >= 4)
            {
                Count = 0;
                Loop = true;
            }
        }

    }
}
