using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    // 移動速度を格納する変数
    public float speed = 1;
    // HP
    private int Player_HP;
    [SerializeField] private Slider hp_slider;
    // 弾の発射間隔
    [SerializeField] private float _timeInterval;
    // 経過時間取得用変数
    private float _timeElapsed;
    // マウスホイールの回転数取得用変数
    private float MousWheel;
    // 特殊攻撃用経過時間格納変数
    private float SkillTime;
    // 特殊攻撃のクールタイム
    [SerializeField] private float SkillInterval;
    // 特殊攻撃選択用変数
    public int BulletSelect;
    // 特殊攻撃の弾のプレファブ格納
    //[SerializeField] private List<GameObject> BulletList = new List<GameObject>();
    [SerializeField] private GameObject[] Bullet;
    // 特殊攻撃の弾ごとのクールタイム確認格納用
    public List<bool> Reload = new List<bool>();
    [SerializeField] private GameObject bulletPoint;
    public CoolDown CoolDownScript;
    private bool DamageHit;
    // アニメーション格納用
    [SerializeField] private Animator SP_Anim;

    void Start()
    {
        Player_HP = 100;
        hp_slider.maxValue = Player_HP;
        hp_slider.value = Player_HP;
        SP_Anim.GetComponent<Animator>();
        // Listに情報を追加(ture:発射可能、false:クールタイム中)
        Reload.Add(true);   // 特殊攻撃1
        Reload.Add(true);   // 特殊攻撃2
        Reload.Add(true);   // 特殊攻撃3
        Reload.Add(true);   // 特殊攻撃4
        //Debug.Log(Reload.Count);
    }

    void Update()
    {
        // 移動処理
        #region 移動
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        #endregion

        // 特殊攻撃選択処理
        #region 特殊攻撃
        // マウスの回転数取得(回転させるたびに1ずつ増減する デフォルトは0)
        MousWheel += Input.GetAxis("Mouse ScrollWheel");
        MousWheel = Mathf.Floor(MousWheel);
        MousWheel = Mathf.Clamp(MousWheel, 0.0f, 4.0f);
        SP_Anim.SetInteger("Param", (int)MousWheel);
        #endregion

        // 弾発射
        #region 弾の発射
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed > _timeInterval)
        {
            shot();
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
                Debug.Log("AnimNum"+AnimNum);
                Debug.Log(Reload[3]);
                BulletSelect = (int)MousWheel;
                if (Reload[BulletSelect - 1] == true)
                {
                    SpecialAttack(BulletSelect);
                }
            }
        }
        #endregion
        // HPのスライダー処理
        hp_slider.value = Player_HP;
        if (Player_HP <= 0)
        {
            SceneManager.LoadScene("Result");
        }
    }

    // 通常弾発射処理関数
    public void shot()
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
        Instantiate(Bullet[0], bulletPoint.transform.position, transform.rotation);
    }

    // 特殊攻撃処理関数(引数は発射する特殊攻撃の弾の種類)
    public void SpecialAttack(int BulletSelection)
    {
        CoolDownScript.SetSpecialNum();

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
        //弾生成
        Instantiate(Bullet[BulletSelection], placePosition, Quaternion.identity);

        // クールタイム開始
        //StartCoroutine(CoolTime());
    }

    public void P_Damage(int damage)
    {
        Player_HP -= damage;
    }


    // クールタイム処理コルーチン
    private IEnumerator CoolTime()
    {
        // クールタイム開始
        //Debug.Log("クールタイム開始");

        // 待機時間
        yield return new WaitForSeconds(2);

        // false → trueに変更
        Reload[BulletSelect - 1] = true;
        //Debug.Log("クールタイム終了");
    }

    public int GetSpecialNum()
    {
        return BulletSelect;
    }

    public int GetPHp()
    {


        return Player_HP;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            DamageHit = false;
            Destroy(other.gameObject);
            if (DamageHit == false)
            {
                P_Damage(5);
                DamageHit = true;
            }
            //Debug.Log("hp:" + Player_HP);
        }
    }
}

