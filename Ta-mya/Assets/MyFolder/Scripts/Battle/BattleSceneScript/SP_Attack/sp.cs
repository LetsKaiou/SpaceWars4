using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sp : MonoBehaviour
{

    // 単純にダメージを与えるだけの特殊攻撃はこのスクリプトだけでok
    // バフ・デバフ系は別個処理を書く必要があるから別で作る

    // 攻撃力
    public int ATKPoint;

    // セーブ用の入力省略
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
