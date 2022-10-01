using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewEntity", menuName = "ScriptableObjects/Entity", order = 1)]

public class Entity : ScriptableObject
{
    public string Name;
    public string Dialog;
    public Sprite battleSprite;
    [Min(0f)] public float StartingHp;
    [Min(1f)] public float MaxHp;

    // Moves
    public float AttackDamage;
    public float Defense;
    public Buff[] Buffs;
    // TODO: Move Pattern

    public List<string> movePattern;
    public int[] movePatternValues;
    public Entity[] minions;
    
}
