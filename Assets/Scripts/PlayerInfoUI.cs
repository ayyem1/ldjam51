using UnityEngine;
using TMPro;

public class PlayerInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI defense;
    [SerializeField] private TextMeshProUGUI mana;

    private void Update()
    {
        healthText.text = "Health: " + GameInstance.Instance.MainPlayer.HpDisplayText;
        mana.text = "Moves:" + GameInstance.Instance.MainPlayer.ManaDisplayText;
        defense.text = "Defense: " + GameInstance.Instance.MainPlayer.CurrentDefense;
    }

}
