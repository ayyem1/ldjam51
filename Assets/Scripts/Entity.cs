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
    public float CurrentDefense = 0;
    public float StartingDefense;

    // Moves
    public float StartingDamageValue;
    public float StartingDefenseIncrementValue = 0;
    public float CurrentDamageValue;
    public float CurrentDefenseIncrementValue;
    public float DamageMultiplier;
    public float DefenseMultiplier;
    public Buff[] Buffs;

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

    public int CurrentPatternIndex { get; private set; } = 0;

    public void Damage(float damageValue)
    {
        float diff = damageValue - CurrentDefense;
        if (damageValue < 0)
        {
            ModifyDefense(diff);
        }
        else
        {
            ModifyDefense(-CurrentDefense);
            CurrentHp -= diff;
        }
    }

    public void ModifyDefense(float defenseValue)
    {
        CurrentDefense += defenseValue;
    }
    public void buffDamage()
    {
        CurrentDamageValue *= DamageMultiplier;
    }
    public void buffDefense()
    {
        CurrentDefenseIncrementValue *= DefenseMultiplier;
    }
    public void Heal(float healValue)
    {
        CurrentHp += healValue;

        if(CurrentHp > MaxHp)
        {
            CurrentHp = MaxHp;
        }
    }
    public void UpdatePatternIndex()
    {
        CurrentPatternIndex++;
        if (CurrentPatternIndex > movePattern.Count - 1)
        {
            CurrentPatternIndex = 0;
        }
    }
    
}
