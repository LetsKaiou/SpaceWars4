using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP3hit : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.instance.P_Damage(20);
        }
        if (other.gameObject.tag == "Enemy")
        {
            Enemy.instance.E_Damage(CreateShip.Attack[2], 0);
        }
        if (other.gameObject.tag == "Enemy2")
        {
            Enemy.instance.E_Damage(CreateShip.Attack[2], 1);
        }
        if (other.gameObject.tag == "Enemy3")
        {
            Enemy.instance.E_Damage(CreateShip.Attack[2], 2);
        }
    }
}
