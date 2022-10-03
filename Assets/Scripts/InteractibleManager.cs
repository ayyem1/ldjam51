using UnityEngine;

public class InteractibleManager : MonoBehaviour
{
    [SerializeField] private Interactible[] interactibles;

    void Update()
    {
        foreach(Transform child in transform)
        {
            // Probably better to grey out items.
            var interactible = child.GetComponent<Interactible>();
            interactible.gameObject.SetActive(!GameInstance.Instance.Interactions.Contains(interactible.gameObject.name));
        }
    }
}
