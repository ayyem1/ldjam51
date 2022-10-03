using UnityEngine;
using TMPro;

public class PlayerInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI defense;
    [SerializeField] private TextMeshProUGUI mana;
    [SerializeField] private TextMeshProUGUI defenseBuff;
    [SerializeField] private TextMeshProUGUI attackBuff;

    private void Update()
    {
        healthText.text = "Health: " + GameInstance.Instance.MainPlayer.HpDisplayText;
        mana.text = "Moves:" + GameInstance.Instance.MainPlayer.ManaDisplayText;
        defense.text = "Defense: " + GameInstance.Instance.MainPlayer.CurrentDefense;
        defenseBuff.text = "Defense Buff: " + GameInstance.Instance.MainPlayer.BuffDefenseAmount;
        attackBuff.text = "Attack Buff: " + GameInstance.Instance.MainPlayer.BuffDamageAmount;
    }

}
