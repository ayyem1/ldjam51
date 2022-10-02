using UnityEngine;

public class Interactible : MonoBehaviour
{
    [SerializeField] private InteractionDialog interactionDialog;
    public enum InteractibleType
    {
        HealingItem,
        Treasure,
        Entity
    }

    public HealingItem HealingItem;
    public Treasure TreasureItem;
    public Entity EntityItem;

    public InteractibleType TypeOfInteractible;

    public void OnInteract()
    {
        interactionDialog.Initialize(this);
        interactionDialog.gameObject.SetActive(true);
    }
}
