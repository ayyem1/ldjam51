using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI defense;
    [SerializeField] private TextMeshProUGUI drawDeck;
    [SerializeField] private TextMeshProUGUI discardPile;

    private void Start()
    {
        healthText.text = "Health: " + GameInstance.Instance.MainPlayer.HpDisplayText;
        drawDeck.text = "Draw Deck: " + GameInstance.Instance.MainPlayer.CardsInDeck.Count;
    }

}
