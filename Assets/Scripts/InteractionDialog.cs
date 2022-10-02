using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InteractionDialog : MonoBehaviour
{
    [SerializeField] private TMP_Text Title;
    [SerializeField] private TMP_Text Description;
    [SerializeField] private Image Icon;
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
        if (refInteractble.TypeOfInteractible == Interactible.InteractibleType.Entity)
        {
            refInteractble.WasInteractedWith = true;
            GameInstance.Instance.SelectedEntity = refInteractble.EntityItem;
            // Mark entity as played.
            SceneManager.LoadScene("BattleScene");

        }
        else if (refInteractble.TypeOfInteractible == Interactible.InteractibleType.HealingItem)
        {
            refInteractble.WasInteractedWith = true;
        }
        else
        {
            refInteractble.WasInteractedWith = true;
        }

    }

    public void OnClose()
    {
        gameObject.SetActive(false);
    }
}
