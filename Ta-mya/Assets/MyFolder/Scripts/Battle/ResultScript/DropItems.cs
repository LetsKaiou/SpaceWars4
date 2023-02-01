using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using UnityEngine.UI;

public class DropItems : MonoBehaviour
{

    //  1.小マップなら特殊攻撃、大マップなら味方船をドロップ
    //→データベースのIDからランダムにドロップ？
    //→ドロップしたIDの保存
    //  2.獲得した特殊攻撃、味方船のisGetをtrueに変更
    //→データベースのisGetから変更
    //  3.獲得した特殊攻撃、味方船をjsonで保存
    //→獲得した特殊攻撃、味方船のIDを登録する
    //→ゲームのスタート時にIDに対応したやつのisGetをtrueに変更

    // マップのサイズ判別
    public static bool Big_Map;   

    // データベース取得用変数
    [SerializeField] private SkillDatabase skillData;
    [SerializeField] private ShipDatabase shipData;

    // 持ってないドロップアイテムののIDを代入するリスト
    private List<int> SPDropIDList = new List<int>();
    private List<int> ShipDropIDList = new List<int>();

    // 獲得したアイテムのID格納用変数
    private int SPID;
    private int ShipID;
    [SerializeField] private Image GetSkillImage;

    // jsonに保存する際の配列番号指定用
    private int A_InDataCount;  // 特殊攻撃用
    private int S_InDataCount;  // 味方船用
    private static int a;

    // セーブ用の入力省略
    private SaveSystem System => SaveSystem.Instance;
    private MainShipData Data => System.MainShipData;

    public static DropItems instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        // 初期化処理
        SPDropIDList.Clear();
        ShipDropIDList.Clear();
        A_InDataCount = 0;
        S_InDataCount = 0;

        foreach (DropSkill dropSkill in skillData.SkillList)
        {
            if(dropSkill.isGet == false)
            {
                // 持っていない特殊攻撃のIDを格納
                SPDropIDList.Add(dropSkill.id);
            }
            else
            {
                // 持っている特殊攻撃のIDをjson配列に代入
                Data.SkillID[A_InDataCount] = dropSkill.id;
                A_InDataCount++;
                
            }
        }

        foreach (DropShip dropShip in shipData.SkillList)
        {
            if (dropShip.isGet == false)
            {
                // 持っていない味方船のIDを格納
                ShipDropIDList.Add(dropShip.id);
            }
            else
            {
                // 持っている味方船のIDをjson配列に代入
                Data.ShipID[S_InDataCount] = dropShip.id;
                S_InDataCount++;
            }
        }
        Debug.Log(Big_Map);
        // 大マップだったら味方船をドロップ
        if(Big_Map == true)
        {
            ShipGet();
        }
        // 小マップだったら特殊攻撃をドロップ
        else
        {
            SPGet();
        }

    }

    private void SPGet()
    {
        if(SPDropIDList.Count != 0)
        {
            SPID = Random.Range(0, SPDropIDList.Count);
            foreach (DropSkill dropSkill in skillData.SkillList)
            {
                // isGetをtrueに変える
                if (dropSkill.id == SPDropIDList[SPID])
                {
                    
                    //Debug.Log("獲得した特殊攻撃のID:" + SPDropIDList[SPID]);
                    GetSkillImage.sprite = dropSkill.Image;
                    // 獲得した特殊攻撃のIDをjson配列に代入
                    Data.SkillID[A_InDataCount] = SPDropIDList[SPID];
                    // jsonを保存
                    System.Save();
                    dropSkill.isGet = true;
                }
            }

        }
        else
        {
            Destroy(GetSkillImage);
        }

    }

    private void ShipGet()
    {
        if(ShipDropIDList.Count != 0)
        {
            ShipID = Random.Range(0, ShipDropIDList.Count);
            foreach (DropShip dropShip in shipData.SkillList)
            {
                // isGetをtrueに変える
                if (dropShip.id == ShipDropIDList[ShipID])
                {
                    GetSkillImage.sprite = dropShip.Image;
                    // 獲得した味方船のIDをjson配列に代入
                    Data.ShipID[S_InDataCount] = ShipDropIDList[ShipID];
                    // jsonを保存
                    System.Save();
                    dropShip.isGet = true;
                }
            }

        }
        else
        {
            return;
        }

    }

}
