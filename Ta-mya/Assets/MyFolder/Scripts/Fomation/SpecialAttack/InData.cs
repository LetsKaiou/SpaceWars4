using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InData : MonoBehaviour
{
    private SkillDatabase SkillData;
    private Special_info specialInfo;

    // Start is called before the first frame update
    void Start()
    {
        specialInfo = new Special_info();
        specialInfo.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
