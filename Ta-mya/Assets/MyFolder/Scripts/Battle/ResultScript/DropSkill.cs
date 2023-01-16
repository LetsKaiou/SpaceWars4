using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class DropSkill 
{
    public int id;
    public string Name;
    public enum Type
    {
        Attack,
        Skill,
    }
    public Type SkillType;
    public Sprite Image;
    public bool isGet;
    public GameObject EffectObj;

}
