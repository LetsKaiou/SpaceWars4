using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem
{
    // ���񂮂�Ƃ�
    private static SaveSystem instance = new SaveSystem();
    public static SaveSystem Instance => instance;

    private SaveSystem(){ Load(); }

    // �f�[�^�̕ۑ���ݒ�
    public string Path => Application.dataPath + "/data.json";

    public MainShipData MainShipData { get; private set;}

    // json�f�[�^�ۑ�
    public void Save()
    {
        string jsonData = JsonUtility.ToJson(MainShipData);
        StreamWriter writer = new StreamWriter(Path, false);    // false �� �㏑���@true �� �V�K�ɏ���
        writer.WriteLine(jsonData);
        writer.Flush();
        writer.Close();
    }

    public void Load()
    {
        if(!File.Exists(Path))
        {
            Debug.Log("����N��");
            MainShipData = new MainShipData();
            Save();
            return;
        }

        StreamReader reader = new StreamReader(Path);
        string jsonData = reader.ReadToEnd();
        MainShipData = JsonUtility.FromJson<MainShipData>(jsonData);
        reader.Close();
    }
}
