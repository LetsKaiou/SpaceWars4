using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObj : MonoBehaviour
{
    // 生成する範囲取得
    [SerializeField] private GameObject Range_X1;
    [SerializeField] private GameObject Range_X2;
    [SerializeField] private GameObject Range_Y1;
    [SerializeField] private GameObject Range_Y2;
    [SerializeField] private GameObject Range_Z1;
    [SerializeField] private GameObject Range_Z2;
    // 生成するオブジェクト格納用
    [SerializeField] private GameObject[] Obj = new GameObject[10];
    private GameObject[] MapObj = new GameObject[256];
    // 生成するオブジェクトの数
    [SerializeField] private int CreateNum;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < CreateNum; i++)
        {
            
            int Number = Random.Range(0, Obj.Length);
            float x = Random.Range(-600, 800);
            float y = Random.Range(70, -90);
            float z = Random.Range(1900, -1900);
            MapObj[i] = Instantiate(Obj[Number], new Vector3(x, y, z), Obj[Number].transform.rotation);
            MapObj[i].tag = "Dust";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}