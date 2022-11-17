using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//[CreateAssetMenu(fileName = "Database", menuName = "子機データ/Database")]
public class FriendStatus : MonoBehaviour
{
    public struct FriendStatusData
    {
        public string name;
        //ステータス
        public  float HP;
        public  float DEF;
        public  float SPD;
    }

    //敵の構造体を格納するリスト
    public static List<FriendStatusData> status = new List<FriendStatusData>();


    void Start()
    {
        //敵リストに読み込んだ情報を反映
        status = STATUSDATA_read_csv();
    }


    //ENEMY構造体のcsvファイルを読み込む
    public List<FriendStatusData> STATUSDATA_read_csv()
    {
        //一時入力用で毎回初期化する構造体とリスト
        FriendStatusData data = new FriendStatusData();
        List<FriendStatusData> data_list = new List<FriendStatusData>();

        //ResourcesからCSVを読み込むのに必要
        TextAsset csvFile;

        //読み込んだCSVファイルを格納
        List<string[]> csvDatas = new List<string[]>();

        //CSVファイルの行数を格納
        int height = 0;

        //for文用。一行目は読み込まない
        int i = 1;

        /* Resouces/CSV下のCSV読み込み */
        csvFile = Resources.Load("CSV/status") as TextAsset;
        //読み込んだテキストをString型にして格納
        StringReader reader = new StringReader(csvFile.text);
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            // ,で区切ってCSVに格納
            csvDatas.Add(line.Split(','));
            height++; // 行数加算
        }
        for (i = 1; i < height; i++)
        {

            //csvDatasはString型なのでそのまま格納できる
            data.name = csvDatas[i][0];
            //String型をfloat型にして格納
            data.HP  = Convert.ToSingle(csvDatas[i][1]);
            data.DEF = Convert.ToSingle(csvDatas[i][2]);
            data.SPD = Convert.ToSingle(csvDatas[i][3]);

            Debug.Log("敵を読み込んだ：" + data.name[1]);
            //Debug.Log("HP：" + data.HP);
            //Debug.Log("DEF：" + data.DEF);
            //Debug.Log("SPD：" + data.SPD);

            //戻り値のリストに加える
            data_list.Add(data);
        }
        return data_list;
    }
}
