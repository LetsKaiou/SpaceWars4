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
    [SerializeField] private float BuffTime;  // �o�t�̌��ʎ���
    // �̗̓A�b�v
    [SerializeField] private int HealthUpPoint;
    // �X�s�[�h�A�b�v
    [SerializeField] private float SpeedUpPoint;
    // �h��̓A�b�v
    [SerializeField] private int DefencePoint;

    private Player py;

    private int[] SPID = new int[4];

    // �f�[�^�x�[�X�擾�p�ϐ�
    [SerializeField] private SkillDatabase skillData;
    // �Đ�����G�t�F�N�g������郊�X�g
    private List<GameObject> EffectObjList = new List<GameObject>();
    private List<int> EffectIDList = new List<int>();


    public static Skill instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        // �z��̏�����
        EffectObjList.Clear();

        // �I����������U����ID��z��ɑ��
        for (int i = 0; i < SPID.Length; i++)
        {
            SPID[i] = int.Parse(Select_Special.SelectSpecial[i]);
        }

        // �I����������U���Ɠ���ID�̃G�t�F�N�g�̃I�u�W�F�N�g��ID�����X�g�ɒǉ�
        foreach (DropSkill dropSkill in skillData.SkillList)
        {
            for (int i = 0; i < SPID.Length; i++)
            {
                if(dropSkill.id == SPID[i])
                {
                    EffectObjList.Add(dropSkill.EffectObj);
                    EffectIDList.Add(dropSkill.id);
                    Debug.Log("ID:" + dropSkill.id);
                }
            }
        }
    }

    private void Update()
    {
        if (isRegene == true)
        {
            RegeneCount += Time.deltaTime;
        }
        if (RegeneCount > BuffTime)
        {
            Player.instance.Player_HP += RegenePoint;
            RegeneCount = 0f;
            isRegene = false;
        }
    }


    public void StartEffect(int UseSPID)
    {
        Instantiate(EffectObjList[UseSPID-1], this.transform.position, Quaternion.identity); //�p�[�e�B�N���p�Q�[���I�u�W�F�N�g
        switch(EffectIDList[UseSPID - 1])
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                Heal();
                break;
            case 11:
                StatusHeal();
                break;
            case 12:
                Baria();
                break;
            case 13:
                Regenerate();
                break;
            case 14:
                Warp();
                break;
            case 15:
                HelthUP();
                break;
            case 16:
                SpeedUP();
                break;
            case 17:
                DefenceUP();
                break;
        }
    }

    // HP�� ID:10
    public void Heal()
    {
        py = GameObject.Find("Yamato").GetComponent<Player>();
        Player.instance.hp_slider.value += HealPoint;
    }
    // ��Ԉُ�� ID:11
    public void StatusHeal()
    {
        // ��Ԉُ�������ɍ쐬 �� ��Ԉُ�ɂȂ�����true�ɂ���
        // ��Ԉُ��bool��false�ɕύX
    }
    // �o���A ID:12
    public void Baria()
    {
        // ��p�X�e�[�^�X���v���C���[�Œ�`���Ă��̒l������E����������
    }
    // ���W�F�l ID:13
    public void Regenerate()
    {
        isRegene = true;
    }
    // ���[�v ID:14
    public void Warp()
    {
        // �d�l�킩��Ȃ�
        // ����̏ꏊ�ɖ����̑D�ƈꏏ�Ƀ��[�v������
    }
    // �ő�̗̓A�b�v ID:15
    public void HelthUP()
    {
        Player.instance.hp_slider.maxValue += HealthUpPoint;
    }
    // �X�s�[�h�A�b�v ID:16
    public void SpeedUP()
    {
        Player.instance.speed += SpeedUpPoint;
    }
    // �h��̓A�b�v ID:17
    public void DefenceUP()
    {
        Player.instance.Defence += DefencePoint;
    }
}
