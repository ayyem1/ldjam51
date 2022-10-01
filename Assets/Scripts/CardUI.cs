using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{
    [SerializeField] private TMP_Text Title;
    [SerializeField] private Image Icon;
    [SerializeField] private TMP_Text Description;
    [SerializeField] private TextMeshProUGUI battleScene_cardName;
    [SerializeField] private TextMeshProUGUI battleScene_cardValue;
    [SerializeField] private Image battleScene_cardIcon;
    private Card refCard;

    public Card Data { get; set; }
    public bool IsEmpty => Data == null;

    public void Initialize(Card data)
    {
        Data = data;
        Title.gameObject.SetActive(!IsEmpty);
        Icon.gameObject.SetActive(!IsEmpty);
        Description.gameObject.SetActive(!IsEmpty);

        if (!IsEmpty)
        {
            Title.text = data.Title;
            Icon.sprite = data.Icon;
            Description.text = data.Description;
        }
    }

    public void InitializeCard(Card refCard)
    {
        this.refCard = refCard;
        battleScene_cardName.text = refCard.Title;
        battleScene_cardIcon.sprite = refCard.Icon;
    }

    public void Clear()
    {
        Data = null;
        Title.gameObject.SetActive(false);
        Icon.gameObject.SetActive(false);
        Description.gameObject.SetActive(false);
    }
}
