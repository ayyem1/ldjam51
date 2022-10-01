using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapSceneUIController : MonoBehaviour
{
    public TMP_Text HealthLabel;
    public TMP_Text CorporateBucksLabel;

    public GameObject DeckBuilderDialog;
    private void Start()
    {
        HealthLabel.text = GameInstance.Instance.MainPlayer.HpDisplayText;
        CorporateBucksLabel.text = GameInstance.Instance.MainPlayer.CurrentCorporateBucksAmount.ToString();
    }

    public void OnPressDeck()
    {
        DeckBuilderDialog.gameObject.SetActive(true);
    }
}