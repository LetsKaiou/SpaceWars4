using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;

public class Save : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        // セーブ
        if (Input.GetKeyDown(KeyCode.S))
        {

            //SaveSystem.Instance.MainShipData.CT[] = createcs.GetCT(i);
            SaveSystem.Instance.Save();
            Debug.Log("せーぶ");
        }

        // ロード
        if (Input.GetKeyDown(KeyCode.L))
        {
            SaveSystem.Instance.Load();
        }

        // 表示
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("HP:" + SaveSystem.Instance.MainShipData.HP);
            Debug.Log("CT:" + SaveSystem.Instance.MainShipData.CT);
            Debug.Log("ATK:" + SaveSystem.Instance.MainShipData.ATK);
        }

        if(Input.GetKeyDown(KeyCode.U))
        {
            SaveSystem.Instance.MainShipData.HP += 30;
        }
    }

    // ステータス保存
    public void SetStatus()
    {
        
        SaveSystem.Instance.MainShipData.HP = Player.GetHp();
        for (int i = 0; i < 4; i++)
        {
            SaveSystem.Instance.MainShipData.CT[i]  = CreateShip.CT[i];
            SaveSystem.Instance.MainShipData.ATK[i] = CreateShip.Attack[i];
        }
        DataSave();
    }

    public void DataSave()
    {
        SaveSystem.Instance.Save();
    }

}
