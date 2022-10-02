using UnityEngine;

public class InteractionDialog : MonoBehaviour
{
    public void Initialize()
    {

    }

    public void OnClose()
    {
        gameObject.SetActive(false);
    }
}
