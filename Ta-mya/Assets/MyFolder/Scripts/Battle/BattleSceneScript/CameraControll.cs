using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    //private Vector3 offset;
    //public GameObject player;
    //private Vector3 axis;
    public Vector3 difference;
    float differenceX;

    float _anglePerFrame = 0.01f;    // 1ÉtÉåÅ[ÉÄÇ…âΩìxâÒÇ∑Ç©[unit : deg]
    //float _rot = 0.0f;

    void Start()
    {

        difference = transform.localPosition;
        differenceX = difference.x;
        //axis = player.transform.eulerAngles;
        //offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, 10.0f * Time.deltaTime);
        //Vector3 _axis=axis- player.transform.eulerAngles;
        //transform.RotateAround(player.transform.position, _axis);
        if (GameObject.Find("Yamato") == true)
        {
            Vector3 startVec = GameObject.Find("Yamato").transform.localPosition;
            transform.localPosition = new Vector3(startVec.x + difference.x, startVec.y + difference.y, startVec.z + difference.z);
        }

    }
}
