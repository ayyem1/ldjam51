using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        //GameInstance.Instance.SetInteractionToStarted(interactible.referenceInteraction.name);
        refInteractble = interactible;
        if (interactible.TypeOfInteractible == Interactible.InteractibleType.HealingItem)
        {
            HealingItem healingItem = (HealingItem)interactible.referenceInteraction;
            UpdateUnlockedInteractions(); // Healing items unlock next item as soon as you click on them. You don't have to heal.
            Title.text = healingItem.Name;

            if (healingItem.HealingPrice > 0)
            {
                Description.text = $"{healingItem.Description}\n\nCost: {healingItem.HealingPrice} Corporate Bucks";
            }
            else
            {
                Description.text = healingItem.Description;
            }

            Icon.sprite = healingItem.Icon;

            if (GameInstance.Instance.MainPlayer.CurrentHp == GameInstance.Instance.MainPlayer.MaxHP)
            {
                ButtonText.text = $"At Full Health";
                ActionButton.interactable = false;
            }
            else if (healingItem.HealingPrice <= 0)
            {
                ButtonText.text = "Collect";
                ActionButton.interactable = true;
            }
            else
            {
                if (GameInstance.Instance.MainPlayer.CurrentCorporateBucksAmount < healingItem.HealingPrice)
                {
                    ButtonText.text = "Not Enough Bucks";
                    ActionButton.interactable = false;
                }
                else
                {
                    ButtonText.text = $"Purchase ({healingItem.HealingPrice})";
                    ActionButton.interactable = true;
                }
            }
        }
        else if (interactible.TypeOfInteractible == Interactible.InteractibleType.Treasure)
        {
            UpdateUnlockedInteractions();// Treasure items unlock next item as soon as you click on them. You don't have to collect.
            Treasure treasureItem = (Treasure)interactible.referenceInteraction;

            Title.text = treasureItem.Name;
            Description.text = $"{treasureItem.Description}\n\nRewards:\nUnlocked A New Card!\nEarned {treasureItem.GrantedCorporateBucks} Corporate Bucks";
            Icon.sprite = treasureItem.Icon;
            ButtonText.text = "Collect";
            ActionButton.interactable = true;
        }
        else
        {
            Entity entityItem = (Entity)interactible.referenceInteraction;

            Title.text = entityItem.Name;
            Description.text = entityItem.StartingDialog;
            Icon.sprite = entityItem.EntitySprite;
            ButtonText.text = "Ready";
            ActionButton.interactable = true;
        }
    }

    public void OnButtonPress()
    {
        if (refInteractble.TypeOfInteractible == Interactible.InteractibleType.Entity)
        {
            var entity = (Entity)refInteractble.referenceInteraction;
            GameInstance.Instance.SetInteractionToCompleted(entity.name);
            UpdateUnlockedInteractions();
            GameInstance.Instance.StartBattle(entity);
        }
        else if (refInteractble.TypeOfInteractible == Interactible.InteractibleType.HealingItem)
        {
            var healingItem = (HealingItem)refInteractble.referenceInteraction;
            var currentCorporateBucks = GameInstance.Instance.MainPlayer.CurrentCorporateBucksAmount;
            var currentHP = GameInstance.Instance.MainPlayer.CurrentHp;
            if (currentCorporateBucks >= healingItem.HealingPrice && currentHP < GameInstance.Instance.MainPlayer.MaxHP)
            {
                GameInstance.Instance.MainPlayer.ModifyCorporateBucksAmount(-healingItem.HealingPrice);
                GameInstance.Instance.MainPlayer.Heal(healingItem.HealingAmount);
                GameInstance.Instance.SetInteractionToCompleted(healingItem.name);
                //UpdateUnlockedInteractions();
                gameObject.SetActive(false);
            }
        }
        else
        {
            var treasureItem = (Treasure)refInteractble.referenceInteraction;
            GameInstance.Instance.MainPlayer.ModifyCorporateBucksAmount(treasureItem.GrantedCorporateBucks);
            foreach (var card in treasureItem.GrantedCards)
            {
                if (card != null)
                {
                    GameInstance.Instance.MainPlayer.AddCard(card);
                }
            }
            GameInstance.Instance.SetInteractionToCompleted(treasureItem.name);
            //UpdateUnlockedInteractions();
            gameObject.SetActive(false);
        }

    }

    private void UpdateUnlockedInteractions()
    {
        if (refInteractble.TypeOfInteractible == Interactible.InteractibleType.Entity)
        {
            var entity = (Entity)refInteractble.referenceInteraction;
            foreach (var unlockedInteraction in entity.UnlockedInteractions)
            {
                GameInstance.Instance.SetInteractionToUnlocked(unlockedInteraction.name);
            }
        }
        else if (refInteractble.TypeOfInteractible == Interactible.InteractibleType.HealingItem)
        {
            var healingItem = (HealingItem)refInteractble.referenceInteraction;
            foreach (var unlockedInteraction in healingItem.UnlockedInteractions)
            {
                GameInstance.Instance.SetInteractionToUnlocked(unlockedInteraction.name);
            }
        }
        else
        {
            var treasureItem = (Treasure)refInteractble.referenceInteraction;
            foreach (var unlockedInteraction in treasureItem.UnlockedInteractions)
            {
                GameInstance.Instance.SetInteractionToUnlocked(unlockedInteraction.name);
            }
        }
    }

    public void OnClose()
    {
        gameObject.SetActive(false);
    }
}
