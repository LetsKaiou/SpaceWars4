using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    // Heal
    [SerializeField] private int HealPoint;
    // �o���A
    [SerializeField] private int BariaPoint;
    // ���W�F�l
    private bool isRegene;                      // ���W�F�l���Ă邩�ǂ���
    [SerializeField] private int RegenePoint;   // 1��̃��W�F�l�̉񕜗�
    private float RegeneCount; 
    [SerializeField] private float RegeneTime;  // ���W�F�l���鎞��
    // �̗̓A�b�v
    [SerializeField] private int HealthUpPoint;
    // �X�s�[�h�A�b�v
    [SerializeField] private float SpeedUpPoint;
    // �h��̓A�b�v
    [SerializeField] private int DefencePoint;

    public static Skill instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (isRegene == true)
        {
            RegeneCount += Time.deltaTime;
        }
        if (RegeneCount > RegeneTime)
        {
            Player.instance.Player_HP += RegenePoint;
            RegeneCount = 0f;
            isRegene = false;
        }
    }


    // HP��
    public void Heal()
    {
        Player.instance.Player_HP += HealPoint;
    }
    // ��Ԉُ��
    public void StatusHeal()
    {
        // ��Ԉُ�������ɍ쐬 �� ��Ԉُ�ɂȂ�����true�ɂ���
        // ��Ԉُ��bool��false�ɕύX
    }
    // �o���A
    public void Baria()
    {
        // ��p�X�e�[�^�X���v���C���[�Œ�`���Ă��̒l������E����������
    }
    // ���W�F�l
    public void Regenerate()
    {
        isRegene = true;
    }
    // ���[�v
    public void Warp()
    {
        // �d�l�킩��Ȃ�
        // ����̏ꏊ�ɖ����̑D�ƈꏏ�Ƀ��[�v������
    }
    // �ő�̗̓A�b�v
    public void HelthUP()
    {
        Player.instance.hp_slider.maxValue += HealthUpPoint;
    }
    // �X�s�[�h�A�b�v
    public void SpeedUP()
    {
        Player.instance.speed += SpeedUpPoint;
    }
    // �h��̓A�b�v
    public void DefenceUP()
    {
        Player.instance.Defence += DefencePoint;
    }
}
