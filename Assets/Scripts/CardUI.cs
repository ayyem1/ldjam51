using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI cardValue;
    [SerializeField] private Image cardIcon;
    private Card refCard;

    public void InitializeCard(Card refCard)
    {
        this.refCard = refCard;
        cardName.text = refCard.Title;
        cardIcon.sprite = refCard.Icon;
    }

}
