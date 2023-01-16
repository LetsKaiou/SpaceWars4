using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    // 弾の発射間隔
    [SerializeField] private float _timeInterval;
    // 経過時間取得用変数
    private float _timeElapsed;
    [SerializeField] private float _RotateTime;
    private float _RtimeElapsed;
    [SerializeField] private float CoolTime;
    private float _CTTime;
    // 敵の情報
    [SerializeField] private int[] Enemy_HP = new int[4];
    [SerializeField] private float speed;
    public bool In;
    public bool PlayerFind;
    public bool StatusNum;
    private Vector3 angle;
    private float setangle;
    private float Maxangle;
    Vector3 NowRotate;
    // ダメージを受けてるかどうか
    private bool DamageHit;
    // 弾に関する変数
    private GameObject E_Bullet;
    [SerializeField] private GameObject[] Bullet;
    private bool shotcheck;
    private bool isSP;
    public GameObject bulletPoint;
    [SerializeField] private CreateShip createship;
    // プレイヤーの座標取得
    [SerializeField]private GameObject target;

    private int EnemyCount;
    public static Enemy instance;

    //倒した時のエフェクト
    public GameObject breakEffect;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < Enemy_HP.Length; i++)
        {
            Enemy_HP[i] = 100;
        }
        EnemyCount = CreateEnemyShip.instance.Counter;
        angle = gameObject.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        _timeElapsed += Time.deltaTime;
        _RtimeElapsed += Time.deltaTime;
        _CTTime += Time.deltaTime;
        if (_RtimeElapsed > _RotateTime)
        {
            Maxangle = Random.Range(0, 360);
            angle = new Vector3(0, Maxangle, 0);
            // 経過時間を元に戻す
            _RtimeElapsed = 0f;
        }

        if (_timeElapsed > _timeInterval)
        {
            shotcheck = true;
            // 経過時間を元に戻す
            _timeElapsed = 0f;
        }

        if(_CTTime > CoolTime)
        {
            isSP = true;
            _CTTime = 0f;
        }
        // Playerの方向に向かって移動する処理
        if (PlayerFind == true)
        {
            // 対象物と自分自身の座標からベクトルを算出
            Vector3 vector3 = target.transform.position - this.transform.position;
            // Quaternion(回転値)を取得
            Quaternion quaternion = Quaternion.LookRotation(vector3);
            // 算出した回転値をこのゲームオブジェクトのrotationに代入
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

        if (EnemyCount <= 0)
        {
            PreviewScore.instance.isWin = true;
            SceneManager.LoadScene("Result");
        }

    }
    public void shot()
    {
        if(isSP == true)
        {
            //弾を出現させる位置を取得
            Vector3 placePosition = this.transform.position;
            //出現させる位置をずらす値
            Vector3 offsetGun = new Vector3(0, 0, 8);

            //武器の向きに合わせて弾の向きも調整
            Quaternion q1 = this.transform.rotation;
            //弾を90度回転させる処理
            Quaternion q2 = Quaternion.AngleAxis(90, new Vector3(0, 0, 0));
            Quaternion q = q1 * q2;

            //弾を出現させる位置を調整
            placePosition = q1 * offsetGun + placePosition;
            //弾生成
            E_Bullet = Instantiate(Bullet[1], bulletPoint.transform.position, transform.rotation);
            E_Bullet.tag = "E_SP";
            isSP = false;
        }

    }

    public void SPShot()
    {
        if (shotcheck == true)
        {
            //弾を出現させる位置を取得
            Vector3 placePosition = this.transform.position;
            //出現させる位置をずらす値
            Vector3 offsetGun = new Vector3(0, 0, 8);

            //武器の向きに合わせて弾の向きも調整
            Quaternion q1 = this.transform.rotation;
            //弾を90度回転させる処理
            Quaternion q2 = Quaternion.AngleAxis(90, new Vector3(0, 0, 0));
            Quaternion q = q1 * q2;

            //弾を出現させる位置を調整
            placePosition = q1 * offsetGun + placePosition;
            //弾生成
            E_Bullet = Instantiate(Bullet[0], bulletPoint.transform.position, transform.rotation);
            E_Bullet.tag = "E_bullet";
            shotcheck = false;
        }
    }

    public void E_Damage(int damage, int Numbre)
    {
        switch (Numbre)
        {
            case 0:
                Enemy_HP[0] -= damage;
                if(Enemy_HP[0] <= 0)
                {
                    Destroy(this.gameObject);
                    EnemyCount--;
                }
                break;
            case 1:
                Enemy_HP[1] -= damage;
                if (Enemy_HP[1] <= 0)
                {
                    Destroy(this.gameObject);
                    EnemyCount--;
                }
                break;
            case 2:
                Enemy_HP[2] -= damage;
                if (Enemy_HP[2] <= 0)
                {
                    Destroy(this.gameObject);
                    EnemyCount--;
                }
                break;
            case 3:
                Enemy_HP[3] -= damage;
                if (Enemy_HP[3] <= 0)
                {
                    Destroy(this.gameObject);
                    EnemyCount--;
                }
                break;
        }
    }
    
    //爆破エフェクトを生成する
    void BreakEffect()
    {
        //爆破エフェクトを生成する
        GameObject effect = Instantiate(breakEffect) as GameObject;
        //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
        effect.transform.position = gameObject.transform.position;
    }

}
