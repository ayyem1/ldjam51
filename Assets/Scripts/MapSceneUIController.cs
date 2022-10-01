using TMPro;
using UnityEngine;

public class MapSceneUIController : MonoBehaviour
{
    public TMP_Text HealthLabel;
    public TMP_Text CorporateBucksLabel;

    private void Start()
    {
        HealthLabel.text = GameInstance.Instance.MainPlayer.HpDisplayText;
        CorporateBucksLabel.text = GameInstance.Instance.MainPlayer.CurrentCorporateBucksAmount.ToString();
    }
}
