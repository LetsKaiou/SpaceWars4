using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DropSkill 
{
    public int id;
    public enum Type
    {
        Attack,
        Skill,
    }
    public Type SkillType;
    public bool isGet;

    public int GetID()
    {
        return id;
    }

    public Type GetType()
    {
        return SkillType;
    }



}
