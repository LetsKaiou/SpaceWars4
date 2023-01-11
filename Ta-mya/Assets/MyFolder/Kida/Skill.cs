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
    [SerializeField] private float RegeneTime;  // リジェネする時間
    // 体力アップ
    [SerializeField] private int HealthUpPoint;
    // スピードアップ
    [SerializeField] private float SpeedUpPoint;
    // 防御力アップ
    [SerializeField] private int DefencePoint;

    public static Skill instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (isRegene == true)
        {
            RegeneCount += Time.deltaTime;
        }
        if (RegeneCount > RegeneTime)
        {
            Player.instance.Player_HP += RegenePoint;
            RegeneCount = 0f;
            isRegene = false;
        }
    }


    // HP回復
    public void Heal()
    {
        Player.instance.Player_HP += HealPoint;
    }
    // 状態異常回復
    public void StatusHeal()
    {
        // 状態異常実装時に作成 → 状態異常になったらtrueにする
        // 状態異常のboolをfalseに変更
    }
    // バリア
    public void Baria()
    {
        // 専用ステータスをプレイヤーで定義してその値を決定・減少させる
    }
    // リジェネ
    public void Regenerate()
    {
        isRegene = true;
    }
    // ワープ
    public void Warp()
    {
        // 仕様わからない
        // 特定の場所に味方の船と一緒にワープさせる
    }
    // 最大体力アップ
    public void HelthUP()
    {
        Player.instance.hp_slider.maxValue += HealthUpPoint;
    }
    // スピードアップ
    public void SpeedUP()
    {
        Player.instance.speed += SpeedUpPoint;
    }
    // 防御力アップ
    public void DefenceUP()
    {
        Player.instance.Defence += DefencePoint;
    }
}
