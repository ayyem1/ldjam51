using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class DeckController: MonoBehaviour
{
    [SerializeField] private CardUI cardPrefab;
    [SerializeField] private Transform cardContainerTransform;
    [SerializeField] private TextMeshProUGUI drawDeckCount;
    [SerializeField] private TextMeshProUGUI discardPileCount;
    private List<Card> currentDeck;
    public List<Card> cardsInHand = new List<Card>();
    public List<Card> cardsInDiscard = new List<Card>();

    private void Start()
    {
        CreateHand();
    }
    private void CreateHand()
    {
        foreach (Transform cardTransform in cardContainerTransform)
        {
            Destroy(cardTransform.gameObject);
        }
        
        List<Card> startingDeck = GameInstance.Instance.MainPlayer.CardsInDeck;
        currentDeck = ShuffleDeck(startingDeck);

        for(int i = 0; i <= 3; i++)
        {
            CardUI card = Instantiate<CardUI>(cardPrefab, cardContainerTransform);
            Card nextCard = currentDeck.ElementAt(i);
            card.InitializeCardForBattle(nextCard);
            cardsInHand.Add(nextCard);
            currentDeck.Remove(nextCard);
            UpdateDeckText();
        }
    }

    public void DrawCard()
    {
        CardUI card = Instantiate<CardUI>(cardPrefab, cardContainerTransform);
        Card nextCard = currentDeck.ElementAt(0);
        card.InitializeCardForBattle(nextCard);
        cardsInHand.Add(nextCard);
        currentDeck.Remove(nextCard);
    }

    public void UseCard(CardUI cardUI, Card card)
    {
        cardsInDiscard.Add(card);
        cardsInHand.Remove(card);
        Destroy(cardUI.gameObject);
    }

    public void ShuffleDiscardPile()
    {
        currentDeck.AddRange(cardsInDiscard);
        currentDeck = ShuffleDeck(currentDeck);
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
        discardPileCount.text = "Discard Pile: " + cardsInDiscard.Count;
    }

}