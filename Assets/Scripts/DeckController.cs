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
        var rnd = new System.Random();
        var randomizedDeck = startingDeck.OrderBy(item => rnd.Next()).ToList();

        for(int i = 0; i <= 3; i++)
        {
            CardUI card = Instantiate<CardUI>(cardPrefab, cardContainerTransform);
            Card nextCard = randomizedDeck.ElementAt(i);
            card.InitializeCardForBattle(nextCard);
        }
        
    }

}