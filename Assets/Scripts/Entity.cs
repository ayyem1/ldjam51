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
    public float CurrentHp;

    // Moves
    public float AttackDamage;
    public float Defense;
    public Buff[] Buffs;
    // TODO: Move Pattern

    public enum ActionType
    {
        Attack,
        Defense,
        Buff
    }
    public List<ActionType> movePattern;
    public Entity[] minions;

    public void Damage(int damageValue)
    {
        CurrentHp -= damageValue;
    }

    public void Heal(int healValue)
    {
        CurrentHp += healValue;

        if(CurrentHp > MaxHp)
        {
            CurrentHp = MaxHp;
        }
    }
    
}
