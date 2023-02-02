using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;


public class Player : MonoBehaviour
{
    // �Z�[�u�p�̓��͏ȗ�
    private SaveSystem System => SaveSystem.Instance;
    private MainShipData Data => System.MainShipData;
    // ���̃X�N���v�g�Q�Ɨp
    public SP_Bullet sp_Bullet;
    public CreateShip createcs;
    public CoolDown CoolDownScript;
    // Player���
    public float speed;
    public  int Player_HP = 60;
    public static int MaxHP;
    public Slider hp_slider;
    public bool isTurn = false;
    public static float ScoreHP;
    private bool isSecond;
    public int Defence;
    // �e�̎�ށA���ˈʒu
    [SerializeField] private GameObject[] Bullet;
    [SerializeField] private GameObject bulletPoint;
    public GameObject[] Clones = new GameObject[256];
    private GameObject P_Bullet;
    // �o�ߎ��Ԏ擾�p�ϐ�
    [SerializeField] private float _timeInterval;
    private float _timeElapsed;
    // �}�E�X�z�C�[���̉�]���擾�p�ϐ�
    private float MousWheel;
    // ����U���p�i�[�ϐ�
    [SerializeField]private float[] sp_Range = new float[4];
    public int BulletSelect;   
    public List<bool> Reload = new List<bool>();
    // �_���[�W�����p�ϐ�
    private bool DamageHit;
    // �A�j���[�V�����i�[�p
    [SerializeField] private Animator SP_Anim;

    private bool shotcheck;

    public float _anglePerFrame = 0.1f;
    [SerializeField] private Material skybox;
    private Vector3 vec;

    public static Player instance;

    public ParticleSystem JetEffect;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        //skybox.SetVector("_Rotation", new Vector3(1, 0, 0));
        //skybox.SetVector("_Speed", new Vector3(0, 0, 0));
        //vec = new Vector3(1, 0, 0);

        ScoreHP = 0;

        Player_HP = Data.HP;

        // ������
        hp_slider.maxValue = Player_HP;
        
        hp_slider.value = Player_HP;
        for (int i = 0; i < 4; i++)
        {
            speed += createcs.SPD[i];
        }


        SP_Anim.GetComponent<Animator>();

        // List�ɏ���ǉ�(ture:���ˉ\�Afalse:�N�[���^�C����)
        Reload.Add(true);   // ����U��1
        Reload.Add(true);   // ����U��2
        Reload.Add(true);   // ����U��3
        Reload.Add(true);   // ����U��4
        //Debug.Log(Reload.Count);

