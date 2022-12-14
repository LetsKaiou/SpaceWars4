using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SkillDatabase : ScriptableObject
{
    public List<DropSkill> SkillList = new List<DropSkill>(); 
}
