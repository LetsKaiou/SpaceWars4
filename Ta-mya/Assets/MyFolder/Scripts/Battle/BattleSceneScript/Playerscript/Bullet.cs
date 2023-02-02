using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int BulletDamage;
    public static Bullet instance;
    public Quaternion firstRotation;
    public float speedY = 100;
    private float deleteTime = 5.0f;
    private Rigidbody rb;
    public float MoveSpeed;

    public GameObject BulletObj;

    //public FriendShipSelect friendsc;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        firstRotation = transform.rotation;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Vector3 movementSpeed = new Vector3(0, speedY, 0);
        movementSpeed = firstRotation * movementSpeed;
        rigidbody.AddForce(movementSpeed);

    }

    void Update()
    {
        // ’e‚ÌˆÚ“®
        rb.velocity = transform.forward * MoveSpeed;

        Destroy(BulletObj, deleteTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Player.instance.P_Damage(20);
        }
        if (other.gameObject.tag == "FriendShip1")
        {
            Destroy(this.gameObject);
            child.instance.C_Damage(5, "FriendShip1");
        }
        if (other.gameObject.tag == "FriendShip2")
        {
            Destroy(this.gameObject);
            child.instance.C_Damage(5, "FriendShip2");
        }
        if (other.gameObject.tag == "FriendShip3")
        {
            Destroy(this.gameObject);
            child.instance.C_Damage(5, "FriendShip3");
        }
        if (other.gameObject.tag == "FriendShip4")
        {
            Destroy(this.gameObject);
            child.instance.C_Damage(5, "FriendShip4");
        }
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Enemy.instance.E_Damage(5,0);
        }
        if (other.gameObject.tag == "Enemy2")
        {
            Destroy(this.gameObject);
            Enemy.instance.E_Damage(5,1);
        }
        if (other.gameObject.tag == "Enemy3")
        {
            Destroy(this.gameObject);
            Enemy.instance.E_Damage(5,2);
        }
        if (other.gameObject.tag == "Enemy4")
        {
            Destroy(this.gameObject);
            Enemy.instance.E_Damage(5, 3);
        }
        if (other.gameObject.tag == "EnemyChild1")
        {
            Destroy(this.gameObject);
            E_child.instance.C_Damage(5, "EnemyChild1");
        }
        if (other.gameObject.tag == "EnemyChild2")
        {
            Destroy(this.gameObject);
            E_child.instance.C_Damage(5, "EnemyChild2");
        }
        if (other.gameObject.tag == "EnemyChild3")
        {
            Destroy(this.gameObject);
            E_child.instance.C_Damage(5, "EnemyChild3");
        }
        if (other.gameObject.tag == "EnemyChild4")
        {
            Destroy(this.gameObject);
            E_child.instance.C_Damage(5, "EnemyChild4");
        }
        if (other.gameObject.tag == "EnemyChild5")
        {
            Destroy(this.gameObject);
            E_child.instance.C_Damage(5, "EnemyChild5");
        }
        if (other.gameObject.tag == "EnemyChild6")
        {
            Destroy(this.gameObject);
            E_child.instance.C_Damage(5, "EnemyChild6");
        }
        if (other.gameObject.tag == "EnemyChild7")
        {
            Destroy(this.gameObject);
            E_child.instance.C_Damage(5, "EnemyChild7");
        }
        if (other.gameObject.tag == "EnemyChild8")
        {
            Destroy(this.gameObject);
            E_child.instance.C_Damage(5, "EnemyChild8");
        }
        if (other.gameObject.tag == "EnemyChild9")
        {
            Destroy(this.gameObject);
            E_child.instance.C_Damage(5, "EnemyChild9");
        }
        if (other.gameObject.tag == "EnemyChild10")
        {
            Destroy(this.gameObject);
            E_child.instance.C_Damage(5, "EnemyChild10");
        }
    }



}
