using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
    private bool Big_Map;   

    // データベース取得用変数
    [SerializeField] private SkillDatabase skillData;
    [SerializeField] private ShipDatabase shipData;

    // 持ってないドロップアイテムののIDを代入するリスト
    private List<int> SPDropIDList = new List<int>();
    private List<int> ShipDropIDList = new List<int>();

    // 獲得したアイテムのID格納用変数
    private int SPID;
    private int ShipID;
       

    void Start()
    {
        // 初期化処理
        SPDropIDList.Clear();
        ShipDropIDList.Clear();

        foreach (DropSkill dropSkill in skillData.SkillList)
        {
            if(dropSkill.isGet == false)
            {
                // 持っていない特殊攻撃のIDを格納
                SPDropIDList.Add(dropSkill.id);
            }
        }

        foreach (DropShip dropShip in shipData.SkillList)
        {
            if (dropShip.isGet == false)
            {
                // 持っていない味方船のIDを格納
                SPDropIDList.Add(dropShip.id);
            }
        }

    }

    private void SPGet()
    {
        SPID = Random.Range(1, SPDropIDList.Count);
        foreach (DropSkill dropSkill in skillData.SkillList)
        {
            if (dropSkill.id == SPID)
            {
                dropSkill.isGet = true;
            }
        }
    }

    private void ShipGet()
    {
        ShipID = Random.Range(1, ShipDropIDList.Count);
    }

}
