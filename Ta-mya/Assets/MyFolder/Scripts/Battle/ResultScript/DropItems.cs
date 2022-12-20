using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
    private bool Big_Map;   

    // �f�[�^�x�[�X�擾�p�ϐ�
    [SerializeField] private SkillDatabase skillData;
    [SerializeField] private ShipDatabase shipData;

    // �����ĂȂ��h���b�v�A�C�e���̂�ID�������郊�X�g
    private List<int> SPDropIDList = new List<int>();
    private List<int> ShipDropIDList = new List<int>();

    // �l�������A�C�e����ID�i�[�p�ϐ�
    private int SPID;
    private int ShipID;
       

    void Start()
    {
        // ����������
        SPDropIDList.Clear();
        ShipDropIDList.Clear();

        foreach (DropSkill dropSkill in skillData.SkillList)
        {
            if(dropSkill.isGet == false)
            {
                // �����Ă��Ȃ�����U����ID���i�[
                SPDropIDList.Add(dropSkill.id);
            }
        }

        foreach (DropShip dropShip in shipData.SkillList)
        {
            if (dropShip.isGet == false)
            {
                // �����Ă��Ȃ������D��ID���i�[
                SPDropIDList.Add(dropShip.id);
            }
        }

    }

    private void SPGet()
    {
        SPID = Random.Range(1, SPDropIDList.Count);
        foreach (DropSkill dropSkill in skillData.SkillList)
        {
            if (dropSkill.id == SPID)
            {
                dropSkill.isGet = true;
            }
        }
    }

    private void ShipGet()
    {
        ShipID = Random.Range(1, ShipDropIDList.Count);
    }

}
