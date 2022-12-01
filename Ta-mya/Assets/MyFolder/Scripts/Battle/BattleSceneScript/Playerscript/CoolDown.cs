using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    public Image[] UIobj;
    public bool Use;
    public float[] CoolTime = new float[4];
    private int SpecialNum;
    private float Now;

    public CreateShip createShip;
    private Special_info specialInfo;
    public Player PlayerScript;

    private void Start()
    {
        for (int i = 0; i < Select_Special.SelectSpecial.Length; i++)
        {
            CoolTime[i] = createShip.CT[i];
            //Debug.Log(i+"‚ÌCT:"+CoolTime[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

       

        UIobj[SpecialNum].fillAmount += 1.0f / CoolTime[SpecialNum] * Time.deltaTime;
        if (UIobj[SpecialNum].fillAmount < 0)
        {
            Use = false;
        }


    }

    public void Count()
    {

        UIobj[SpecialNum].fillAmount += 1.0f / CoolTime[SpecialNum] * Time.deltaTime;
        if (UIobj[SpecialNum].fillAmount < 0)
        {
            Use = false;
        }
    }

    public void SetSpecialNum()
    {

        SpecialNum = PlayerScript.GetSpecialNum() - 1;
        UIobj[SpecialNum].fillAmount = 0;
    }

    //void FixedUpdate()
    //{
    //    if(Use == true)
    //    {
    //        if (0 <= CoolTime[SpecialNum])
    //        {
    //            CoolTime[SpecialNum] -= Time.deltaTime;
    //            Now = CoolTime[SpecialNum];
    //            //Debug.Log("Now:" + Now);
    //        }
    //    }
    //}

}
