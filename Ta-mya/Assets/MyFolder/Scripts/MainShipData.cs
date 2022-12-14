using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MainShipData
{
    // 保存するもの
    // 自機のステータス(HP,CT,特殊攻撃の攻撃力)、建物のデータ(各開発ポイントの累積値)、持っている特殊攻撃・味方の戦闘機

    
    public int HP = 60; // メイン艦のHP(合計値とHPを足し算した値が入る)
    public float CT;    // CTの短縮される時間(合計値と同じ値が入る)
    public int ATK;     // 特殊攻撃の攻撃力・効果量(合計値と同じ値が入る)

    // それぞれの開発ポイントの合計値
    public int IndSum;
    public int ComSum;
    public float AgrSum;

}
