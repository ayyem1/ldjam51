using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class DeckController: MonoBehaviour
{
    public const int PlayerHandSizeLimit = 4;

    [SerializeField] private CardUI cardPrefab;
    [SerializeField] private Transform cardContainerTransform;
    [SerializeField] private TextMeshProUGUI drawDeckCount;
    [SerializeField] private TextMeshProUGUI discardPileCount;
    private List<Card> currentDeck;
    public List<Card> CardsInHand = new List<Card>();
    public List<Card> CardsInDiscard = new List<Card>();

    private CardUI draggedCardUI;
    public void CreateHand(CardUI draggedCardUI)
    {
        foreach (Transform cardTransform in cardContainerTransform)
        {
            Destroy(cardTransform.gameObject);
        }

        currentDeck = new List<Card>();
        currentDeck.AddRange(ShuffleDeck(GameInstance.Instance.MainPlayer.CardsInDeck));

        this.draggedCardUI = draggedCardUI;
        for(int i = 0; i <= 3; i++)
        {
            CardUI card = Instantiate<CardUI>(cardPrefab, cardContainerTransform);
            Card nextCard = currentDeck.ElementAt(i);
            card.Initialize(nextCard, CardUI.CardType.Battle);
            var dragScript = card.gameObject.GetComponent<CardDrag>();
            dragScript.DraggedCardUI = draggedCardUI;

            CardsInHand.Add(nextCard);
            currentDeck.Remove(nextCard);
            UpdateDeckText();
        }
    }

    public void RefreshPlayerHand()
    {
        while (CardsInHand.Count < PlayerHandSizeLimit)
        {
            DrawCard();
        }
    }

    public void DrawCard()
    {
        if (currentDeck.Count <= 0)
        {
            ShuffleDiscardPile();
        }

        CardUI card = Instantiate<CardUI>(cardPrefab, cardContainerTransform);
        Card nextCard = currentDeck[0];
        card.Initialize(nextCard, CardUI.CardType.Battle);
        var dragScript = card.gameObject.GetComponent<CardDrag>();
        dragScript.DraggedCardUI = draggedCardUI;

        CardsInHand.Add(nextCard);
        currentDeck.Remove(nextCard);
    }

    public void UseCard(CardUI cardUI, Card card)
    {
        CardsInDiscard.Add(card);
        CardsInHand.Remove(card);
        Destroy(cardUI.gameObject);
    }

    public void ShuffleDiscardPile()
    {
        // If for whatever reason, we shuffle discard back into deck before deck is empty, this handles that.
        CardsInDiscard.AddRange(currentDeck);  
        currentDeck.AddRange(ShuffleDeck(CardsInDiscard));
        CardsInDiscard.Clear();
    }

    public List<Card> ShuffleDeck(List<Card> deck)
    {
        var rnd = new System.Random();
        List<Card> newDeck = deck.OrderBy(item => rnd.Next()).ToList();
        return newDeck;
    }

    public void UpdateDeckText()
    {
        drawDeckCount.text = "Draw Deck: " + currentDeck.Count;
        discardPileCount.text = "Discard Pile: " + CardsInDiscard.Count;
    }

}