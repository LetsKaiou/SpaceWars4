using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemyShip : MonoBehaviour
{
    // �G�D���i�[�p
    [SerializeField] private GameObject EnemyShip;
    private GameObject[] EnemyClones = new GameObject[10];
    [SerializeField] private Vector3[] s_EnemyCreatePos = new Vector3[4];
    [SerializeField] private Vector3[] b_EnemyCreatePos = new Vector3[10];
    GameObject[] enemyparent = new GameObject[2];
    private int Num;
    private int PosCount;
    private string[] TagName = new string[10];
    // ��}�b�v�����}�b�v�ǂ������I�΂�Ă邩���f
    [SerializeField] private bool isBigMap;
    // �G��͂̐���2���ǂ���
    [SerializeField] private bool isShip2;
    // �������鐔
    private int Counter;

    // Start is called before the first frame update
    void Start()
    {
        
        SetTag();   // string�Ƀ^�O�̖��O����

        enemyparent[0] = GameObject.FindGameObjectWithTag("Enemy");
        if(isShip2 == true)
        {
            enemyparent[1] = GameObject.FindGameObjectWithTag("Enemy2");

        }

        if (isBigMap == true)
        {
            Counter = 4;    // ��}�b�v�������琶������4�ɂ���
            BigMap();
        }
        else
        {
            Counter = 2;    // ���}�b�v�������琶������2�ɂ���
            Smallmap();     
        }

    }

    // ���}�b�v�p����
    public void Smallmap()
    {
        Debug.Log("InSmall");
        for (int i = 0; i < 2; i++) // 2����s���Ċ͑���2���
        {

            // Counter�̐������D�̐���
            for (int count = 0; count < Counter; count++)
            {
                Debug.Log(PosCount);
                EnemyClones[count] = Instantiate(EnemyShip, s_EnemyCreatePos[PosCount], transform.rotation);
                // �����蔻��擾�p�̃^�O�ƃX�e�[�^�X�𐶐����Ɋ��蓖�Ă�
                switch (count)
                {
                    case 0:
                        EnemyClones[count].tag = TagName[Num];
                        EnemyClones[count].transform.parent = enemyparent[i].transform;
                        PosCount++;
                        break;
                    case 1:
                        EnemyClones[count].tag = TagName[Num];
                        EnemyClones[count].transform.parent = enemyparent[i].transform;
                        PosCount++;
                        break;
                }
            }
        }
    }

    // ��}�b�v�p�̏���
    public void BigMap()
    {
        for (int i = 0; i < 2; i++)
        {
            // Counter�̐������D�̐���
            for (int count = 0; count < Counter; count++)
            {
                EnemyClones[count] = Instantiate(EnemyShip, b_EnemyCreatePos[count], Quaternion.identity);
                // �����蔻��擾�p�̃^�O�ƃX�e�[�^�X�𐶐����Ɋ��蓖�Ă�
                switch (count)
                {
                    case 0:
                        EnemyClones[count].tag = TagName[Num];
                        EnemyClones[count].transform.parent = enemyparent[i].transform;
                        break;
                    case 1:
                        EnemyClones[count].tag = TagName[Num];
                        EnemyClones[count].transform.parent = enemyparent[i].transform;
                        break;
                    case 2:
                        EnemyClones[count].tag = TagName[Num];
                        EnemyClones[count].transform.parent = enemyparent[i].transform;
                        break;
                    case 3:
                        EnemyClones[count].tag = TagName[Num];
                        EnemyClones[count].transform.parent = enemyparent[i].transform;
                        break;
                }
                Num++;
            }

        }
    }

    public void SetTag()
    {
        for (int i = 0; i < 10; i++)
        {
            int icount = i + 1;
            TagName[i] = "EnemyChild" + icount;
        }
    }

}