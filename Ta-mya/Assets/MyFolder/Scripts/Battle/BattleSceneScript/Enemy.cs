using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 弾の発射間隔
    [SerializeField] private float _timeInterval;
    // 経過時間取得用変数
    private float _timeElapsed;
    // 敵の情報
    private int Enemy_HP = 50;
    [SerializeField] private float speed;
    public bool In;
    // ダメージを受けてるかどうか
    private bool DamageHit;
    // 弾に関する変数
    [SerializeField] private GameObject[] Bullet;
    private bool shotcheck;
    public GameObject bulletPoint;
    // プレイヤーの座標取得
    [SerializeField]private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed > _timeInterval)
        {
            shotcheck = true;
            // 経過時間を元に戻す
            _timeElapsed = 0f;
        }

        // 対象物と自分自身の座標からベクトルを算出
        Vector3 vector3 = target.transform.position - this.transform.position;
        // Quaternion(回転値)を取得
        Quaternion quaternion = Quaternion.LookRotation(vector3);
        // 算出した回転値をこのゲームオブジェクトのrotationに代入
        this.transform.rotation = quaternion;
        if(In == false)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
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
            Instantiate(Bullet[0], bulletPoint.transform.position, transform.rotation);
            shotcheck = false;
        }

    }

    public void E_Damage(int damage)
    {
        Enemy_HP -= damage;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            DamageHit = false;
            Destroy(other.gameObject);
            if (DamageHit == false)
            {
                E_Damage(5);
                DamageHit = true;
            }
            //Debug.Log("Ehp:" + Enemy_HP);
        }
    }
}
