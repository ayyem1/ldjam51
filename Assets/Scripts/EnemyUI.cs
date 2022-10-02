using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI defense;
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
        enemyIcon.sprite = refEnemy.Data.BattleSprite;
        refEnemy.CurrentHp = refEnemy.Data.StartingHp;
        refEnemy.CurrentDefense = refEnemy.Data.StartingDefense;
        refEnemy.CurrentDamageValue = refEnemy.Data.StartingDamageValue;
        refEnemy.CurrentDefenseIncrementValue = refEnemy.Data.StartingDefenseIncrementValue;

        isInitialized = true;
    }

    public void UpdateEntityVisual()
    {
        defense.text =  refEnemy.CurrentDefense.ToString();
        health.text = $"{refEnemy.CurrentHp}/{refEnemy.Data.MaxHp}";
    }
}
