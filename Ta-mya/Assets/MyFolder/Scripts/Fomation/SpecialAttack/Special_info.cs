using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Special_info 
{
    static TextAsset csvFile;
    // �ꎞ�i�[��̃��X�g
    public static List<string[]> SpecialList = new List<string[]>();
    // �i�[����f�[�^�̕ϐ�
    public string[] Name = new string[100];         // ���O
    public int[] Attack = new int[100];             // �U����
    public float[] CT = new float[100];             // �N�[���^�C��
    public int[] Range = new int[100];              // �˒�(�e��������܂ł̎���)
    public string[] Explanatory = new string[100];  // ����U���̐�����
    public string[] Image = new string[50];         // ����U���̃A�C�R��
    public int[] ID = new int[20];
    public bool Ones = false;

    //[SerializeField] private DropSkill drop;

    // Start is called before the first frame update
    static void CsvReader()
    {
    //�w�肵���t�@�C����TextAsset�Ƃ��ēǂݍ���
    csvFile = Resources.Load("CSV/Special_Attack") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        //�Ō�܂œǂݍ��ނ�-1�ɂȂ�֐�
        while (reader.Peek() != -1)
        {
            //��s���ǂݍ���
            string line = reader.ReadLine();
            //,��؂�Ń��X�g�ɒǉ����Ă���
            SpecialList.Add(line.Split(','));
        }
    }

    // �f�[�^�̊i�[����
    public void Init()
    {
        if (Ones == false)
        {
            //�����ꎞ�i�[
            CsvReader();
            
            //�e�ϐ��փf�[�^���i�[�@CSV�t�@�C�����̍s�����ǂݍ��݁i�S�X�e�[�^�X�f�[�^�j
            //Debug.Log("count="+SpecialInfo.Count);
            for (int i = 1; i < SpecialList.Count; i++)
            {
                
                Name[i] = SpecialList[i][0];
                Attack[i] = int.Parse(SpecialList[i][1]);//string�^����int�^�֕ϊ�
                CT[i] = float.Parse(SpecialList[i][2]);
                Range[i] = int.Parse(SpecialList[i][3]);
                Explanatory[i] = SpecialList[i][4];
                Image[i] = SpecialList[i][5];
                ID[i] = int.Parse(SpecialList[i][6]);
            }
            Ones = true;
        }
    }

    // �f�[�^�̏�����
    public void Delete()
    {
        SpecialList.Clear();
    }

}
