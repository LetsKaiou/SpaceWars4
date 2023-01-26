using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_child : MonoBehaviour
{
    public float speed = 1;
    //public Bullet script;
    // �U���p�ϐ�
    private GameObject C_Bullet;
    public GameObject bullet;
    [SerializeField] private GameObject bulletPoint;
    [SerializeField] private float _timeInterval;
    private float _timeElapsed;

    // �X�e�[�^�X�i�[�p
    public int[] hp = new int[10];

    //�|�������̃G�t�F�N�g
    public GameObject breakEffect;

    public static E_child instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < hp.Length; i++)
        {
            hp[i] = 10;
        }
    }

    // �Q�[�����s���̌J��Ԃ�����
    void Update()
    {
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
        if(Enemy.instance.In == true)
        {
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
            C_Bullet.tag = "EnemyC_bullet";

        }
    }
    // �������Ɏ����̃X�e�[�^�X����
    //public void SetStatus(int FHP)
    //{
    //    HP = FHP;
    //}

    public void C_Damage(int damage, string TagName)
    {
        switch (TagName)
        {
            case "EnemyChild1":
                Damage(0, damage);
                //Debug.Log("F1:" + hp[0]);
                break;
            case "EnemyChild2":
                Damage(1, damage);
                //Debug.Log("F2:" + hp[1]);
                break;
            case "EnemyChild3":
                Damage(2, damage);
                //Debug.Log("F3:" + hp[2]);
                break;
            case "EnemyChild4":
                Damage(3, damage);
                //Debug.Log("F4:" + hp[3]);
                break;
            case "EnemyChild5":
                Damage(4, damage);
                //Debug.Log("F4:" + hp[3]);
                break;
            case "EnemyChild6":
                Damage(5, damage);
                //Debug.Log("F4:" + hp[3]);
                break;
            case "EnemyChild7":
                Damage(6, damage);
                //Debug.Log("F4:" + hp[3]);
                break;
            case "EnemyChild8":
                Damage(7, damage);
                //Debug.Log("F4:" + hp[3]);
                break;
            case "EnemyChild9":
                Damage(8, damage);
                //Debug.Log("F4:" + hp[3]);
                break;
            case "EnemyChild10":
                Damage(9, damage);
                //Debug.Log("F4:" + hp[3]);
                break;
        }
    }
    //���j�G�t�F�N�g�𐶐�����
    void BreakEffect()
    {
        //���j�G�t�F�N�g�𐶐�����
        GameObject effect = Instantiate(breakEffect) as GameObject;
        //�G�t�F�N�g����������ꏊ�����肷��(�G�I�u�W�F�N�g�̏ꏊ)
        effect.transform.position = this.gameObject.transform.position;
    }
    #region �U��Hit����
    private void Damage(int EnemyID, int Damage)
    {
        this.hp[EnemyID] -= Damage;
        if (hp[EnemyID] <= 0)
        {
            BreakEffect();
            Destroy(this.gameObject);
        }
    }
    #endregion
}
