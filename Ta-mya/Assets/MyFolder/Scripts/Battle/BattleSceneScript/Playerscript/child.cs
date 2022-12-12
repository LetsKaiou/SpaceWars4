using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class child : MonoBehaviour
{
    public float speed = 1;
    //public Bullet script;
    // �U���p�ϐ�
    private GameObject C_Bullet;
    public GameObject bullet;
    [SerializeField] private GameObject bulletPoint;
    [SerializeField] private float _timeInterval;
    private float _timeElapsed;
    // ���̃X�N���v�g�Q�Ɨp�ϐ�
    private GameObject control;
    private CreateShip createcs;
    private FriendShipInfo frindInfo;
    // �X�e�[�^�X�i�[�p
    public int HP;
    public int DEF;
    public int SPD;
    public int[] hp = new int[4];
    public int[] def = new int[4];
    public int[] spd = new int[4];
    private int[] shipId = new int[4];


    // �Q�[���̃X�^�[�g���̏���
    void Start()
    {
        
        switch (this.gameObject.tag)
        {
            case "FriendShip1":
                this.hp[0] = HP;
                //Debug.Log("F1:" + hp[0]);
                break;
            case "FriendShip2":
                this.hp[1] = HP;
                //Debug.Log("F2:" + hp[1]);
                break;
            case "FriendShip3":
                this.hp[2] = HP;
                //Debug.Log("F3:" + hp[2]);
                break;
            case "FriendShip4":
                this.hp[3] = HP;
                //Debug.Log("F4:" + hp[3]);
                break;
        }
    }

    // �Q�[�����s���̌J��Ԃ�����
    void Update()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.position += transform.forward * speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position -= transform.forward * speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.Q))
        //{
        //    transform.position += transform.up * speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.E))
        //{
        //    transform.position -= transform.up * speed * Time.deltaTime;
        //}
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed > _timeInterval)
        {
            /*-- ���Ԋu�Ŏ��s���������� --*/
            shot();
            // �o�ߎ��Ԃ����ɖ߂�
            _timeElapsed = 0f;
        }
    }

    public void shot()
    {
        Debug.Log("ChildShot");
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
        C_Bullet = Instantiate(bullet, bulletPoint.transform.position, transform.rotation);
        C_Bullet.tag = "C_bullet";
    }
    // �������Ɏ����̃X�e�[�^�X����
    public void SetStatus(int FHP)
    {
        HP = FHP;
    }

    public void C_Damage(int damage)
    {
        switch (this.gameObject.tag)
        {
            case "FriendShip1":
                this.hp[0] -= damage;
                //Debug.Log("F1:" + hp[0]);
                break;
            case "FriendShip2":
                this.hp[1] -= damage;
                //Debug.Log("F2:" + hp[1]);
                break;
            case "FriendShip3":
                this.hp[2] -= damage;
                //Debug.Log("F3:" + hp[2]);
                break;
            case "FriendShip4":
                this.hp[3] -= damage;
                //Debug.Log("F4:" + hp[3]);
                break;
        }
    }

    #region �U��Hit����
    public void OnTriggerEnter(Collider other)
    {
        // �ʏ�U��Hit����
        if (other.gameObject.tag == "P_bullet")
        {
            Debug.Log("INEHit");

            C_Damage(5);

        }
        // ����U��Hit����
        if (other.gameObject.tag == "SP1")
        {
            Destroy(other.gameObject);
            C_Damage(createcs.GetSPAttack(0));
        }
        if (other.gameObject.tag == "SP2")
        {
            Destroy(other.gameObject);
            C_Damage(createcs.GetSPAttack(1));
        }
        if (other.gameObject.tag == "SP3")
        {
            Destroy(other.gameObject);
            C_Damage(createcs.GetSPAttack(2));
        }
        if (other.gameObject.tag == "SP4")
        {
            Destroy(other.gameObject);
            C_Damage(createcs.GetSPAttack(3));
        }
    }
    #endregion
}
