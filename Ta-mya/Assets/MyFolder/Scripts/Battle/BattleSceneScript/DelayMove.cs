using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayMove : MonoBehaviour
{
    //public GameObject player;
    private GameObject player;
    private Vector3 offset;
    private Vector3 rote;
    private Quaternion qua;
    // Use this for initialization
    void Start()
    {
        if (this.tag == "Player") return;
        //this.tag = GameObject.Find("Player");
        switch (this.tag)
        {
            case "FriendShip1":
                player = GameObject.FindGameObjectsWithTag("Player")[0];
                break;
            case "FriendShip2":
                player = GameObject.FindGameObjectsWithTag("Player")[0];
                break;
            case "FriendShip3":
                player = GameObject.FindGameObjectsWithTag("FriendShip2")[0];
                break;
            case "FriendShip4":
                player = GameObject.FindGameObjectsWithTag("FriendShip3")[0];
                break;
        }
        
        offset = transform.position - player.transform.position;
        //rote = player.transform.localEulerAngles;
    }

    void LateUpdate()
    {
        if (this.tag == "Player") return;
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, 10.0f * Time.deltaTime);
        //rote = player.transform.localEulerAngles;
        //transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, rote, 10.0f * Time.deltaTime); ;    
        qua = player.transform.rotation;
        // transform.rotation = qua;
        transform.rotation = Quaternion.Lerp(transform.rotation, qua, 5.0f * Time.deltaTime);
    }
}
