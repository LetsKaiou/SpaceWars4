using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;

public class Save : MonoBehaviour
{

    public void Start()
    {
        // �Z�[�u����X�e�[�^�X�̔��f
        //SetStatus();
    }

    // Update is called once per frame
    void Update()
    {
        // �Z�[�u
        //if (Input.GetKeyDown(KeyCode.S))
        //{

        //    //SaveSystem.Instance.MainShipData.CT[] = createcs.GetCT(i);
        //    SaveSystem.Instance.Save();
        //    
        //}

        // ���[�h
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Load" + SaveSystem.Instance.MainShipData.HP);
            SaveSystem.Instance.Load();
        }

        // �\��
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("HP:"  + SaveSystem.Instance.MainShipData.HP);
            Debug.Log("CT:"  + SaveSystem.Instance.MainShipData.CT);
            Debug.Log("ATK:" + SaveSystem.Instance.MainShipData.ATK);
        }

        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    SaveSystem.Instance.MainShipData.HP += 30;
        //}
    }

    // �X�e�[�^�X�ۑ�
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
        Debug.Log("���[��");
       
        SaveSystem.Instance.Save();
        Debug.Log(SaveSystem.Instance.MainShipData.HP);
    }

}
