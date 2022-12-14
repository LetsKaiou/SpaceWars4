using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;

public class Save : MonoBehaviour
{
    // 入力の省略用
    private SaveSystem System => SaveSystem.Instance;
    private MainShipData Data => System.MainShipData;

    public void Start()
    {
        // セーブするステータスの反映
        //SetStatus();
    }

    // Update is called once per frame
    void Update()
    {
        // セーブ
        //if (Input.GetKeyDown(KeyCode.S))
        //{

        //    //SaveSystem.Instance.MainShipData.CT[] = createcs.GetCT(i);
        //    SaveSystem.Instance.Save();
        //    
        //}

        // ロード
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Load" + System.MainShipData.HP);
            System.Load();
        }

        // 表示
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("HP:"  + Data.HP);
            Debug.Log("CT:"  + Data.CT);
            Debug.Log("ATK:" + Data.ATK);
        }

        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    SaveSystem.Instance.MainShipData.HP += 30;
        //}
    }

    // ステータス保存
    public static void SetStatus()
    {
        Debug.Log("SetStatusIn");
        SaveSystem.Instance.Load();

        //SaveSystem.Instance.MainShipData.HP  = PreviewScore.Com;
        //SaveSystem.Instance.MainShipData.CT  = PreviewScore.Agr;
        //SaveSystem.Instance.MainShipData.ATK = PreviewScore.Ind;
        DataSave();
    }

    public static void DataSave()
    {
        Debug.Log("せーぶ");

        SaveSystem.Instance.Save();
        Debug.Log(SaveSystem.Instance.MainShipData.HP);
    }

}
