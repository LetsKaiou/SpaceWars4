using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    // �e�̔��ˊԊu
    [SerializeField] private float _timeInterval;
    // �o�ߎ��Ԏ擾�p�ϐ�
    private float _timeElapsed;
    // �G�̏��
    private int Enemy_HP = 50;
    [SerializeField] private float speed;
    public bool In;
    public int StatusNum;
    // �_���[�W���󂯂Ă邩�ǂ���
    private bool DamageHit;
    // �e�Ɋւ���ϐ�
    [SerializeField] private GameObject[] Bullet;
    private bool shotcheck;
    public GameObject bulletPoint;
    [SerializeField] private CreateShip createship;
    // �v���C���[�̍��W�擾
    [SerializeField]private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed > _timeInterval)
        {
            shotcheck = true;
            // �o�ߎ��Ԃ����ɖ߂�
            _timeElapsed = 0f;
        }

        // �Ώە��Ǝ������g�̍��W����x�N�g�����Z�o
        Vector3 vector3 = target.transform.position - this.transform.position;
        // Quaternion(��]�l)���擾
        Quaternion quaternion = Quaternion.LookRotation(vector3);
        // �Z�o������]�l�����̃Q�[���I�u�W�F�N�g��rotation�ɑ��
        this.transform.rotation = quaternion;
        if(In == false)
        {
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
            Instantiate(Bullet[0], bulletPoint.transform.position, transform.rotation);
            shotcheck = false;
        }

    }

    public void E_Damage(int damage)
    {
        Enemy_HP -= damage;
    }

    #region ����U��Hit����
    public void OnTriggerEnter(Collider other)
    {
        // �ʏ�U��Hit����
        if (other.gameObject.tag == "Bullet")
        {
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
            if (DamageHit == false)
            {
                E_Damage(createship.Attack[0]);
                DamageHit = true;
            }
            Debug.Log("�_���[�W:" + createship.Attack[0]);
            Debug.Log("Ehp:" + Enemy_HP);
        }
        if (other.gameObject.tag == "SP2")
        {
            DamageHit = false;
            Destroy(other.gameObject);
            if (DamageHit == false)
            {
                E_Damage(createship.Attack[1]);
                DamageHit = true;
            }
            Debug.Log("�_���[�W:" + createship.Attack[1]);
            Debug.Log("Ehp:" + Enemy_HP);
        }
        if (other.gameObject.tag == "SP3")
        {
            DamageHit = false;
            Destroy(other.gameObject);
            if (DamageHit == false)
            {
                E_Damage(createship.Attack[2]);
                DamageHit = true;
            }
            Debug.Log("�_���[�W:" + createship.Attack[2]);
            Debug.Log("Ehp:" + Enemy_HP);
        }
        if (other.gameObject.tag == "SP4")
        {
            DamageHit = false;
            Destroy(other.gameObject);
            if (DamageHit == false)
            {
                E_Damage(createship.Attack[3]);
                DamageHit = true;
            }
            Debug.Log("�_���[�W:" + createship.Attack[3]);
            Debug.Log("Ehp:" + Enemy_HP);
        }
        #endregion
    }
}
