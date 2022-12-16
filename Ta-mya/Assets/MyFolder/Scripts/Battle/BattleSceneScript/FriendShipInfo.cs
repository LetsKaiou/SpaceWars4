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
        csvFile = Resources.Load("CSV/status") as TextAsset;//�w�肵���t�@�C����TextAsset�Ƃ��ēǂݍ���(�t�@�C������.csv�͕s�v�Ȃ��Ƃɒ���)�@�ŏ��̍s�i�^�C�g�������j���ǂݍ��܂��̂ł����͎g�p���Ȃ�
        StringReader reader = new StringReader(csvFile.text);//
        while (reader.Peek() != -1)//�Ō�܂œǂݍ��ނ�-1�ɂȂ�֐�
        {
            string line = reader.ReadLine();//��s���ǂݍ���
            FriendShipData.Add(line.Split(','));//,��؂�Ń��X�g�ɒǉ����Ă���
        }
    }

    public void Init()
    {
        Debug.Log("Init");

        CsvReader();//�����ꎞ�i�[
        //�e�ϐ��փf�[�^���i�[�@CSV�t�@�C�����̍s�����ǂݍ��݁i�S�X�e�[�^�X�f�[�^�j
        for (int i = 1; i < FriendShipData.Count; i++)
        {
            Name[i] = FriendShipData[i][0];
            HP[i]  = int.Parse(FriendShipData[i][1]);//string�^����int�^�֕ϊ�
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
