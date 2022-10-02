using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewEntity", menuName = "ScriptableObjects/Entity", order = 1)]

public class Entity : ScriptableObject
{
    public string Name;
    public string Dialog;
    public Sprite BattleSprite;
    [Min(0f)] public float StartingHp;
    [Min(1f)] public float MaxHp;

    public float StartingDefense;

    public float StartingDamageValue;
    public float StartingDefenseIncrementValue = 0;
    public float StartingAttackBuff;
    public float StartingDefenseBuff;
    public float StartingAttackDebuff;
    public float StartingDefenseDebuff;

    public enum ActionType
    {
        Attack,
        Defense,
        BuffAttack,
        BuffDefense,
        DebuffAttack,
        DebuffDefense
    }
    public List<ActionType> movePattern;
    public Entity[] minions;    
}
