using TMPro;
using UnityEngine;

public class FTUEDialog : MonoBehaviour
{
    [SerializeField] private TMP_Text Title;
    [SerializeField] private TMP_Text Description;

    public void Initialize(string title, string description)
    {
        Title.text = title;
        Description.text = description;
    }

    public void OnClose()
    {
        gameObject.SetActive(false);
    }
}
