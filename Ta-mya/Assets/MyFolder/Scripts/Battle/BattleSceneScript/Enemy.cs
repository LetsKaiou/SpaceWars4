using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    // ’e‚Ì”­ŽËŠÔŠu
    [SerializeField] private float _timeInterval;
    // Œo‰ßŽžŠÔŽæ“¾—p•Ï”
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
            // Œo‰ßŽžŠÔ‚ðŒ³‚É–ß‚·
            _timeElapsed = 0f;
        }
        if (Enemy_HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void shot()
    {
        Debug.Log("IN_E_Bullet");
        //’e‚ðoŒ»‚³‚¹‚éˆÊ’u‚ðŽæ“¾
        Vector3 placePosition = this.transform.position;
        //oŒ»‚³‚¹‚éˆÊ’u‚ð‚¸‚ç‚·’l
        Vector3 offsetGun = new Vector3(0, 0, 8);

        //•Ší‚ÌŒü‚«‚É‡‚í‚¹‚Ä’e‚ÌŒü‚«‚à’²®
        Quaternion q1 = this.transform.rotation;
        //’e‚ð90“x‰ñ“]‚³‚¹‚éˆ—
        Quaternion q2 = Quaternion.AngleAxis(90, new Vector3(0, 0, 0));
        Quaternion q = q1 * q2;

        //’e‚ðoŒ»‚³‚¹‚éˆÊ’u‚ð’²®
        placePosition = q1 * offsetGun + placePosition;
        //’e¶¬
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
