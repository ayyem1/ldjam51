using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{
    public enum CardType
    {
        Deck,
        Battle
    }

    [SerializeField] private TMP_Text Title;
    [SerializeField] private Image Icon;
    [SerializeField] private TMP_Text Description;

    public Image Background;
    public Image Border;

    public Card Data { get; set; }
    public CardType TypeOfCard { get; set; }

    public bool IsEmpty => Data == null;

    public void Initialize(Card data, CardType cardType)
    {
        Data = data;
        TypeOfCard = cardType;

        Title.gameObject.SetActive(!IsEmpty);
        Icon.gameObject.SetActive(!IsEmpty);
        Description.gameObject.SetActive(!IsEmpty);

        if (!IsEmpty)
        {
            Title.text = data.Title;
            Icon.sprite = data.Icon;
            if (cardType == CardType.Deck)
            {
                Description.text = data.Description;
            }
            else
            {
                Description.text = Data.cardActionType.ToString() + ": " + Data.cardValue;
            }
        }
    }

    public void Clear()
    {
        Data = null;
        Title.gameObject.SetActive(false);
        Icon.gameObject.SetActive(false);
        Description.gameObject.SetActive(false);
    }
}
