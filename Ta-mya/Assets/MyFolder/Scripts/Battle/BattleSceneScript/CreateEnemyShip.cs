using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemyShip : MonoBehaviour
{
    // 敵船情報格納用
    [SerializeField] private GameObject EnemyShip;
    private GameObject[] EnemyClones = new GameObject[10];
    [SerializeField] private Vector3[] EnemyCreatePos = new Vector3[10];
    GameObject[] enemyparent = new GameObject[2];
    private int Num;
    private string[] TagName = new string[10];
    // 大マップか小マップどっちが選ばれてるか判断
    [SerializeField] private bool isBigMap;
    // 生成する数
    private int Counter;

    // Start is called before the first frame update
    void Start()
    {
        
        SetTag();   // stringにタグの名前割当

        enemyparent[0] = GameObject.FindGameObjectWithTag("Enemy");
        enemyparent[1] = GameObject.FindGameObjectWithTag("Enemy2");

        if (isBigMap == true)
        {
            Counter = 4;    // 大マップだったら生成数を4にする
            BigMap();
        }
        else
        {
            Counter = 2;    // 小マップだったら生成数を2にする
            Smallmap();     
        }

    }

    // 小マップ用処理
    public void Smallmap()
    {
        for (int i = 0; i < 2; i++) // 2回実行して艦隊を2つ作る
        {
            // Counterの数だけ船の生成
            for (int count = 0; count < Counter; count++)
            {
                EnemyClones[count] = Instantiate(EnemyShip, EnemyCreatePos[count], Quaternion.identity);
                // 当たり判定取得用のタグとステータスを生成時に割り当てる
                switch (count)
                {
                    case 0:
                        EnemyClones[count].tag = TagName[Num];
                        EnemyClones[count].transform.parent = enemyparent[i].transform;
                        break;
                    case 1:
                        EnemyClones[count].tag = TagName[Num];
                        EnemyClones[count].transform.parent = enemyparent[i].transform;
                        break;
                }
            }
        }
    }

    // 大マップ用の処理
    public void BigMap()
    {
        for (int i = 0; i < 2; i++)
        {
            // Counterの数だけ船の生成
            for (int count = 0; count < Counter; count++)
            {
                EnemyClones[count] = Instantiate(EnemyShip, EnemyCreatePos[count], Quaternion.identity);
                // 当たり判定取得用のタグとステータスを生成時に割り当てる
                switch (count)
                {
                    case 0:
                        EnemyClones[count].tag = TagName[Num];
                        EnemyClones[count].transform.parent = enemyparent[i].transform;
                        break;
                    case 1:
                        EnemyClones[count].tag = TagName[Num];
                        EnemyClones[count].transform.parent = enemyparent[i].transform;
                        break;
                    case 2:
                        EnemyClones[count].tag = TagName[Num];
                        EnemyClones[count].transform.parent = enemyparent[i].transform;
                        break;
                    case 3:
                        EnemyClones[count].tag = TagName[Num];
                        EnemyClones[count].transform.parent = enemyparent[i].transform;
                        break;
                }
                Num++;
            }

        }
    }

    public void SetTag()
    {
        for (int i = 0; i < 10; i++)
        {
            int icount = i + 1;
            TagName[i] = "EnemyChild" + icount;
        }
    }

}
