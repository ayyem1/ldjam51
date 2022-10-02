using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EntityUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private Image enemyIcon;
    private Entity refEntity;

    public void InitializeEntity(Entity refEntity)
    {
        this.refEntity = refEntity;
        health.text = $"{refEntity.StartingHp}/{refEntity.MaxHp}";
        enemyIcon.sprite = refEntity.BattleSprite;
    }

}
