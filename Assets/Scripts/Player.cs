using UnityEngine;

public class Player : MonoBehaviour
{
    public string Name;
    public float StartingHp;
    public float StartingCorporateBucks;
    public Card[] StartingCards;
    public float CurrentHp { get; set; }
    public float CorporateBucksAmount { get; set; }
    public Card[] OwnedCards { get; set; }
    public Card[] CardsInDeck { get; set; }
}
