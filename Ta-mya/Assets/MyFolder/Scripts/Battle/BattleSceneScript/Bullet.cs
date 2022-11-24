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

        Destroy(gameObject, deleteTime);
    }

}
