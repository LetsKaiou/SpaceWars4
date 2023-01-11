using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    public Vector3 difference;
    float differenceX;

    float _anglePerFrame = 0.01f;    // 1ÉtÉåÅ[ÉÄÇ…âΩìxâÒÇ∑Ç©[unit : deg]
    float _rot = 0.0f;

    void Start()
    {

        difference = transform.localPosition;
        differenceX = difference.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (GameObject.Find("Yamato") == true)
        {
            Vector3 startVec = GameObject.Find("Yamato").transform.localPosition;
            transform.localPosition = new Vector3(startVec.x + difference.x, startVec.y + difference.y, startVec.z + difference.z);
        }

    }
}
