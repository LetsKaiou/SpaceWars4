using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveSystem.Instance.Save();
            Debug.Log("ÇπÅ[Ç‘");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SaveSystem.Instance.Load();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("HP:" + SaveSystem.Instance.MainShipData.HP);
            Debug.Log("CT:" + SaveSystem.Instance.MainShipData.CT);
            Debug.Log("ATK:" + SaveSystem.Instance.MainShipData.ATK);
        }

        if(Input.GetKeyDown(KeyCode.U))
        {
            SaveSystem.Instance.MainShipData.HP += 30;
        }
    }
}
