using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int i = 0; i < SelectShip.SelectShipNum.Length; i++)
            {
                Debug.Log(SelectShip.SelectShipNum[i]);
            }            
        }
    }
}
