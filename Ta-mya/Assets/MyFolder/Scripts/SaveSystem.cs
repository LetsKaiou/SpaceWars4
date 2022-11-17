using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem
{
    // しんぐるとん
    private static SaveSystem instance = new SaveSystem();
    public static SaveSystem Instance => instance;

    private SaveSystem(){ Load(); }

    // データの保存先設定
    public string Path => Application.dataPath + "/data.json";
    private MainShipData mainShipData = new MainShipData();
    public MainShipData MainShipData { get; private set; }

    // jsonデータ保存
    public void Save()
    {
        string jsonData = JsonUtility.ToJson(MainShipData);
        StreamWriter writer = new StreamWriter(Path, false);    // false → 上書き　true → 新規に書く
        writer.WriteLine(jsonData);
        writer.Flush();
        writer.Close();
    }

    public void Load()
    {
        if(!File.Exists(Path))
        {
            Debug.Log("I can't find a file");
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
