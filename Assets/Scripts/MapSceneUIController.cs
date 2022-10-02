using TMPro;
using UnityEngine;

public class MapSceneUIController : MonoBehaviour
{
    public TMP_Text HealthLabel;
    public TMP_Text CorporateBucksLabel;

    public GameObject DeckBuilderDialog;
    private void Update()
    {
        HealthLabel.text = GameInstance.Instance.MainPlayer.HpDisplayText;
        CorporateBucksLabel.text = GameInstance.Instance.MainPlayer.CurrentCorporateBucksAmount.ToString();
    }

    public void OnPressDeck()
    {
        DeckBuilderDialog.gameObject.SetActive(true);
    }
}