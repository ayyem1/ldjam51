using UnityEngine;
using UnityEngine.UI;

public class Interactible : MonoBehaviour
{
    [SerializeField] private InteractionDialog interactionDialog;
    public Image Icon;
    public Button InteractibleButton;

    public enum InteractibleType
    {
        HealingItem,
        Treasure,
        Entity
    }

    public enum State
    {
        NotUnlocked,
        Unlocked,
        //Started,
        Completed
    }

    public ScriptableObject referenceInteraction;
    public InteractibleType TypeOfInteractible;

    public void OnInteract()
    {
        interactionDialog.Initialize(this);
        interactionDialog.gameObject.SetActive(true);
    }
}
