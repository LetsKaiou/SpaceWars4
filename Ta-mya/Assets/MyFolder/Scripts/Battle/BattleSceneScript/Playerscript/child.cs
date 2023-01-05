using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class child : MonoBehaviour
{
    public float speed = 1;
    //public Bullet script;
    // 攻撃用変数
    private GameObject C_Bullet;
    public GameObject bullet;
    [SerializeField] private GameObject bulletPoint;
    [SerializeField] private float _timeInterval;
    private float _timeElapsed;
    // 他のスクリプト参照用変数
    private GameObject control;
    private CreateShip createcs;
    private FriendShipInfo frindInfo;
    // ステータス格納用
    public int HP;
    public int DEF;
    public int SPD;
    public int[] hp = new int[4];
    public int[] def = new int[4];
    public int[] spd = new int[4];
    private int[] shipId = new int[4];

    private GameObject[] ChildObj = new GameObject[4];
    private string[] tag = new string[4];

    public static child instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // ゲームのスタート時の処理
    void Start()
    {
        string[] tag = { "FriendShip1", "FriendShip2", "FriendShip3", "FriendShip4" };
        for (int i = 0; i < tag.Length; i++)
        {
            ChildObj[i] = GameObject.FindGameObjectWithTag(tag[i]);
        }
        switch (this.gameObject.tag)
        {
            case "FriendShip1":
                this.hp[0] = HP;
                //Debug.Log("F1:" + hp[0]);
                break;
            case "FriendShip2":
                this.hp[1] = HP;
                //Debug.Log("F2:" + hp[1]);
                break;
            case "FriendShip3":
                this.hp[2] = HP;
                //Debug.Log("F3:" + hp[2]);
                break;
            case "FriendShip4":
                this.hp[3] = HP;
                //Debug.Log("F4:" + hp[3]);
                break;
        }
    }

    // ゲーム実行中の繰り返し処理
    void Update()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.position += transform.forward * speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position -= transform.forward * speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.Q))
        //{
        //    transform.position += transform.up * speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.E))
        //{
        //    transform.position -= transform.up * speed * Time.deltaTime;
        //}
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
            C_Bullet.tag = "C_bullet";

        }
    }
    // 生成時に自分のステータスを代入
    public void SetStatus(int FHP)
    {
        HP = FHP;
    }

    public void C_Damage(int damage)
    {
        switch (this.gameObject.tag)
        {
            case "FriendShip1":
                this.hp[0] -= damage;
                //Debug.Log("F1:" + hp[0]);
                break;
            case "FriendShip2":
                this.hp[1] -= damage;
                //Debug.Log("F2:" + hp[1]);
                break;
            case "FriendShip3":
                this.hp[2] -= damage;
                //Debug.Log("F3:" + hp[2]);
                break;
            case "FriendShip4":
                this.hp[3] -= damage;
                //Debug.Log("F4:" + hp[3]);
                break;
        }
    }

    #region 攻撃Hit処理
    public void OnTriggerEnter(Collider other)
    {
        // 通常攻撃Hit判定
        if (other.gameObject.tag == "P_bullet")
        {
            Debug.Log("INEHit");

            C_Damage(5);

        }
        // 特殊攻撃Hit判定
        if (other.gameObject.tag == "SP1")
        {
            Destroy(other.gameObject);
            C_Damage(createcs.GetSPAttack(0));
        }
        if (other.gameObject.tag == "SP2")
        {
            Destroy(other.gameObject);
            C_Damage(createcs.GetSPAttack(1));
        }
        if (other.gameObject.tag == "SP3")
        {
            Destroy(other.gameObject);
            C_Damage(createcs.GetSPAttack(2));
        }
        if (other.gameObject.tag == "SP4")
        {
            Destroy(other.gameObject);
            C_Damage(createcs.GetSPAttack(3));
        }
    }
    #endregion

    public void Front(float M_Speed, string Tag)
    {
        switch (Tag)
        {
            case "FriendShip1":
                ChildObj[0].transform.position += transform.forward * M_Speed * Time.deltaTime;
                break;
            case "FriendShip2":
                ChildObj[1].transform.position += transform.forward * M_Speed * Time.deltaTime;
                break;
            case "FriendShip3":
                ChildObj[2].transform.position += transform.forward * M_Speed * Time.deltaTime;
                break;
            case "FriendShip4":
                ChildObj[3].transform.position += transform.forward * M_Speed * Time.deltaTime;
                break;
        }
    }

    public void Back(float M_Speed, string Tag)
    {
        switch (Tag)
        {
            case "FriendShip1":
                ChildObj[0].transform.position -= transform.forward * M_Speed * Time.deltaTime;
                break;
            case "FriendShip2":
                ChildObj[1].transform.position -= transform.forward * M_Speed * Time.deltaTime;
                break;
            case "FriendShip3":
                ChildObj[2].transform.position -= transform.forward * M_Speed * Time.deltaTime;
                break;
            case "FriendShip4":
                ChildObj[3].transform.position -= transform.forward * M_Speed * Time.deltaTime;
                break;
        }
    }

}
