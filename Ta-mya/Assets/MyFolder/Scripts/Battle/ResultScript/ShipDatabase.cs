using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShipDatabase : ScriptableObject
{
    public List<DropShip> SkillList = new List<DropShip>();
}
