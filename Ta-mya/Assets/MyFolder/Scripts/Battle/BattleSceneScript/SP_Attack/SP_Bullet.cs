using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Bullet : MonoBehaviour
{
    public CreateShip sp_info;
    public Player playersc;

    // 発射する特殊攻撃のオブジェクト格納用
    [SerializeField] private GameObject[] P_SPBullet;
    // どの特殊攻撃が撃たれたか判別
    public int P_BulletNumber;
    private bool P_SetData = false;
    public bool[] SPCheck;
    // 特殊攻撃のデータ取得
    public int[] P_Attack = new int[100];            
    private int[] P_Range = new int[100];
    GameObject[] bullet = new GameObject[4];
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        // 弾の移動
        rb.velocity = transform.forward * 15;
       
    }



    //public void Destroy(int bulletNum, int Range)
    //{
    //    P_Range[bulletNum - 1] = Range;
    //    Debug.Log("Range:" + P_Range[bulletNum - 1]);
    //    Destroy(bullet[bulletNum-1], P_Range[bulletNum - 1]);
    //}




}
