using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;


public class Player : MonoBehaviour
{
    // セーブ用の入力省略
    private SaveSystem System => SaveSystem.Instance;
    private MainShipData Data => System.MainShipData;
    // 他のスクリプト参照用
    public SP_Bullet sp_Bullet;
    public CreateShip createcs;
    public CoolDown CoolDownScript;
    // Player情報
    public float speed;
    public int Player_HP = 60;
    public static int MaxHP;
    public Slider hp_slider;
    public bool isTurn = false;
    public static float ScoreHP;
    private bool isSecond;
    public int Defence;
    // 弾の種類、発射位置
    [SerializeField] private GameObject[] Bullet;
    [SerializeField] private GameObject bulletPoint;
    public GameObject[] Clones = new GameObject[256];
    private GameObject P_Bullet;
    // 経過時間取得用変数
    [SerializeField] private float _timeInterval;
    private float _timeElapsed;
    // マウスホイールの回転数取得用変数
    private float MousWheel;
    // 特殊攻撃用格納変数
    [SerializeField] private float[] sp_Range = new float[4];
    public int BulletSelect;
    public List<bool> Reload = new List<bool>();
    // ダメージ処理用変数
    private bool DamageHit;
    // アニメーション格納用
    [SerializeField] private Animator SP_Anim;

    private bool shotcheck;

    public float _anglePerFrame = 0.1f;
    [SerializeField] private Material skybox;
    private Vector3 vec;

    public static Player instance;

    public ParticleSystem JetEffect;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        //skybox.SetVector("_Rotation", new Vector3(1, 0, 0));
        //skybox.SetVector("_Speed", new Vector3(0, 0, 0));
        //vec = new Vector3(1, 0, 0);

        ScoreHP = 0;

        Player_HP = Data.HP;

        // 初期化
        hp_slider.maxValue = Player_HP;

        hp_slider.value = Player_HP;
        for (int i = 0; i < 4; i++)
        {
            speed += createcs.SPD[i];
        }


        SP_Anim.GetComponent<Animator>();

        // Listに情報を追加(ture:発射可能、false:クールタイム中)
        Reload.Add(true);   // 特殊攻撃1
        Reload.Add(true);   // 特殊攻撃2
        Reload.Add(true);   // 特殊攻撃3
        Reload.Add(true);   // 特殊攻撃4
        //Debug.Log(Reload.Count);

        // エフェクト用
        JetEffect.Pause();
    }

    void Update()
    {

        //skybox.SetVector("_Speed", vec);
        // 移動処理
        #region 移動
        if (Input.GetKey(KeyCode.W) && isTurn == false)
        {
            transform.position += transform.forward * speed * Time.deltaTime;

            //vec = new Vector3(1, 0, 0);
            //エフェクト用
            JetEffect.Play();
        }
        //else
        //{
        //    vec = new Vector3(0, 0, 0);
        //}
        if (Input.GetKey(KeyCode.S) && isTurn == false)
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
            JetEffect.Stop();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadScene("Result");
        }
        #endregion

        // 特殊攻撃選択処理
        #region 特殊攻撃
        // マウスの回転数取得(回転させるたびに1ずつ増減する デフォルトは0)
        MousWheel += Input.GetAxis("Mouse ScrollWheel");
        MousWheel = Mathf.Floor(MousWheel);
        MousWheel = Mathf.Clamp(MousWheel, 0.0f, 4.0f);
        //SP_Anim.SetInteger("Param", (int)MousWheel);
        #endregion

        // 弾発射
        #region 弾の発射
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed > _timeInterval)
        {
            shotcheck = true;
            //shot();
            // 経過時間を元に戻す
            _timeElapsed = 0f;
        }
        #endregion
        // 特殊攻撃の弾選択処理と発射処理への移動(マウス左クリックで発射)
        #region 特殊攻撃設定用
        if (MousWheel > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {

                int AnimNum = SP_Anim.GetInteger((int)MousWheel);
                BulletSelect = (int)MousWheel;
                if (Reload[BulletSelect - 1] == true)
                {
                    SpecialAttack();
                }
            }
        }
        #endregion
        // プレイヤーの体力処理
        #region HP処理
        // HPのスライダー処理
        //hp_slider.value = MaxHP;
        if (hp_slider.value <= 0)
        {
            GoResult.isWin = false;
            SceneManager.LoadScene("Result");
        }
        #endregion
    }

    // 通常弾発射処理関数
    public void shot()
    {
        if (shotcheck == true)
        {
            Debug.Log("ShorIN");
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
            P_Bullet = Instantiate(Bullet[0], bulletPoint.transform.position, transform.rotation);
            P_Bullet.tag = "P_bullet";
            shotcheck = false;
        }
    }

    // 特殊攻撃処理関数(引数は発射する特殊攻撃の弾の種類)
    public void SpecialAttack()
    {
        // 選択した特殊攻撃を渡す
        CoolDownScript.SetSpecialNum();

        // 消滅までの時間を代入
        sp_Range[BulletSelect - 1] = createcs.GetSPRange(BulletSelect - 1);

        // 発射後falseに変更
        Reload[BulletSelect - 1] = false;

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
        Quaternion a = Quaternion.identity;

        // 使った特殊攻撃のIDを返す
        Skill.instance.StartEffect(BulletSelect);

    }

    public void GetSocre_HP()
    {
        ScoreHP = hp_slider.value / Player_HP * 100;
    }

    // ダメージ計算処理
    public void P_Damage(int damage)
    {
        damage = damage - Defence;  // 防御力分ダメージ減少
        hp_slider.value -= damage;
    }

    // BulletSelectを渡す
    public int GetSpecialNum()
    {
        return BulletSelect;
    }


    // 発射した特殊攻撃を消す
    public void Destroy()
    {
        Destroy(Clones[BulletSelect - 1], sp_Range[BulletSelect - 1]);
    }

    // ダメージ判定用関数
    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "E_bullet" || other.gameObject.tag == "C_bullet")
    //    {
    //        DamageHit = false;
    //        Destroy(other.gameObject);
    //        if (DamageHit == false)
    //        {
    //            Debug.Log(other.tag);
    //            P_Damage(5 - Defence);
    //            DamageHit = true;
    //        }
    //    }
    //    if (other.gameObject.tag == "E_SP")
    //    {
    //        DamageHit = false;
    //        Destroy(other.gameObject);
    //        if (DamageHit == false)
    //        {
    //            Debug.Log(other.tag);
    //            P_Damage(20);
    //            DamageHit = true;
    //        }
    //    }
    //}
}

