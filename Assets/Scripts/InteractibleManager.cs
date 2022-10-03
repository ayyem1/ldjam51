using UnityEngine;

public class InteractibleManager : MonoBehaviour
{

    private void Start()
    {
        foreach (Transform child in transform)
        {
            var interactible = child.GetComponent<Interactible>();
            GameInstance.Instance.InitializeStateInteraction(interactible);
        }
    }
    private void Update()
    {
        foreach (Transform child in transform)
        {
            var interactible = child.GetComponent<Interactible>();
            var state = GameInstance.Instance.GetState(interactible.referenceInteraction.name);

            if (state == Interactible.State.NotUnlocked)
            {
                interactible.Icon.color = Color.black;
                interactible.InteractibleButton.interactable = false;
            }
            else if (state == Interactible.State.Unlocked)
            {
                interactible.Icon.color = Color.white;
                interactible.InteractibleButton.interactable = true;
            }
            else if (state == Interactible.State.Started)
            {
                var newColor = interactible.Icon.color;
                newColor.a = 145;
                interactible.Icon.color = newColor;
                interactible.InteractibleButton.interactable = true;
            }
            else if (state == Interactible.State.Completed)
            {
                var newColor = interactible.Icon.color;
                newColor.a = 145;
                interactible.Icon.color = newColor;
                interactible.InteractibleButton.interactable = false;
            }
        }
    }
    //void Update()
    //{
    //    foreach(Transform child in transform)
    //    {
    //        var interactible = child.GetComponent<Interactible>();
    //        if (interactible.TypeOfInteractible == Interactible.InteractibleType.Entity)
    //        {
    //            if (GameInstance.Instance.CompletedInteractions.Contains(interactible.EntityItem.name)
    //                || GameInstance.Instance.StartedInteractions.Contains(interactible.EntityItem.name))
    //            {
    //                var newColor = interactible.Icon.color;
    //                newColor.a = 145;
    //                interactible.Icon.color = newColor;
    //                interactible.InteractibleButton.interactable = true;
    //            }
    //            else if (GameInstance.Instance.UnlockedInteractions.Contains(interactible.EntityItem.name))
    //            {
    //                interactible.Icon.color = Color.white;
    //                interactible.InteractibleButton.interactable = true;
    //            }
    //            else
    //            {
    //                interactible.Icon.color = Color.black;
    //                interactible.InteractibleButton.interactable = false;
    //            }
    //        }
    //        else if (interactible.TypeOfInteractible == Interactible.InteractibleType.Treasure)
    //        {
    //            if (GameInstance.Instance.CompletedInteractions.Contains(interactible.TreasureItem.name))
    //            {
    //                var newColor = interactible.Icon.color;
    //                newColor.a = 145;
    //                interactible.Icon.color = newColor;
    //                interactible.InteractibleButton.interactable = false;
    //            }
    //            else if (GameInstance.Instance.StartedInteractions.Contains(interactible.TreasureItem.name))
    //            {
    //                var newColor = interactible.Icon.color;
    //                newColor.a = 145;
    //                interactible.Icon.color = newColor;
    //                interactible.InteractibleButton.interactable = true;
    //            }
    //            else if (GameInstance.Instance.UnlockedInteractions.Contains(interactible.TreasureItem.name))
    //            {
    //                interactible.Icon.color = Color.white;
    //                interactible.InteractibleButton.interactable = true;
    //            }
    //            else
    //            {
    //                interactible.Icon.color = Color.black;
    //                interactible.InteractibleButton.interactable = false;
    //            }
    //        }
    //        else
    //        {
    //            if (GameInstance.Instance.CompletedInteractions.Contains(interactible.TreasureItem.name))
    //            {
    //                var newColor = interactible.Icon.color;
    //                newColor.a = 145;
    //                interactible.Icon.color = newColor;
    //                interactible.InteractibleButton.interactable = false;
    //            }
    //            else if (GameInstance.Instance.StartedInteractions.Contains(interactible.TreasureItem.name))
    //            {
    //                var newColor = interactible.Icon.color;
    //                newColor.a = 145;
    //                interactible.Icon.color = newColor;
    //                interactible.InteractibleButton.interactable = true;
    //            }
    //            else if (GameInstance.Instance.UnlockedInteractions.Contains(interactible.TreasureItem.name))
    //            {
    //                interactible.Icon.color = Color.white;
    //                interactible.InteractibleButton.interactable = true;
    //            }
    //            else
    //            {
    //                interactible.Icon.color = Color.black;
    //                interactible.InteractibleButton.interactable = false;
    //            }
    //        }
    //    }
    //}
}
