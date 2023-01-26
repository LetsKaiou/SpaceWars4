using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceUP : MonoBehaviour
{
    // 上昇量
    [SerializeField] private int DefencePoint;
    // 効果時間
    [SerializeField] private float EffectTime;
    // 経過時間格納
    private float TimeCount = 0f;
    private Player py;

    // インスタンス
    public static DefenceUP instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        py = GameObject.Find("Yamato").GetComponent<Player>();
        P_DefenceUp();
    }

    void Update()
    {
        // 効果時間計測処理
        TimeCount += Time.deltaTime;
        if (TimeCount > EffectTime)
        {
            // 効果時間過ぎたら戻す
            Player.instance.Defence -= DefencePoint;
            Destroy(this.gameObject);
        }
    }

    public void P_DefenceUp()
    {
        Player.instance.Defence += DefencePoint;
    }

}
