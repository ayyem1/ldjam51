using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EntityUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI defense;
    [SerializeField] private Image enemyIcon;
    private Entity refEntity;

    public void InitializeEntity(Entity refEntity)
    {
        this.refEntity = refEntity;
        health.text = $"{refEntity.StartingHp}/{refEntity.MaxHp}";
        enemyIcon.sprite = refEntity.BattleSprite;
        refEntity.CurrentHp = refEntity.StartingHp;
        refEntity.CurrentDefense = refEntity.StartingDefense;
        refEntity.CurrentDamageValue = refEntity.StartingDamageValue;
        refEntity.CurrentDefenseIncrementValue = refEntity.StartingDefenseIncrementValue;
    }

    public void UpdateEntityVisual()
    {
        defense.text = refEntity.CurrentDefense.ToString();
        health.text = $"{refEntity.CurrentHp}/{refEntity.MaxHp}";
    }
}
