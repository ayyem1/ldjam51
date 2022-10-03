using UnityEngine;

public class InteractibleManager : MonoBehaviour
{
    void Update()
    {
        foreach(Transform child in transform)
        {
            // Probably better to grey out items.
            var interactible = child.GetComponent<Interactible>();
            if (interactible.TypeOfInteractible != Interactible.InteractibleType.Entity)
            {
                interactible.gameObject.SetActive(!GameInstance.Instance.Interactions.Contains(interactible.gameObject.name));
            }
        }
    }
}
