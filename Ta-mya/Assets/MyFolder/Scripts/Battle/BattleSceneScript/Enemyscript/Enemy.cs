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
    // 敵の情報
    private int Enemy_HP = 100;
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
    public GameObject bulletPoint;
    [SerializeField] private CreateShip createship;
    // プレイヤーの座標取得
    [SerializeField]private GameObject target;
    // Start is called before the first frame update
    void Start()
    {

        angle = gameObject.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        _timeElapsed += Time.deltaTime;
        _RtimeElapsed += Time.deltaTime;

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

        if (Enemy_HP <= 0)
        {
            SceneManager.LoadScene("Result");
        }

    }
    public void shot()
    {
        if(shotcheck == true)
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

    public void E_Damage(int damage)
    {
        this.Enemy_HP -= damage;
    }

    #region 攻撃Hit処理
    public void OnTriggerEnter(Collider other)
    {
        // 通常攻撃Hit判定
        if (other.gameObject.tag == "P_bullet")
        {
            Debug.Log("INEHit");
            DamageHit = false;
            Destroy(other.gameObject);
            if (DamageHit == false)
            {
                E_Damage(5);
                DamageHit = true;
            }
            Debug.Log("ダメージ:" + 5);
            Debug.Log("Ehp:" + Enemy_HP);
        }
        // 特殊攻撃Hit判定
        if (other.gameObject.tag == "SP1")
        {
            DamageHit = false;
            Destroy(other.gameObject);
            //if (DamageHit == false)
            //{
            //    E_Damage(CreateShip.Attack[0]);
            //    DamageHit = true;
            //}
            Enemy_HP = Enemy_HP - SP_Use1.instance.SP1Damage();
            Debug.Log("ダメージ:" + CreateShip.Attack[0]);
            Debug.Log("Ehp:" + Enemy_HP);
        }
        if (other.gameObject.tag == "SP2")
        {
            DamageHit = false;
            Destroy(other.gameObject);
            //if (DamageHit == false)
            //{
            //    E_Damage(CreateShip.Attack[1]);
            //    DamageHit = true;
            //}
            Enemy_HP = Enemy_HP - SP_Use1.instance.SP1Damage();
            Debug.Log("ダメージ:" + CreateShip.Attack[1]);
            Debug.Log("Ehp:" + Enemy_HP);
        }
        if (other.gameObject.tag == "SP3")
        {
            DamageHit = false;
            Destroy(other.gameObject);
            //if (DamageHit == false)
            //{
            //    E_Damage(CreateShip.Attack[2]);
            //    DamageHit = true;
            //}
            Enemy_HP = Enemy_HP - SP_Use1.instance.SP1Damage();
            Debug.Log("ダメージ:" + CreateShip.Attack[2]);
            Debug.Log("Ehp:" + Enemy_HP);
        }
        if (other.gameObject.tag == "SP4")
        {
            DamageHit = false;
            Destroy(other.gameObject);
            //if (DamageHit == false)
            //{
            //    E_Damage(CreateShip.Attack[3]);
            //    DamageHit = true;
            //}
            Enemy_HP = Enemy_HP - SP_Use1.instance.SP1Damage();
            Debug.Log("ダメージ:" + CreateShip.Attack[3]);
            Debug.Log("Ehp:" + Enemy_HP);
        }
        
    }
    #endregion

}
