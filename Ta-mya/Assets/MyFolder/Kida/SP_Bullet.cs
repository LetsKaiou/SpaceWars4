using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Bullet : MonoBehaviour
{
    public CreateShip sp_info;
    public Player playersc;

    // ���˂������U���̃I�u�W�F�N�g�i�[�p
    [SerializeField] private GameObject[] P_SPBullet;
    // �ǂ̓���U���������ꂽ������
    public int[] P_BulletNumber;
    private bool P_SetData = false;
    public bool[] SPCheck;
    // ����U���̃f�[�^�擾
    private int[] P_Attack = new int[100];            
    private int[] P_Range = new int[100];
    GameObject[] bullet = new GameObject[4];
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(P_SetData == false)
        {
            Setdata();
        }
        // �e�̈ړ�
        rb.velocity = transform.forward * 15;
        
    }

    public void CreatBullet(int bulletNum, Vector3 pos)
    {

        bullet[bulletNum] = Instantiate(P_SPBullet[bulletNum]) as GameObject;
        Debug.Log(bullet[bulletNum]);
        //Debug.Log(eul);
    }

    public void Destroy(int bulletNum)
    {
       
        Destroy(bullet[bulletNum-1], P_Range[bulletNum-1]);
    }

    public void SetTag(int setnum)
    {
        switch (setnum - 1)
        {
            case 0:
                playersc.Clones[setnum - 1].tag = "SP1";
                break;
            case 1:
                playersc.Clones[setnum - 1].tag = "SP2";
                break;
            case 2:
                playersc.Clones[setnum - 1].tag = "SP3";
                break;
            case 3:
                playersc.Clones[setnum - 1].tag = "SP4";
                break;
        }
        
    }

    public void Setdata()
    {
        for (int i = 0; i < 4; i++)
        {
            P_Attack[i] = sp_info.GetSPAttack(i);
            P_Range[i] = sp_info.GetSPRange(i);
        }
        P_SetData = true;
    }

}
