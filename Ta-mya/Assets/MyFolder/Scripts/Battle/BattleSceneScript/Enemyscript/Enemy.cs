using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    // �e�̔��ˊԊu
    [SerializeField] private float _timeInterval;
    // �o�ߎ��Ԏ擾�p�ϐ�
    private float _timeElapsed;
    [SerializeField] private float _RotateTime;
    private float _RtimeElapsed;
    [SerializeField] private float CoolTime;
    private float _CTTime;
    // �G�̏��
    [SerializeField] private int[] Enemy_HP = new int[4];
    [SerializeField] private float speed;
    public bool In;
    public bool PlayerFind;
    public bool StatusNum;
    private Vector3 angle;
    private float setangle;
    private float Maxangle;
    Vector3 NowRotate;
    // �_���[�W���󂯂Ă邩�ǂ���
    private bool DamageHit;
    // �e�Ɋւ���ϐ�
    private GameObject E_Bullet;
    [SerializeField] private GameObject[] Bullet;
    private bool shotcheck;
    private bool isSP;
    public GameObject bulletPoint;
    [SerializeField] private CreateShip createship;
    // �v���C���[�̍��W�擾
    [SerializeField]private GameObject target;

    private int EnemyCount;
    public static Enemy instance;

    //�|�������̃G�t�F�N�g
    public GameObject breakEffect;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < Enemy_HP.Length; i++)
        {
            Enemy_HP[i] = 100;
        }
        EnemyCount = CreateEnemyShip.instance.Counter;
        angle = gameObject.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        _timeElapsed += Time.deltaTime;
        _RtimeElapsed += Time.deltaTime;
        _CTTime += Time.deltaTime;
        if (_RtimeElapsed > _RotateTime)
        {
            Maxangle = Random.Range(0, 360);
            angle = new Vector3(0, Maxangle, 0);
            // �o�ߎ��Ԃ����ɖ߂�
            _RtimeElapsed = 0f;
        }

        if (_timeElapsed > _timeInterval)
        {
            shotcheck = true;
            // �o�ߎ��Ԃ����ɖ߂�
            _timeElapsed = 0f;
        }

        if(_CTTime > CoolTime)
        {
            isSP = true;
            _CTTime = 0f;
        }
        // Player�̕����Ɍ������Ĉړ����鏈��
        if (PlayerFind == true)
        {
            // �Ώە��Ǝ������g�̍��W����x�N�g�����Z�o
            Vector3 vector3 = target.transform.position - this.transform.position;
            // Quaternion(��]�l)���擾
            Quaternion quaternion = Quaternion.LookRotation(vector3);
            // �Z�o������]�l�����̃Q�[���I�u�W�F�N�g��rotation�ɑ��
            this.transform.rotation = quaternion;
            if (In == false)
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }
        else if(PlayerFind == false)
        {
            transform.DORotate(angle, 4);
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        if (EnemyCount <= 0)
        {
            PreviewScore.instance.isWin = true;
            SceneManager.LoadScene("Result");
        }

    }
    public void shot()
    {
        if(isSP == true)
        {
            //�e���o��������ʒu���擾
            Vector3 placePosition = this.transform.position;
            //�o��������ʒu�����炷�l
            Vector3 offsetGun = new Vector3(0, 0, 8);

            //����̌����ɍ��킹�Ēe�̌���������
            Quaternion q1 = this.transform.rotation;
            //�e��90�x��]�����鏈��
            Quaternion q2 = Quaternion.AngleAxis(90, new Vector3(0, 0, 0));
            Quaternion q = q1 * q2;

            //�e���o��������ʒu�𒲐�
            placePosition = q1 * offsetGun + placePosition;
            //�e����
            E_Bullet = Instantiate(Bullet[1], bulletPoint.transform.position, transform.rotation);
            E_Bullet.tag = "E_SP";
            isSP = false;
        }

    }

    public void SPShot()
    {
        if (shotcheck == true)
        {
            //�e���o��������ʒu���擾
            Vector3 placePosition = this.transform.position;
            //�o��������ʒu�����炷�l
            Vector3 offsetGun = new Vector3(0, 0, 8);

            //����̌����ɍ��킹�Ēe�̌���������
            Quaternion q1 = this.transform.rotation;
            //�e��90�x��]�����鏈��
            Quaternion q2 = Quaternion.AngleAxis(90, new Vector3(0, 0, 0));
            Quaternion q = q1 * q2;

            //�e���o��������ʒu�𒲐�
            placePosition = q1 * offsetGun + placePosition;
            //�e����
            E_Bullet = Instantiate(Bullet[0], bulletPoint.transform.position, transform.rotation);
            E_Bullet.tag = "E_bullet";
            shotcheck = false;
        }
    }

    public void E_Damage(int damage, int Numbre)
    {
        switch (Numbre)
        {
            case 0:
                Enemy_HP[0] -= damage;
                if(Enemy_HP[0] <= 0)
                {
                    Destroy(this.gameObject);
                    EnemyCount--;
                }
                break;
            case 1:
                Enemy_HP[1] -= damage;
                if (Enemy_HP[1] <= 0)
                {
                    Destroy(this.gameObject);
                    EnemyCount--;
                }
                break;
            case 2:
                Enemy_HP[2] -= damage;
                if (Enemy_HP[2] <= 0)
                {
                    Destroy(this.gameObject);
                    EnemyCount--;
                }
                break;
            case 3:
                Enemy_HP[3] -= damage;
                if (Enemy_HP[3] <= 0)
                {
                    Destroy(this.gameObject);
                    EnemyCount--;
                }
                break;
        }
    }
    
    //���j�G�t�F�N�g�𐶐�����
    void BreakEffect()
    {
        //���j�G�t�F�N�g�𐶐�����
        GameObject effect = Instantiate(breakEffect) as GameObject;
        //�G�t�F�N�g����������ꏊ�����肷��(�G�I�u�W�F�N�g�̏ꏊ)
        effect.transform.position = gameObject.transform.position;
    }

}
