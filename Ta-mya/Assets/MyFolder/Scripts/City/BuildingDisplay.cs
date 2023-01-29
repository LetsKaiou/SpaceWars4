using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDisplay : MonoBehaviour
{

    // セーブ用の入力省略
    private SaveSystem System => SaveSystem.Instance;
    private MainShipData Data => System.MainShipData;

    
    public GameObject Ind1_2;
    public GameObject Ind1_3;
    public GameObject Ind1_4;
    public GameObject Ind1_5;
    public GameObject Ind1_6;
    public GameObject Ind1_7;
    public GameObject Ind1_8;
    
    public GameObject Ind2_2;
    public GameObject Ind2_3;
    public GameObject Ind2_4;
    public GameObject Ind2_5;
    public GameObject Ind2_6;
    
    public GameObject Ind3_2;
    public GameObject Ind3_3;
    public GameObject Ind3_4;
    
    public GameObject Tetto_2;
    public GameObject Tetto_3;
    public GameObject Tetto_4;

    public GameObject Shop_2;
    public GameObject Shop_3;
    public GameObject Shop_4;
    public GameObject Shop_5;
    public GameObject Shop_6;
    public GameObject Shop_7;
    public GameObject Shop_8;
    public GameObject Shop_9;
    public GameObject Shop_10;
    public GameObject Shop_11;
    public GameObject Biru_1;
    public GameObject Biru_2;
    public GameObject Conbini_1;
    public GameObject Conbini_2;

    public GameObject Bokujo_2;
    public GameObject Bokujo_3;

    public GameObject Tower_1;
    public GameObject Tower_2;
    public GameObject Tower_3;
    
    public GameObject SAKU_2;
    public GameObject SAKU_3;
    public GameObject SAKU_4;
    public GameObject SAKU_5;
    public GameObject SAKU_6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Data.IndSum >= 30)
        {
            Ind1_2.SetActive(true);
        }
        if (Data.IndSum >= 60)
        {
            Ind2_2.SetActive(true);
        }
        if (Data.IndSum >= 90)
        {
            Tetto_2.SetActive(true);
        }
        if (Data.IndSum >= 120)
        {
            Ind1_3.SetActive(true);
        }
        if (Data.IndSum >= 150)
        {
            Ind1_4.SetActive(true);
        }
        if (Data.IndSum >= 180)
        {
            Tetto_3.SetActive(true);
        }
        if (Data.IndSum >= 210)
        {
            Ind3_2.SetActive(true);
        }
        if (Data.IndSum >= 240)
        {
            Ind2_3.SetActive(true);
        }
        if (Data.IndSum >= 270)
        {
            Ind1_5.SetActive(true);
        }
        if (Data.IndSum >= 300)
        {
            Ind2_4.SetActive(true);
        }
        if (Data.IndSum >= 330)
        {
            Ind1_6.SetActive(true);
        }
        if (Data.IndSum >= 360)
        {
            Ind3_3.SetActive(true);
        }
        if (Data.IndSum >= 390)
        {
            Ind1_7.SetActive(true);
        }
        if (Data.IndSum >= 420)
        {
            Ind2_5.SetActive(true);
        }
        if (Data.IndSum >= 450)
        {
            Ind1_8.SetActive(true);
        }
        if (Data.IndSum >= 480)
        {
            Tetto_4.SetActive(true);
        }
        if (Data.IndSum >= 510)
        {
            Ind2_6.SetActive(true);
        }
        if (Data.IndSum >= 540)
        {
            Ind3_4.SetActive(true);
        }


        if (Data.ComSum >= 100)
        {
            Conbini_1.SetActive(true);
        }
        if (Data.ComSum >= 150)
        {
            Biru_1.SetActive(true);
        }
        if (Data.ComSum >= 200)
        {
            Shop_2.SetActive(true);
        }
        if (Data.ComSum >= 250)
        {
            Shop_3.SetActive(true);
        }
        if (Data.ComSum >= 300)
        {
            Shop_4.SetActive(true);
        }
        if (Data.ComSum >= 350)
        {
            Shop_5.SetActive(true);
        }
        if (Data.ComSum >= 400)
        {
            Biru_2.SetActive(true);
        }
        if (Data.ComSum >= 450)
        {
            Shop_6.SetActive(true);
        }
        if (Data.ComSum >= 500)
        {
            Shop_7.SetActive(true);
        }
        if (Data.ComSum >= 550)
        {
            Shop_8.SetActive(true);
        }
        if (Data.ComSum >= 600)
        {
            Conbini_2.SetActive(true);
        }
        if (Data.ComSum >= 750)
        {
            Shop_9.SetActive(true);
        }
        if (Data.ComSum >= 800)
        {
            Shop_10.SetActive(true);
        }
        if (Data.ComSum >= 850)
        {
            Shop_11.SetActive(true);
        }

        if (Data.AgrSum >= 2)
        {
            Bokujo_2.SetActive(true);
        }
        if (Data.AgrSum >= 4)
        {
            Tower_2.SetActive(true);
        }
        if (Data.AgrSum >= 6)
        {
            SAKU_2.SetActive(true);
        }
        if (Data.AgrSum >= 8)
        {
            Bokujo_3.SetActive(true);
        }
        if (Data.AgrSum >= 10)
        {
            Tower_3.SetActive(true);
        }
        if (Data.AgrSum >= 12)
        {
            SAKU_3.SetActive(true);
        }
        if (Data.AgrSum >= 14)
        {
            SAKU_4.SetActive(true);
        }
        if (Data.AgrSum >= 16)
        {
            SAKU_5.SetActive(true);
        }
        if (Data.AgrSum >= 18)
        {
            SAKU_6.SetActive(true);
        }


    }
}
