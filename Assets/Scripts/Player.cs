using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Min(0f)] [SerializeField] private float startingHp;
    [Min(1f)] [SerializeField] private float maxHp;
    [Min(0f)] [SerializeField] private int startingCorporateBucksAmount;
    [Min(0f)] [SerializeField] private int minNumCardsInDeck;
    [Min(0f)] [SerializeField] private int maxNumCardsInDeck;
    [SerializeField] private Card[] startingCards;
    [Min(0f)] [SerializeField] private int startingMana = 3;
    public string Name { get; set; }
    public float CurrentHp { get; set; }
    public float CurrentDefense { get; set; }
    public string HpDisplayText { get { return $"{CurrentHp}/{maxHp}"; } }
    public int CurrentCorporateBucksAmount { get; set; }
    public List<Card> ReserveCards { get; set; } = new List<Card>();
    public List<Card> CardsInDeck { get; set; } = new List<Card>();

    public int MinDeckCount { get { return minNumCardsInDeck; } }
    public int MaxDeckCount { get { return maxNumCardsInDeck; } }
    public string ManaDisplayText { get { return $"{RemainingPlayerMana}/{StartingMana}"; } }
    public int StartingMana { get { return startingMana; } }
    public int RemainingPlayerMana { get; private set; }

    public float BuffDamageAmount = 0;
    public float BuffDefenseAmount = 0 ;


    public void InitializePlayer()
    {
        ResetMana();

        Name = "New Guy"; // TODO: Ask user for name.
        CurrentHp = startingHp;
        CurrentCorporateBucksAmount = startingCorporateBucksAmount;
        CardsInDeck.AddRange(startingCards);

    }

    public void ResetMana()
    {
        // Shouldn't this be just Starting Mana?
        RemainingPlayerMana = GameInstance.Instance.MainPlayer.StartingMana;
    }

    public void ReduceMana(int amount)
    {
        if (RemainingPlayerMana >= amount)
        {
            RemainingPlayerMana -= amount;
        }
        else
        {
            Debug.LogError("Attempted to reduce player mana below 0.");
        }
    }

    public int GetMana()
    {
        return RemainingPlayerMana;
    }

    public void Damage(float damageValue)
    {
        float diff = damageValue - CurrentDefense;
        if (damageValue < 0)
        {
            CurrentDefense += diff;
        }
        else
        {
            CurrentDefense = 0;
            CurrentHp -= diff;
        }
    }
    public void ModifyDefense(float defenseValue)
    {
        CurrentDefense += defenseValue;
    }
    public void BuffDamage(float amount)
    {
        BuffDamageAmount += amount;
    }
    public void BuffDefense(float amount)
    {
        BuffDefenseAmount += amount;
    }
    public void ResetBuffs()
    {
        BuffDefenseAmount = 0;
        BuffDamageAmount = 0;
    }
}
