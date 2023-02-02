using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Hit : MonoBehaviour
{
    // 攻撃力
    public int ATKPoint;

    // インスタンス
    public static SP_Hit instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Start()
    {
        ATKPoint = SpecialPrevrew.Attack[Player.instance.BulletSelect - 1];
        Debug.Log(SpecialPrevrew.Attack[0]);
        Debug.Log("ATKPoint:" + SpecialPrevrew.Attack[Player.instance.BulletSelect - 1]);
    }

    public void OnTriggerEnter(Collider other)
    {
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
