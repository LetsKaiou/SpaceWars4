using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    // Heal
    [SerializeField] private int HealPoint;
    // バリア
    [SerializeField] private int BariaPoint;
    // リジェネ
    private bool isRegene;                      // リジェネしてるかどうか
    [SerializeField] private int RegenePoint;   // 1回のリジェネの回復量
    private float RegeneCount; 
    [SerializeField] private float BuffTime;  // バフの効果時間
    // 体力アップ
    [SerializeField] private int HealthUpPoint;
    // スピードアップ
    [SerializeField] private float SpeedUpPoint;
    // 防御力アップ
    [SerializeField] private int DefencePoint;

    private Player py;

    private int[] SPID = new int[4];

    // データベース取得用変数
    [SerializeField] private SkillDatabase skillData;
    // 再生するエフェクトをいれるリスト
    private List<GameObject> EffectObjList = new List<GameObject>();
    private List<int> EffectIDList = new List<int>();


    public static Skill instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        // 配列の初期化
        EffectObjList.Clear();

        // 選択した特殊攻撃のIDを配列に代入
        for (int i = 0; i < SPID.Length; i++)
        {
            SPID[i] = int.Parse(Select_Special.SelectSpecial[i]);
        }

        // 選択した特殊攻撃と同じIDのエフェクトのオブジェクトとIDをリストに追加
        foreach (DropSkill dropSkill in skillData.SkillList)
        {
            for (int i = 0; i < SPID.Length; i++)
            {
                if(dropSkill.id == SPID[i])
                {
                    EffectObjList.Add(dropSkill.EffectObj);
                    EffectIDList.Add(dropSkill.id);
                    Debug.Log("ID:" + dropSkill.id);
                }
            }
        }
    }

    private void Update()
    {
        if (isRegene == true)
        {
            RegeneCount += Time.deltaTime;
        }
        if (RegeneCount > BuffTime)
        {
            Player.instance.Player_HP += RegenePoint;
            RegeneCount = 0f;
            isRegene = false;
        }
    }


    public void StartEffect(int UseSPID)
    {
        Instantiate(EffectObjList[UseSPID-1], this.transform.position, Quaternion.identity); //パーティクル用ゲームオブジェクト
        switch(EffectIDList[UseSPID - 1])
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                Heal();
                break;
            case 11:
                StatusHeal();
                break;
            case 12:
                Baria();
                break;
            case 13:
                Regenerate();
                break;
            case 14:
                Warp();
                break;
            case 15:
                HelthUP();
                break;
            case 16:
                SpeedUP();
                break;
            case 17:
                DefenceUP();
                break;
        }
    }

    // HP回復 ID:10
    public void Heal()
    {
        py = GameObject.Find("Yamato").GetComponent<Player>();
        Player.instance.hp_slider.value += HealPoint;
    }
    // 状態異常回復 ID:11
    public void StatusHeal()
    {
        // 状態異常実装時に作成 → 状態異常になったらtrueにする
        // 状態異常のboolをfalseに変更
    }
    // バリア ID:12
    public void Baria()
    {
        // 専用ステータスをプレイヤーで定義してその値を決定・減少させる
    }
    // リジェネ ID:13
    public void Regenerate()
    {
        isRegene = true;
    }
    // ワープ ID:14
    public void Warp()
    {
        // 仕様わからない
        // 特定の場所に味方の船と一緒にワープさせる
    }
    // 最大体力アップ ID:15
    public void HelthUP()
    {
        Player.instance.hp_slider.maxValue += HealthUpPoint;
    }
    // スピードアップ ID:16
    public void SpeedUP()
    {
        Player.instance.speed += SpeedUpPoint;
    }
    // 防御力アップ ID:17
    public void DefenceUP()
    {
        Player.instance.Defence += DefencePoint;
    }
}
