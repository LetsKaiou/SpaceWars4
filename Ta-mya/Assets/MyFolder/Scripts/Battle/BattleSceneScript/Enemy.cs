using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    // �e�̔��ˊԊu
    [SerializeField] private float _timeInterval;
    // �o�ߎ��Ԏ擾�p�ϐ�
    private float _timeElapsed;
    private int Enemy_HP =50;
    private bool DamageHit;
    [SerializeField] private GameObject[] Bullet;
    public GameObject bulletPoint;
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
            shot();
            // �o�ߎ��Ԃ����ɖ߂�
            _timeElapsed = 0f;
        }
    }
    public void shot()
    {
        Debug.Log("IN_E_Bullet");
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
    }

    public void E_Damage(int damage)
    {
        Enemy_HP -= damage;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            DamageHit = false;
            Destroy(other.gameObject);
            if (DamageHit == false)
            {
                E_Damage(5);
                DamageHit = true;
            }
            //Debug.Log("Ehp:" + Enemy_HP);
        }
    }
}
