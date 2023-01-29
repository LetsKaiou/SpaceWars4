using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendTurn : MonoBehaviour
{
    public child friendcs;
    public float turnSpeed;
    private Rigidbody rb;
    private float turnInputValue;
    private Quaternion rotation;
    private float currentAngleY;
    [SerializeField]
    private float rotateAngle = 45f;
    [SerializeField]
    private float RotateSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rotation = transform.rotation;
       
        
    }

    void LateUpdate()
    {
        rotation = Quaternion.Euler(0f, transform.eulerAngles.y + Input.GetAxis("Horizontal") * rotateAngle, 0f);
        var forSpeed = Vector3.Dot(rb.velocity, transform.forward).ToString("0");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity += transform.forward * 0.3f;
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, 30);
        }

        if (Input.GetKey(KeyCode.RightShift))
        {
            rb.velocity -= transform.forward * 0.2f;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            rb.velocity = Vector3.zero;
        }

        TankTurn();


        currentAngleY = transform.localEulerAngles.y;


        if (currentAngleY > 180)
        {
            currentAngleY = currentAngleY - 360;
        }



        //currentAngleY = Mathf.Clamp(currentAngleY, -30, 30);
        transform.localEulerAngles = new Vector3(0, currentAngleY, 0);
    }

    void TankTurn()
    {

        if (Input.GetKey(KeyCode.D))
        {
            friendcs.isTurn = true;
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, RotateSpeed * Time.deltaTime);
            //transform.Rotate(new Vector3(0, 0.5f, 0));
            //child.instance.Front(Player.instance.speed, "FriendShip1");
            //child.instance.Front(Player.instance.speed, "FriendShip4");
            //child.instance.Back(Player.instance.speed, "FriendShip2");
            //child.instance.Back(Player.instance.speed, "FriendShip3");
        }
        if (Input.GetKey(KeyCode.A))
        {
            friendcs.isTurn = true;
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, RotateSpeed * Time.deltaTime);
            //transform.Rotate(new Vector3(0, -0.5f, 0));
            //child.instance.Front(Player.instance.speed, "FriendShip2");
            //child.instance.Front(Player.instance.speed, "FriendShip3");
            //child.instance.Back(Player.instance.speed, "FriendShip1");
            //child.instance.Back(Player.instance.speed, "FriendShip4");
        }
        friendcs.isTurn = false;
    }
}
