using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Min(0f)] [SerializeField] private float startingHp;
    [Min(1f)] [SerializeField] private float maxHp;
    [Min(0f)] [SerializeField] private int startingCorporateBucksAmount;
    [SerializeField] private Card[] startingCards;

    public string Name { get; set; }
    public float CurrentHp { get; set; }
    public string HpDisplayText { get { return $"{CurrentHp}/{maxHp}"; } }
    public int CurrentCorporateBucksAmount { get; set; }
    public List<Card> ReserveCards { get; set; } = new List<Card>();
    public List<Card> CardsInDeck { get; set; } = new List<Card>();

    public void InitializePlayer()
    {
        Name = "New Guy"; // TODO: Ask user for name.
        CurrentHp = startingHp;
        CurrentCorporateBucksAmount = startingCorporateBucksAmount;
        CardsInDeck.AddRange(startingCards);
    }
}
