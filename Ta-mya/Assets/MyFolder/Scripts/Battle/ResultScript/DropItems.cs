using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class DropItems : MonoBehaviour
{

    //  1.���}�b�v�Ȃ����U���A��}�b�v�Ȃ疡���D���h���b�v
    //���f�[�^�x�[�X��ID���烉���_���Ƀh���b�v�H
    //���h���b�v����ID�̕ۑ�
    //  2.�l����������U���A�����D��isGet��true�ɕύX
    //���f�[�^�x�[�X��isGet����ύX
    //  3.�l����������U���A�����D��json�ŕۑ�
    //���l����������U���A�����D��ID��o�^����
    //���Q�[���̃X�^�[�g����ID�ɑΉ��������isGet��true�ɕύX

    // �}�b�v�̃T�C�Y����
    private bool Big_Map = false;   

    // �f�[�^�x�[�X�擾�p�ϐ�
    [SerializeField] private SkillDatabase skillData;
    [SerializeField] private ShipDatabase shipData;

    // �����ĂȂ��h���b�v�A�C�e���̂�ID�������郊�X�g
    private List<int> SPDropIDList = new List<int>();
    private List<int> ShipDropIDList = new List<int>();

    // �l�������A�C�e����ID�i�[�p�ϐ�
    private int SPID;
    private int ShipID;

    // json�ɕۑ�����ۂ̔z��ԍ��w��p
    private int A_InDataCount;  // ����U���p
    private int S_InDataCount;  // �����D�p
    private static int a;

    // �Z�[�u�p�̓��͏ȗ�
    private SaveSystem System => SaveSystem.Instance;
    private MainShipData Data => System.MainShipData;

    void Start()
    {
        // ����������
        SPDropIDList.Clear();
        ShipDropIDList.Clear();
        A_InDataCount = 0;
        S_InDataCount = 0;

        foreach (DropSkill dropSkill in skillData.SkillList)
        {
            if(dropSkill.isGet == false)
            {
                // �����Ă��Ȃ�����U����ID���i�[
                SPDropIDList.Add(dropSkill.id);
            }
            else
            {
                // �����Ă������U����ID��json�z��ɑ��
                Data.SkillID[A_InDataCount] = dropSkill.id;
                Debug.Log("SkillID:" + Data.SkillID[A_InDataCount]);
                A_InDataCount++;
                
            }
        }

        foreach (DropShip dropShip in shipData.SkillList)
        {
            if (dropShip.isGet == false)
            {
                // �����Ă��Ȃ������D��ID���i�[
                SPDropIDList.Add(dropShip.id);
            }
            else
            {
                // �����Ă��閡���D��ID��json�z��ɑ��
                Data.ShipID[S_InDataCount] = dropShip.id;
                S_InDataCount++;
            }
        }

        // ��}�b�v�������疡���D���h���b�v
        if(Big_Map == true)
        {
            ShipGet();
        }
        // ���}�b�v�����������U�����h���b�v
        else
        {
            SPGet();
        }

    }

    private void SPGet()
    {
        SPID = Random.Range(1, SPDropIDList.Count);
        Debug.Log("Count:" + SPDropIDList.Count);
        foreach (DropSkill dropSkill in skillData.SkillList)
        {
            // isGet��true�ɕς���
            if (dropSkill.id == SPDropIDList[SPID])
            {
                Debug.Log("�l����������U����ID:" + SPDropIDList[SPID]);
                // �l����������U����ID��json�z��ɑ��
                Data.SkillID[A_InDataCount] = SPDropIDList[SPID];
                // json��ۑ�
                System.Save();
                dropSkill.isGet = true;
            }
        }
    }

    private void ShipGet()
    {
        ShipID = Random.Range(1, ShipDropIDList.Count);
        foreach (DropShip dropShip in shipData.SkillList)
        {
            // isGet��true�ɕς���
            if (dropShip.id == ShipID)
            {
                // �l�����������D��ID��json�z��ɑ��
                Data.ShipID[S_InDataCount] = ShipDropIDList[ShipID];
                // json��ۑ�
                System.Save();
                dropShip.isGet = true;
            }
        }
    }

}
