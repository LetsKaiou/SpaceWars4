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
    public int[] P_Attack = new int[100];            
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

        Debug.Log(P_Attack[0]);
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


    public void Setdata(int num, int attack)
    {
        P_Attack[num] = sp_info.GetSPAttack(attack);
        Debug.Log(P_Attack[num]);
    }

}
