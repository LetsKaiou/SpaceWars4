using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Bullet : MonoBehaviour
{
    public CreateShip sp_info;

    // 発射する特殊攻撃のオブジェクト格納用
    [SerializeField] private GameObject[] P_SPBullet;
    // どの特殊攻撃が撃たれたか判別
    public int[] P_BulletNumber;
    private bool P_SetData = false;
    public bool[] SPCheck;
    // 特殊攻撃のデータ取得
    private int[] P_Attack = new int[100];            
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
        
        if(P_SetData == false)
        {
            Setdata();
        }
        // 弾の移動
        rb.velocity = transform.forward * 3;
        
    }

    public void CreatBullet(int bulletNum, Vector3 pos)
    {

        bullet[bulletNum] = Instantiate(P_SPBullet[bulletNum]) as GameObject;
        Debug.Log(bullet[bulletNum]);
        //Debug.Log(eul);
    }

    public void Destroy(int bulletNum)
    {
       
        Destroy(bullet[bulletNum-1], P_Range[bulletNum-1]);
    }
    //public void RangeCount(int ShotSP, Vector3 pos, Quaternion eul)
    //{

    //    switch (ShotSP)
    //    {
    //        case 1:
    //            Debug.Log(SPCheck[ShotSP]);
    //            SPCheck[ShotSP] = false;  
    //            bullet[ShotSP] =(GameObject)Instantiate(P_SPBullet[ShotSP], pos, eul);

    //            if (SPCheck[ShotSP] == false)
    //            {
    //                //for (int i = 0; i < P_Range[ShotSP];)
    //                //{
    //                //    P_Range[ShotSP] = P_Range[ShotSP] - 1;
    //                //    Debug.Log("SP1が消えるまで:" + P_Range[ShotSP]);
    //                //}
    //                //if(P_Range[ShotSP] == 0)
    //                //{
    //                    Destroy(bullet[ShotSP], P_Range[ShotSP]);
    //                    SPCheck[ShotSP] = true;
    //                //}
    //            }
    //            break;
    //        case 2:
    //            if (SPCheck[ShotSP] == false)
    //            {
    //                P_Range[ShotSP] = P_Range[ShotSP] - 1;
    //                if (P_Range[ShotSP] == 0)
    //                {
    //                    SPCheck[ShotSP] = true;
    //                }
    //            }
    //            break;
    //        case 3:
    //            if (SPCheck[ShotSP] == false)
    //            {
    //                P_Range[ShotSP] = P_Range[ShotSP] - 1;
    //                if (P_Range[ShotSP] == 0)
    //                {
    //                    SPCheck[ShotSP] = true;
    //                }
    //            }
    //            break;
    //        case 4:
    //            if (SPCheck[ShotSP] == false)
    //            {
    //                P_Range[ShotSP] = P_Range[ShotSP] - 1;
    //                if (P_Range[ShotSP] == 0)
    //                {
    //                    SPCheck[ShotSP] = true;
    //                }
    //            }
    //            break;
    //    }
    //}




    public void Setdata()
    {
        for (int i = 0; i < 4; i++)
        {
            P_Attack[i] = sp_info.GetSPAttack(i);
            P_Range[i] = sp_info.GetSPRange(i);
        }
        P_SetData = true;
    }

}
