using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP3hit : MonoBehaviour
{
    // 攻撃力
    public int ATKPoint;

    // インスタンス
    public static SP3hit instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Start()
    {
        ATKPoint = CreateShip.Attack[2];
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Player.instance.P_Damage(20);
        }
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
