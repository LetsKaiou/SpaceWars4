using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBreaker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �G�t�F�N�g�����������2�b��ɃI�u�W�F�N�g���폜����
        Invoke("BreakEffect", 2.0f);
    }
    // �G�t�F�N�g���폜����
    void BreakEffect()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
