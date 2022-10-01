using UnityEngine;

public class DeckBuilderDialog : MonoBehaviour
{
    [SerializeField] private CardUI CardPrefab;
    [SerializeField] private Transform deckContentRoot;
    [SerializeField] private Transform reserveContentRoot;

    private void Start()
    {
        var playerCards = GameInstance.Instance.MainPlayer.CardsInDeck;
        foreach(var card in playerCards)
        {
            var cardUI = Instantiate<CardUI>(CardPrefab, deckContentRoot);
            cardUI.InitializeForDeckBuilder(card);
        }

        var reserveCards = GameInstance.Instance.MainPlayer.ReserveCards;
        foreach (var card in reserveCards)
        {
            var cardUI = Instantiate<CardUI>(CardPrefab, deckContentRoot);
            cardUI.InitializeForDeckBuilder(card);
        }
    }

    public void OnBackButtonPressed()
    {
        gameObject.SetActive(false);
    }
}
