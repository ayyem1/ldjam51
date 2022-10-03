using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIV2 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI enemyName;
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI defense;
    [SerializeField] private TextMeshProUGUI attack;
    [SerializeField] private Image enemyIcon;


    private Enemy refEnemy;
    private bool isInitialized;


    private void Update()
    {
        if (isInitialized)
        {
            UpdateEntityVisual();
        }
    }

    public void Initialize(Enemy refEnemy)
    {
        this.refEnemy = refEnemy;
        health.text = $"{refEnemy.Data.StartingHp}/{refEnemy.Data.MaxHp}";
        enemyIcon.sprite = refEnemy.Data.EntitySprite;
        refEnemy.CurrentHp = refEnemy.Data.StartingHp;
        refEnemy.CurrentDefense = refEnemy.Data.StartingDefense;
        refEnemy.CurrentDamageValue = refEnemy.Data.StartingDamageValue;
        refEnemy.CurrentDefenseIncrementValue = refEnemy.Data.StartingDefenseIncrementValue;
        refEnemy.DamageBuffAmount = refEnemy.Data.StartingAttackBuff;
        refEnemy.DefenseBuffAmount = refEnemy.Data.StartingDefenseBuff;
        refEnemy.DebuffDamageAmount = refEnemy.Data.StartingAttackDebuff;
        refEnemy.DebuffDefenseAmount = refEnemy.Data.StartingDefenseDebuff;

        isInitialized = true;
    }

    public void UpdateEntityVisual()
    {
        defense.text = refEnemy.CurrentDefense.ToString();
        health.text = $"{refEnemy.CurrentHp}/{refEnemy.Data.MaxHp}";
        enemyName.text = refEnemy.Data.Name;
        attack.text = refEnemy.CurrentDamageValue.ToString();
    }

    public Enemy GetEnemy()
    {
        return refEnemy;
    }
}
