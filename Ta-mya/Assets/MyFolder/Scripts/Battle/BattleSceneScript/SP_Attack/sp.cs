using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sp : MonoBehaviour
{

    // �P���Ƀ_���[�W��^���邾���̓���U���͂��̃X�N���v�g������ok
    // �o�t�E�f�o�t�n�͕ʌ����������K�v�����邩��ʂō��

    // �U����
    public int ATKPoint;

    // �Z�[�u�p�̓��͏ȗ�
    private SaveSystem System => SaveSystem.Instance;
    private MainShipData Data => System.MainShipData;

    public void Start()
    {
        ATKPoint = CreateShip.Attack[Player.instance.BulletSelect-1] + Data.ATK;
    }

    public void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Player")
        //{
        //    Destroy(this.gameObject);
        //    Player.instance.P_Damage(20);
        //}
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Enemy.instance.E_Damage(ATKPoint, 0);
        }
        if (other.gameObject.tag == "Enemy2")
        {
            Destroy(this.gameObject);
            Enemy.instance.E_Damage(ATKPoint, 1);
        }
        if (other.gameObject.tag == "Enemy3")
        {
            Destroy(this.gameObject);
            Enemy.instance.E_Damage(ATKPoint, 2);
        }
        if (other.gameObject.tag == "Enemy4")
        {
            Destroy(this.gameObject);
            Enemy.instance.E_Damage(ATKPoint, 3);
        }
    }
}