        // �G�t�F�N�g�p
        JetEffect.Pause();
    }

    void Update()
    {

        //skybox.SetVector("_Speed", vec);
        // �ړ�����
        #region �ړ�
        if (Input.GetKey(KeyCode.W) && isTurn == false)
        {
            transform.position += transform.forward * speed * Time.deltaTime;

            //vec = new Vector3(1, 0, 0);
            //�G�t�F�N�g�p
            JetEffect.Play();
        }
        //else
        //{
        //    vec = new Vector3(0, 0, 0);
        //}
        if (Input.GetKey(KeyCode.S) && isTurn == false)
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
            JetEffect.Stop();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadScene("Result");
        }
        #endregion

        // ����U���I������
        #region ����U��
        // �}�E�X�̉�]���擾(��]�����邽�т�1���������� �f�t�H���g��0)
        MousWheel += Input.GetAxis("Mouse ScrollWheel");
        MousWheel = Mathf.Floor(MousWheel);
        MousWheel = Mathf.Clamp(MousWheel, 0.0f, 4.0f);
        //SP_Anim.SetInteger("Param", (int)MousWheel);
        #endregion

        // �e����
        #region �e�̔���
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed > _timeInterval)
        {
            shotcheck = true;
            //shot();
            // �o�ߎ��Ԃ����ɖ߂�
            _timeElapsed = 0f;
        }
        #endregion
        // ����U���̒e�I�������Ɣ��ˏ����ւ̈ړ�(�}�E�X���N���b�N�Ŕ���)
        #region ����U���ݒ�p
        if (MousWheel > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {

                int AnimNum = SP_Anim.GetInteger((int)MousWheel);
                BulletSelect = (int)MousWheel;
                if (Reload[BulletSelect - 1] == true)
                {
                    SpecialAttack();
                }
            }
        }
        #endregion
        // �v���C���[�̗̑͏���
        #region HP����
        // HP�̃X���C�_�[����
        //hp_slider.value = MaxHP;
        if (hp_slider.value <= 0)
        {
            GoResult.isWin = false;
            SceneManager.LoadScene("Result");
        }
        #endregion
    }

    // �ʏ�e���ˏ����֐�
    public void shot()
    {
        if(shotcheck == true)
        {
            Debug.Log("ShorIN");
            //�e���o��������ʒu���擾
            Vector3 placePosition = this.transform.position;
            //�o��������ʒu�����炷�l
            Vector3 offsetGun = new Vector3(0, 0, 8);

            //����̌����ɍ��킹�Ēe�̌���������
            Quaternion q1 = this.transform.rotation;
            //�e��90�x��]�����鏈��
            Quaternion q2 = Quaternion.AngleAxis(90, new Vector3(1, 0, 0));
            Quaternion q = q1 * q2;

            //�e���o��������ʒu�𒲐�
            placePosition = q1 * offsetGun + placePosition;
            //�e����
            P_Bullet = Instantiate(Bullet[0], bulletPoint.transform.position, transform.rotation);
            P_Bullet.tag = "P_bullet";
            shotcheck = false;
        }
    }

    // ����U�������֐�(�����͔��˂������U���̒e�̎��)
    public void SpecialAttack()
    {
        // �I����������U����n��
        CoolDownScript.SetSpecialNum();

        // ���ł܂ł̎��Ԃ���
        sp_Range[BulletSelect - 1] = createcs.GetSPRange(BulletSelect - 1);
        
        // ���ˌ�false�ɕύX
        Reload[BulletSelect - 1] = false;

        //�e���o��������ʒu���擾
        Vector3 placePosition = this.transform.position;
        //�o��������ʒu�����炷�l
        Vector3 offsetGun = new Vector3(0, 0, 8);

        //����̌����ɍ��킹�Ēe�̌���������
        Quaternion q1 = this.transform.rotation;
        //�e��90�x��]�����鏈��
        Quaternion q2 = Quaternion.AngleAxis(90, new Vector3(1, 0, 0));
        Quaternion q = q1 * q2;

        //�e���o��������ʒu�𒲐�
        placePosition = q1 * offsetGun + placePosition;
        Quaternion a = Quaternion.identity;
        //�e����
        //Clones[BulletSelect-1] = Instantiate(Bullet[BulletSelect], bulletPoint.transform.position, transform.rotation);

        // �g��������U����ID��Ԃ�
        Skill.instance.StartEffect(BulletSelect);

        // �^�O�̊��蓖��
        //switch (BulletSelect - 1)
        //{
        //    case 0:
        //        Clones[BulletSelect - 1].tag = "SP1";
        //        break;
        //    case 1:
        //        Clones[BulletSelect - 1].tag = "SP2";
        //        break;
        //    case 2:
        //        Clones[BulletSelect - 1].tag = "SP3";
        //        break;
        //    case 3:
        //        Clones[BulletSelect - 1].tag = "SP4";
        //        break;
        //}

        //Destroy();
    }

    public void GetSocre_HP()
    {
        ScoreHP = hp_slider.value / Player_HP * 100;
    }

    // �_���[�W�v�Z����
    public void P_Damage(int damage)
    {
        damage = damage - Defence;  // �h��͕��_���[�W����
        hp_slider.value -= damage;
    }

    // BulletSelect��n��
    public int GetSpecialNum()
    {
        return BulletSelect;
    }


    // ���˂�������U��������
    public void Destroy()
    {
        Destroy(Clones[BulletSelect - 1], sp_Range[BulletSelect - 1]);
    }

    // �_���[�W����p�֐�
    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "E_bullet" || other.gameObject.tag == "C_bullet")
    //    {
    //        DamageHit = false;
    //        Destroy(other.gameObject);
    //        if (DamageHit == false)
    //        {
    //            Debug.Log(other.tag);
    //            P_Damage(5 - Defence);
    //            DamageHit = true;
    //        }
    //    }
    //    if (other.gameObject.tag == "E_SP")
    //    {
    //        DamageHit = false;
    //        Destroy(other.gameObject);
    //        if (DamageHit == false)
    //        {
    //            Debug.Log(other.tag);
    //            P_Damage(20);
    //            DamageHit = true;
    //        }
    //    }
    //}
}

