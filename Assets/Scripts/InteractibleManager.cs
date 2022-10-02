using UnityEngine;

public class InteractibleManager : MonoBehaviour
{
    [SerializeField] private Interactible[] interactibles;

    void Update()
    {
        foreach(Interactible interactible in interactibles)
        {
            // Probably better to grey out items.
            interactible.gameObject.SetActive(!GameInstance.Instance.Interactions.Contains(interactible.gameObject.name));
        }
    }
}
