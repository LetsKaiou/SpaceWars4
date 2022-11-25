using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCheck : MonoBehaviour
{
    public Player playersc;
    public Enemy enemysc;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemysc.shot();
            enemysc.In = true;
        }
    }
}
