using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MainShipData
{
    // �ۑ��������
    // ���@�̃X�e�[�^�X(HP,CT,����U���̍U����)�A�����̃f�[�^(�e�J���|�C���g�̗ݐϒl)�A�����Ă������U���E�����̐퓬�@

    
    public int HP = 60; // ���C���͂�HP(���v�l��HP�𑫂��Z�����l������)
    public float CT;    // CT�̒Z�k����鎞��(���v�l�Ɠ����l������)
    public int ATK;     // ����U���̍U���́E���ʗ�(���v�l�Ɠ����l������)

    // ���ꂼ��̊J���|�C���g�̍��v�l
    public int IndSum;
    public int ComSum;
    public float AgrSum;

}
