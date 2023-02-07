using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ShotCheck : MonoBehaviour
{
    GameObject rootObj;
    Player rootcs;
    private Transform E_Positon;

    public void Start()
    {
        rootObj = transform.root.gameObject;
        rootcs = rootObj.GetComponent<Player>();
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            E_Pos(other);
            rootcs.shot();
        }
        else if (other.gameObject.tag == "Enemy1")
        {
            E_Pos(other);
            rootcs.shot();
        }
        else if (other.gameObject.tag == "Enemy2")
        {
            Debug.Log("In");
            E_Pos(other);
            rootcs.shot();
        }
        else if (other.gameObject.tag == "Enemy3")
        {
            E_Pos(other);
            rootcs.shot();
        }
        else if (other.gameObject.tag == "Enemy4")
        {
            E_Pos(other);
            rootcs.shot();
        }
    }

    // “G‘D‚ÌPos‚ð‘ã“ü
    public void E_Pos(Collider other)
    {
        E_Positon = other.transform;
    }

    // “G‘D‚ÌPositon‚ð•Ô‚·
    public Transform ReturnPos()
    {
        return E_Positon;
    }

}
