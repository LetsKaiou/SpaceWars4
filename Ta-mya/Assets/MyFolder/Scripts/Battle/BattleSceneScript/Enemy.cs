using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    // 弾の発射間隔
    [SerializeField] private float _timeInterval;
    // 経過時間取得用変数
    private float _timeElapsed;
    private int Enemy_HP =50;
    private bool DamageHit;
    [SerializeField] private GameObject[] Bullet;
    public GameObject bulletPoint;
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
            shot();
            // 経過時間を元に戻す
            _timeElapsed = 0f;
        }
    }
    public void shot()
    {
        Debug.Log("IN_E_Bullet");
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
