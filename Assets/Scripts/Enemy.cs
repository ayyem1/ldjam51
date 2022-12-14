public class Enemy
{
    public Entity Data { get; private set; }

    public float CurrentHp;
    public float CurrentDefense = 0;

    public float CurrentDamageValue;
    public float CurrentDefenseIncrementValue;
    public float DamageBuffAmount;
    public float DefenseBuffAmount;
    public float DebuffDamageAmount;
    public float DebuffDefenseAmount;
    public int CurrentPatternIndex { get; private set; } = 0;


    public Enemy(Entity entity)
    {
        Data = entity;
    }

    public void Damage(float damageValue)
    {
        float diff = damageValue - CurrentDefense;
        if (diff < 0)
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
    public void ResetDefense()
    {
        CurrentDefense = 0;
    }
    public void BuffDamage(float amount)
    {
        CurrentDamageValue += amount;
    }
    public void BuffDefense(float amount)
    {
        CurrentDefenseIncrementValue += amount;
    }
    public void ResetBuffs()
    {
        CurrentDamageValue = Data.StartingDamageValue;
        CurrentDefenseIncrementValue = Data.StartingDefenseIncrementValue;
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
