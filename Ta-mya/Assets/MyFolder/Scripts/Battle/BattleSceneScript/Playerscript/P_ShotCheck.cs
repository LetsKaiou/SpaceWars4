using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ShotCheck : MonoBehaviour
{
    public Enemy enemycs;
    GameObject rootObj;
    Player rootcs;

    public void Start()
    {
        rootObj = transform.root.gameObject;
        rootcs = rootObj.GetComponent<Player>();
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            rootcs.shot();
        }
        else if (other.gameObject.tag == "Enemy2")
        {
            rootcs.shot();
        }
        else if (other.gameObject.tag == "Enemy3")
        {
            rootcs.shot();
        }
        else if (other.gameObject.tag == "Enemy4")
        {
            rootcs.shot();
        }
    }
    public void OnTriggerExit(Collider other)
    {

    }
}
