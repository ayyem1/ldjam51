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
    [SerializeField] private Image ActionTypeIcon;

    public Image Background;
    public Image Border;

    public Card Data { get; set; }
    public CardType TypeOfCard { get; set; }

    [SerializeField] private Sprite[] actionTypeSpriteArray;
    private Sprite sprite;
    public bool IsEmpty => Data == null;

    public void Initialize(Card data, CardType cardType)
    {
        Data = data;
        TypeOfCard = cardType;

        Title.gameObject.SetActive(!IsEmpty);
        Icon.gameObject.SetActive(!IsEmpty);
        Description.gameObject.SetActive(!IsEmpty);

        switch(Data.cardActionType)
        {
            case Card.ActionType.Attack:
                sprite = actionTypeSpriteArray[0];
                break;
            case Card.ActionType.Defense:
                sprite = actionTypeSpriteArray[1];
                break;
            case Card.ActionType.BuffAttack:
                sprite = actionTypeSpriteArray[2];
                break;
            case Card.ActionType.BuffDefense:
                sprite = actionTypeSpriteArray[3];
                break;
            case Card.ActionType.DebuffAttack:
                sprite = actionTypeSpriteArray[4];
                break;
            case Card.ActionType.DebuffDefense:
                sprite = actionTypeSpriteArray[5];
                break;
            default:
                Debug.LogError("Wrong Action Type");
                break;
        }

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
                Description.text = Data.cardValue.ToString();
                ActionTypeIcon.sprite = sprite;
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
