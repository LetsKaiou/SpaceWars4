using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCheck : MonoBehaviour
{
    public Enemy enemycs;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemycs.shot();
            enemycs.SPShot();
            enemycs.In = true;
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
