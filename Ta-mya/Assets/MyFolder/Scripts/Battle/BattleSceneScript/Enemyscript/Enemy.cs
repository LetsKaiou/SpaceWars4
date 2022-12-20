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
    // �G�̏��
    private int Enemy_HP = 100;
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
    public GameObject bulletPoint;
    [SerializeField] private CreateShip createship;
    // �v���C���[�̍��W�擾
    [SerializeField]private GameObject target;
    // Start is called before the first frame update
    void Start()
    {

        angle = gameObject.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        _timeElapsed += Time.deltaTime;
        _RtimeElapsed += Time.deltaTime;

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

        if (Enemy_HP <= 0)
        {
            SceneManager.LoadScene("Result");
        }

    }
    public void shot()
    {
        if(shotcheck == true)
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

    public void E_Damage(int damage)
    {
        this.Enemy_HP -= damage;
    }

    #region �U��Hit����
    public void OnTriggerEnter(Collider other)
    {
        // �ʏ�U��Hit����
        if (other.gameObject.tag == "P_bullet")
        {
            Debug.Log("INEHit");
            DamageHit = false;
            Destroy(other.gameObject);
            if (DamageHit == false)
            {
                E_Damage(5);
                DamageHit = true;
            }
            Debug.Log("�_���[�W:" + 5);
            Debug.Log("Ehp:" + Enemy_HP);
        }
        // ����U��Hit����
        if (other.gameObject.tag == "SP1")
        {
            DamageHit = false;
            Destroy(other.gameObject);
            //if (DamageHit == false)
            //{
            //    E_Damage(CreateShip.Attack[0]);
            //    DamageHit = true;
            //}
            Enemy_HP = Enemy_HP - SP_Use1.instance.SP1Damage();
            Debug.Log("�_���[�W:" + CreateShip.Attack[0]);
            Debug.Log("Ehp:" + Enemy_HP);
        }
        if (other.gameObject.tag == "SP2")
        {
            DamageHit = false;
            Destroy(other.gameObject);
            //if (DamageHit == false)
            //{
            //    E_Damage(CreateShip.Attack[1]);
            //    DamageHit = true;
            //}
            Enemy_HP = Enemy_HP - SP_Use1.instance.SP1Damage();
            Debug.Log("�_���[�W:" + CreateShip.Attack[1]);
            Debug.Log("Ehp:" + Enemy_HP);
        }
        if (other.gameObject.tag == "SP3")
        {
            DamageHit = false;
            Destroy(other.gameObject);
            //if (DamageHit == false)
            //{
            //    E_Damage(CreateShip.Attack[2]);
            //    DamageHit = true;
            //}
            Enemy_HP = Enemy_HP - SP_Use1.instance.SP1Damage();
            Debug.Log("�_���[�W:" + CreateShip.Attack[2]);
            Debug.Log("Ehp:" + Enemy_HP);
        }
        if (other.gameObject.tag == "SP4")
        {
            DamageHit = false;
            Destroy(other.gameObject);
            //if (DamageHit == false)
            //{
            //    E_Damage(CreateShip.Attack[3]);
            //    DamageHit = true;
            //}
            Enemy_HP = Enemy_HP - SP_Use1.instance.SP1Damage();
            Debug.Log("�_���[�W:" + CreateShip.Attack[3]);
            Debug.Log("Ehp:" + Enemy_HP);
        }
        
    }
    #endregion

}
