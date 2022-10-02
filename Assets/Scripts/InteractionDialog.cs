using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InteractionDialog : MonoBehaviour
{
    [SerializeField] private TMP_Text Title;
    [SerializeField] private TMP_Text Description;
    [SerializeField] private TMP_Text coinReawrdAmount;
    [SerializeField] private Image rewardIcon;
    [SerializeField] private Image rewardName;
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
            Icon.sprite = interactible.HealingItem.Icon;
            if (interactible.HealingItem.HealingPrice <= 0)
            {
                ButtonText.text = "Collect";
            }
            else
            {
                ButtonText.text = $"Purchase ({interactible.HealingItem.HealingPrice})";
            }
        }
        else if (interactible.TypeOfInteractible == Interactible.InteractibleType.Treasure)
        {
            Title.text = interactible.TreasureItem.Name;
            Description.text = interactible.TreasureItem.Description;
            Icon.sprite = interactible.TreasureItem.Icon;
            ButtonText.text = "Collect";
        }
        else
        {
            Title.text = interactible.EntityItem.Name;
            Description.text = interactible.EntityItem.StartingDialog;
            Icon.sprite = interactible.EntityItem.BattleSprite;
            ButtonText.text = "Ready";
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
                GameInstance.Instance.MainPlayer.ModifyCorporateBucksAmount(refInteractble.HealingItem.HealingPrice);
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
