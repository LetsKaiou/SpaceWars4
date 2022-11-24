using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAxis : MonoBehaviour
{
    public Transform m_target;
    public float m_rotateSpeed = 2;

    void Update()
    {
        transform.RotateAround
        (
            m_target.position,
            Vector3.up,
            m_rotateSpeed * Time.deltaTime
        );
    }
}
