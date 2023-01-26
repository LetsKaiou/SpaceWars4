using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_child : MonoBehaviour
{
    public float speed = 1;
    //public Bullet script;
    // 攻撃用変数
    private GameObject C_Bullet;
    public GameObject bullet;
    [SerializeField] private GameObject bulletPoint;
    [SerializeField] private float _timeInterval;
    private float _timeElapsed;

    // ステータス格納用
    public int[] hp = new int[10];

    //倒した時のエフェクト
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

    // ゲーム実行中の繰り返し処理
    void Update()
    {
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed > _timeInterval)
        {
            /*-- 一定間隔で実行したい処理 --*/
            shot();
            // 経過時間を元に戻す
            _timeElapsed = 0f;
        }
    }

    public void shot()
    {
        if(Enemy.instance.In == true)
        {
            //弾を出現させる位置を取得
            Vector3 placePosition = this.transform.position;
            //出現させる位置をずらす値
            Vector3 offsetGun = new Vector3(0, 0, 8);

            //武器の向きに合わせて弾の向きも調整
            Quaternion q1 = this.transform.rotation;
            //弾を90度回転させる処理
            Quaternion q2 = Quaternion.AngleAxis(90, new Vector3(1, 0, 0));
            Quaternion q = q1 * q2;

            //弾を出現させる位置を調整
            placePosition = q1 * offsetGun + placePosition;
            //弾生成
            C_Bullet = Instantiate(bullet, bulletPoint.transform.position, transform.rotation);
            C_Bullet.tag = "EnemyC_bullet";

        }
    }
    // 生成時に自分のステータスを代入
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
    //爆破エフェクトを生成する
    void BreakEffect()
    {
        //爆破エフェクトを生成する
        GameObject effect = Instantiate(breakEffect) as GameObject;
        //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
        effect.transform.position = this.gameObject.transform.position;
    }
    #region 攻撃Hit処理
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
