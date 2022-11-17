using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MainShipData
{
    // 保存するもの
    // 自機のステータス(HP,CT,特殊攻撃の攻撃力)、建物のデータ(各開発ポイントの累積値)、持っている特殊攻撃・味方の戦闘機

        public int HP = 12;
        public float CT = 3;
        public int ATK = 5;
}
