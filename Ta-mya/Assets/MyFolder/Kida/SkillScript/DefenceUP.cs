using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceUP : MonoBehaviour
{
    // �㏸��
    [SerializeField] private int DefencePoint;
    // ���ʎ���
    [SerializeField] private float EffectTime;
    // �o�ߎ��Ԋi�[
    private float TimeCount = 0f;
    private Player py;

    // �C���X�^���X
    public static DefenceUP instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        py = GameObject.Find("Yamato").GetComponent<Player>();
        P_DefenceUp();
    }

    void Update()
    {
        // ���ʎ��Ԍv������
        TimeCount += Time.deltaTime;
        if (TimeCount > EffectTime)
        {
            // ���ʎ��ԉ߂�����߂�
            Player.instance.Defence -= DefencePoint;
            Destroy(this.gameObject);
        }
    }

    public void P_DefenceUp()
    {
        Player.instance.Defence += DefencePoint;
    }

}
