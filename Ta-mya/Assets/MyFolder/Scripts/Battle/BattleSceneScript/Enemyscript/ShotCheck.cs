using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCheck : MonoBehaviour
{
    public Enemy enemycs;
    GameObject rootObj;
    Enemy rootcs;

    public void Start()
    {
        rootObj = transform.root.gameObject;
        rootcs = rootObj.GetComponent<Enemy>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rootcs.shot();
            rootcs.SPShot();
            rootcs.In = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemycs.In = false;
        }
    }
}
