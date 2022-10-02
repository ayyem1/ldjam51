using UnityEngine;

public class Enemy
{
    public Entity Data { get; private set; }

    public float CurrentHp;
    public float CurrentDefense = 0;

    public float CurrentDamageValue;
    public float CurrentDefenseIncrementValue;
    public float DamageMultiplier;
    public float DefenseMultiplier;
    public int CurrentPatternIndex { get; private set; } = 0;


    public Enemy(Entity entity)
    {
        Data = entity;
    }

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
    public void BuffDamage()
    {
        CurrentDamageValue *= DamageMultiplier;
    }
    public void BuffDefense()
    {
        CurrentDefenseIncrementValue *= DefenseMultiplier;
    }
    public void Heal(float healValue)
    {
        CurrentHp += healValue;

        if (CurrentHp > Data.MaxHp)
        {
            CurrentHp = Data.MaxHp;
        }
    }
    public void UpdatePatternIndex()
    {
        CurrentPatternIndex++;
        if (CurrentPatternIndex > Data.movePattern.Count - 1)
        {
            CurrentPatternIndex = 0;
        }
    }
}
