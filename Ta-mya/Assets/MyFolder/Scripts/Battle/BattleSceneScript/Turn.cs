using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public Player playercs;
    public float turnSpeed;
    private Rigidbody rb;
    private float turnInputValue;

    private float currentAngleY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
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



        currentAngleY = Mathf.Clamp(currentAngleY, -30, 30);
        transform.localEulerAngles = new Vector3(0, currentAngleY, 0);
    }

    void TankTurn()
    {

        if (Input.GetKey(KeyCode.D))
        {
            playercs.isTurn = true;
            transform.Rotate(new Vector3(0, 0.5f, 0));
            //child.instance.Front(Player.instance.speed, "FriendShip1");
            //child.instance.Front(Player.instance.speed, "FriendShip4");
            //child.instance.Back(Player.instance.speed, "FriendShip2");
            //child.instance.Back(Player.instance.speed, "FriendShip3");
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log(playercs.isTurn);
            playercs.isTurn = true;
            transform.Rotate(new Vector3(0, -0.5f, 0));
            //child.instance.Front(Player.instance.speed, "FriendShip2");
            //child.instance.Front(Player.instance.speed, "FriendShip3");
            //child.instance.Back(Player.instance.speed, "FriendShip1");
            //child.instance.Back(Player.instance.speed, "FriendShip4");
        }
        playercs.isTurn = false;
    }
}
