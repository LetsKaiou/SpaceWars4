using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPDUP : MonoBehaviour
{
    [SerializeField] private int SPDPoint;
    [SerializeField] private float EffectTime;
    private float TimeCount = 0f;
    private Player py;

    public static SPDUP instance;

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
        P_SPDUp();
    }

    // Update is called once per frame
    void Update()
    {      
        // 効果時間計測処理
        TimeCount += Time.deltaTime;
        if (TimeCount > EffectTime)
        {
            // 効果時間過ぎたら戻す
            Player.instance.speed -= SPDPoint;
            Destroy(this.gameObject);
        }
    }

    private void P_SPDUp()
    {
        Player.instance.speed += SPDPoint;
    }
}
