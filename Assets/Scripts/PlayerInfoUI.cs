using UnityEngine;
using TMPro;

public class PlayerInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI defense;
    [SerializeField] private TextMeshProUGUI moveCounter;

    private void Update()
    {
        healthText.text = "Health: " + GameInstance.Instance.MainPlayer.HpDisplayText;
        moveCounter.text = "Moves:" + GameInstance.Instance.MainPlayer.moveCounterDisplayText;
        defense.text = "Defense: " + GameInstance.Instance.MainPlayer.CurrentDefense;
    }

}
