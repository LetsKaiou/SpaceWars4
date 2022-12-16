using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class FriendShipInfo 
{
    static TextAsset csvFile;
    static List<string[]> FriendShipData = new List<string[]>();
    public string[] Name = new string[100];
    public  int[] HP = new int[100];
    public  int[] DEF = new int[100];
    public  int[] SPD = new int[100];
    public string[] Image = new string[50];
    public int[] ID = new int[20];

    public bool Ones = false;
    // Start is called before the first frame update
    static void CsvReader()
    {
        csvFile = Resources.Load("CSV/status") as TextAsset;//指定したファイルをTextAssetとして読み込み(ファイル名の.csvは不要なことに注意)　最初の行（タイトル部分）も読み込まれるのでそこは使用しない
        StringReader reader = new StringReader(csvFile.text);//
        while (reader.Peek() != -1)//最後まで読み込むと-1になる関数
        {
            string line = reader.ReadLine();//一行ずつ読み込み
            FriendShipData.Add(line.Split(','));//,区切りでリストに追加していく
        }
    }

    public void Init()
    {
        Debug.Log("Init");

        CsvReader();//情報を一時格納
        //各変数へデータを格納　CSVファイル内の行数分読み込み（全ステータスデータ）
        for (int i = 1; i < FriendShipData.Count; i++)
        {
            Name[i] = FriendShipData[i][0];
            HP[i]  = int.Parse(FriendShipData[i][1]);//string型からint型へ変換
            DEF[i] = int.Parse(FriendShipData[i][2]);
            SPD[i] = int.Parse(FriendShipData[i][3]);
            Image[i] = FriendShipData[i][4];
            ID[i] = int.Parse(FriendShipData[i][5]);
        
        }

    }

    public void Delete()
    {
        Debug.Log("Ship_Delete");
        FriendShipData.Clear();
    }
}
