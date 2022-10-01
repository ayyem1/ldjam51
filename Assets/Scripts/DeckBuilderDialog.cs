using UnityEngine;

public class DeckBuilderDialog : MonoBehaviour
{
    [SerializeField] private CardUI[] CardsInDeck;
    [SerializeField] private CardUI[] CardsInReserve;

    private void Start()
    {
        var playerCards = GameInstance.Instance.MainPlayer.CardsInDeck;
        var i = 0;
        for (; i < playerCards.Count; i++)
        {
            CardsInDeck[i].InitializeForDeckBuilder(playerCards[i]);
        }
        for (; i < CardsInDeck.Length; i++)
        {
            CardsInDeck[i].InitializeForDeckBuilder(null);
        }

        var reserveCards = GameInstance.Instance.MainPlayer.ReserveCards;
        i = 0;
        for (; i < reserveCards.Count; i++)
        {
            CardsInReserve[i].InitializeForDeckBuilder(reserveCards[i]);
        }
        for (; i < CardsInReserve.Length; i++)
        {
            CardsInReserve[i].InitializeForDeckBuilder(null);
        }
    }
    public void OnBackButtonPressed()
    {
        gameObject.SetActive(false);
    }
}
