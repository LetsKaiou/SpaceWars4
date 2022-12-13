using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CubeMove : MonoBehaviourPunCallbacks
{
    float speed = 5f;

    void Update()
    {
        if (photonView.IsMine)
        {
            this.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime;
        }
    }
}
