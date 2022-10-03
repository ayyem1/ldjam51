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
            //else if (state == Interactible.State.Started)
            //{
            //    var newColor = interactible.Icon.color;
            //    newColor.a = 145;
            //    interactible.Icon.color = newColor;
            //    interactible.InteractibleButton.interactable = true;
            //}
            else if (state == Interactible.State.Completed)
            {
                var newColor = interactible.Icon.color;
                newColor.a = 145;
                interactible.Icon.color = newColor;
                interactible.InteractibleButton.interactable = false;
            }
        }
    }
}
