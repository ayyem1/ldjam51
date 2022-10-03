using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class InteractionDialog : MonoBehaviour
{
    [SerializeField] private TMP_Text Title;
    [SerializeField] private TMP_Text Description;
    [SerializeField] private Image Icon;
    [SerializeField] private Button ActionButton;
    [SerializeField] private TMP_Text ButtonText;

    private Interactible refInteractble;
    public void Initialize(Interactible interactible)
    {
        refInteractble = interactible;
        if (interactible.TypeOfInteractible == Interactible.InteractibleType.HealingItem)
        {
            Title.text = interactible.HealingItem.Name;
            Description.text = interactible.HealingItem.Description;
            if (interactible.HealingItem.HealingPrice > 0)
            {
                Description.text = $"{Description.text}\n\nCost: {interactible.HealingItem.HealingPrice} Corporate Bucks";
            }
            Icon.sprite = interactible.HealingItem.Icon;
            if (interactible.HealingItem.HealingPrice <= 0)
            {
                ButtonText.text = "Collect";
            }
            else
            {
                if (GameInstance.Instance.MainPlayer.CurrentCorporateBucksAmount < interactible.HealingItem.HealingPrice)
                {
                    ButtonText.text = "Not Enough Bucks";
                    ActionButton.interactable = false;
                }
                else
                {
                    ButtonText.text = $"Purchase ({interactible.HealingItem.HealingPrice})";
                    ActionButton.interactable = true;
                }
            }
        }
        else if (interactible.TypeOfInteractible == Interactible.InteractibleType.Treasure)
        {
            Title.text = interactible.TreasureItem.Name;
            Description.text = $"{interactible.TreasureItem.Description}\n\nRewards:\nUnlocked A New Card!\nEarned {interactible.TreasureItem.GrantedCorporateBucks} Corporate Bucks";
            Icon.sprite = interactible.TreasureItem.Icon;
            ButtonText.text = "Collect";
            ActionButton.interactable = true;
        }
        else
        {
            Title.text = interactible.EntityItem.Name;
            Description.text = interactible.EntityItem.StartingDialog;
            Icon.sprite = interactible.EntityItem.BattleSprite;
            ButtonText.text = "Ready";
            ActionButton.interactable = true;
        }
    }

    public void OnButtonPress()
    {
        // TODO: Mark entities as interacted with so we don't allow redos.
        if (refInteractble.TypeOfInteractible == Interactible.InteractibleType.Entity)
        {
            GameInstance.Instance.SelectedEntity = refInteractble.EntityItem;
            GameInstance.Instance.Interactions.Add(refInteractble.gameObject.name);
            SceneManager.LoadScene("BattleScene");
        }
        else if (refInteractble.TypeOfInteractible == Interactible.InteractibleType.HealingItem)
        {
            var currentCorporateBucks = GameInstance.Instance.MainPlayer.CurrentCorporateBucksAmount;
            var currentHP = GameInstance.Instance.MainPlayer.CurrentHp;
            if (currentCorporateBucks >= refInteractble.HealingItem.HealingPrice && currentHP < GameInstance.Instance.MainPlayer.MaxHP)
            {
                GameInstance.Instance.MainPlayer.ModifyCorporateBucksAmount(-refInteractble.HealingItem.HealingPrice);
                GameInstance.Instance.MainPlayer.Heal(refInteractble.HealingItem.HealingAmount);
                if (refInteractble.HealingItem.IsSingleUse)
                {
                    GameInstance.Instance.Interactions.Add(refInteractble.gameObject.name);
                }
                gameObject.SetActive(false);
            }
        }
        else
        {
            GameInstance.Instance.MainPlayer.ModifyCorporateBucksAmount(refInteractble.TreasureItem.GrantedCorporateBucks);
            foreach (var card in refInteractble.TreasureItem.GrantedCards)
            {
                if (card != null)
                {
                    GameInstance.Instance.MainPlayer.AddCard(card);
                }
            }
            GameInstance.Instance.Interactions.Add(refInteractble.gameObject.name);
            gameObject.SetActive(false);
        }

    }

    public void OnClose()
    {
        gameObject.SetActive(false);
    }
}
