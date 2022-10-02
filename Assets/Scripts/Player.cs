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

    public string Name { get; set; }
    public float CurrentHp { get; set; }
    public float CurrentDefense { get; set; }
    public string HpDisplayText { get { return $"{CurrentHp}/{maxHp}"; } }
    public int CurrentCorporateBucksAmount { get; set; }
    public List<Card> ReserveCards { get; set; } = new List<Card>();
    public List<Card> CardsInDeck { get; set; } = new List<Card>();

    public int MinDeckCount { get { return minNumCardsInDeck; } }
    public int MaxDeckCount { get { return maxNumCardsInDeck; } }
    public void InitializePlayer()
    {
        Name = "New Guy"; // TODO: Ask user for name.
        CurrentHp = startingHp;
        CurrentCorporateBucksAmount = startingCorporateBucksAmount;
        CardsInDeck.AddRange(startingCards);
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

}
