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
    public float MoveSpeed = 2.0f;

    public GameObject BulletObj;

    private GameObject Player;
    private GameObject Enemy;

    public Player playersc;
    public Enemy enemysc;
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
        // íeÇÃà⁄ìÆ
        rb.velocity = transform.forward * MoveSpeed;

        Destroy(gameObject, deleteTime);
    }

    // íeÇÃê⁄êGîªíËèàóù
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemysc.hp = enemysc.hp - BulletDamage;
        }

        if (other.gameObject.tag == "Player")
        {
            playersc.P_Damage(BulletDamage);
        }
    }

    private void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.name == "Child1")
        {
            
            
        }
    }

}
