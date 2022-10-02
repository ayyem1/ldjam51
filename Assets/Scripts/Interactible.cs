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

    [SerializeField] private HealingItem healingItem;
    [SerializeField] private Treasure treasureItem;
    [SerializeField] private Entity entity;

    public InteractibleType TypeOfInteractible;

    public void OnInteract()
    {
        interactionDialog.Initialize();
        interactionDialog.gameObject.SetActive(true);
    }
}
