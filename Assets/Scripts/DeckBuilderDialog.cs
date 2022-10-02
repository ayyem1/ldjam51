using UnityEngine;

public class DeckBuilderDialog : MonoBehaviour
{
    [SerializeField] private CardUI CardPrefab;
    [SerializeField] private Transform deckContentRoot;
    [SerializeField] private Transform reserveContentRoot;
    [SerializeField] private CardUI DraggedCardUI;

    private void OnEnable()
    {
        var playerCards = GameInstance.Instance.MainPlayer.CardsInDeck;
        foreach(var card in playerCards)
        {
            var cardUI = Instantiate<CardUI>(CardPrefab, deckContentRoot);
            cardUI.Initialize(card, CardUI.CardType.Deck);
            var dragScript = cardUI.gameObject.GetComponent<CardDrag>();
            dragScript.DraggedCardUI = DraggedCardUI;
        }

        var reserveCards = GameInstance.Instance.MainPlayer.ReserveCards;
        foreach (var card in reserveCards)
        {
            var cardUI = Instantiate<CardUI>(CardPrefab, reserveContentRoot);
            cardUI.Initialize(card, CardUI.CardType.Deck);
            var dragScript = cardUI.gameObject.GetComponent<CardDrag>();
            dragScript.DraggedCardUI = DraggedCardUI;
        }
    }

    private void OnDisable()
    {
        foreach(Transform child in deckContentRoot.transform)
        {
            Destroy(child.gameObject);
        }

        foreach(Transform child in reserveContentRoot.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void AddNewCardDataToContent(CardDrop.DropLocation dropLocation, Card cardData)
    {
        if (dropLocation == CardDrop.DropLocation.Deck)
        {
            var cardUI = Instantiate<CardUI>(CardPrefab, deckContentRoot);
            cardUI.Initialize(cardData, CardUI.CardType.Deck);
            var dragScript = cardUI.gameObject.GetComponent<CardDrag>();
            dragScript.DraggedCardUI = DraggedCardUI;
        }
        else
        {
            var cardUI = Instantiate<CardUI>(CardPrefab, reserveContentRoot);
            cardUI.Initialize(cardData, CardUI.CardType.Deck);
            var dragScript = cardUI.gameObject.GetComponent<CardDrag>();
            dragScript.DraggedCardUI = DraggedCardUI;
        }
    }

    public void OnBackButtonPressed()
    {
        gameObject.SetActive(false);
    }
}
