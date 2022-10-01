using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [SerializeField] private TMP_Text Title;
    [SerializeField] private Image Icon;
    [SerializeField] private TMP_Text Description;

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

    public void Clear()
    {
        Data = null;
        Title.gameObject.SetActive(false);
        Icon.gameObject.SetActive(false);
        Description.gameObject.SetActive(false);
    }
}
