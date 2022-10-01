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
            CardsInDeck[i].Initialize(playerCards[i]);
        }
        for (; i < CardsInDeck.Length; i++)
        {
            CardsInDeck[i].Initialize(null);
        }

        var reserveCards = GameInstance.Instance.MainPlayer.ReserveCards;
        i = 0;
        for (; i < reserveCards.Count; i++)
        {
            CardsInReserve[i].Initialize(reserveCards[i]);
        }
        for (; i < CardsInReserve.Length; i++)
        {
            CardsInReserve[i].Initialize(null);
        }
    }
    public void OnBackButtonPressed()
    {
        gameObject.SetActive(false);
    }
}
