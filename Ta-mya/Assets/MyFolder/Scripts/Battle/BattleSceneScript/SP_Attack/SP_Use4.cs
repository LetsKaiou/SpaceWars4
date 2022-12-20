using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SP_Use4 : MonoBehaviour
{
    public Image UIobj;
    public bool Use;
    public float CoolTime;
    private int SP4_ATK;
    private int SpecialNum;
    private float Now;

    public CreateShip createShip;
    private Special_info specialInfo;
    public Player PlayerScript;

    // セーブ用の入力省略
    private SaveSystem System => SaveSystem.Instance;
    private MainShipData Data => System.MainShipData;

    public static SP_Use4 instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        SP4_ATK = CreateShip.Attack[3] + Data.ATK;
        CoolTime = CreateShip.CT[3] - Data.CT;
        //Debug.Log(i+"のCT:"+CoolTime[i]);
    }

    // Update is called once per frame
    void Update()
    {
        UIobj.fillAmount += 1.0f / CoolTime * Time.deltaTime;
        if (UIobj.fillAmount == 1)
        {
            PlayerScript.Reload[3] = true;
        }
    }


    public void SetSpecialNum()
    {
        Debug.Log("SpecialNum:" + SpecialNum);

        SpecialNum = PlayerScript.GetSpecialNum() - 1;
        UIobj.fillAmount = 0;
    }

    public int SP4Damage()
    {
        return SP4_ATK;
    }

}
