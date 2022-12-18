using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Special_info 
{
    static TextAsset csvFile;
    // 一時格納先のリスト
    public static List<string[]> SpecialList = new List<string[]>();
    // 格納するデータの変数
    public string[] Name = new string[100];         // 名前
    public int[] Attack = new int[100];             // 攻撃力
    public float[] CT = new float[100];             // クールタイム
    public int[] Range = new int[100];              // 射程(弾が消えるまでの時間)
    public string[] Explanatory = new string[100];  // 特殊攻撃の説明文
    public string[] Image = new string[50];         // 特殊攻撃のアイコン
    public int[] ID = new int[20];
    public bool Ones = false;

    //[SerializeField] private DropSkill drop;

    // Start is called before the first frame update
    static void CsvReader()
    {
    //指定したファイルをTextAssetとして読み込み
    csvFile = Resources.Load("CSV/Special_Attack") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        //最後まで読み込むと-1になる関数
        while (reader.Peek() != -1)
        {
            //一行ずつ読み込み
            string line = reader.ReadLine();
            //,区切りでリストに追加していく
            SpecialList.Add(line.Split(','));
        }
    }

    // データの格納処理
    public void Init()
    {
        if (Ones == false)
        {
            //情報を一時格納
            CsvReader();
            
            //各変数へデータを格納　CSVファイル内の行数分読み込み（全ステータスデータ）
            //Debug.Log("count="+SpecialInfo.Count);
            for (int i = 1; i < SpecialList.Count; i++)
            {
                
                Name[i] = SpecialList[i][0];
                Attack[i] = int.Parse(SpecialList[i][1]);//string型からint型へ変換
                CT[i] = float.Parse(SpecialList[i][2]);
                Range[i] = int.Parse(SpecialList[i][3]);
                Explanatory[i] = SpecialList[i][4];
                Image[i] = SpecialList[i][5];
                ID[i] = int.Parse(SpecialList[i][6]);
            }
            Ones = true;
        }
    }

    // データの初期化
    public void Delete()
    {
        SpecialList.Clear();
    }

}
