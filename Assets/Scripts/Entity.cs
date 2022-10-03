using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEntity", menuName = "ScriptableObjects/Entity", order = 1)]

public class Entity : ScriptableObject
{
    public string Name;
    public string StartingDialog;
    public string LossDialog;
    public Sprite EntitySprite;
    [Min(0f)] public float StartingHp;
    [Min(1f)] public float MaxHp;

    public float StartingDefense;

    public float StartingDamageValue;
    public float StartingDefenseIncrementValue = 0;
    public float StartingAttackBuff;
    public float StartingDefenseBuff;
    public float StartingAttackDebuff;
    public float StartingDefenseDebuff;

    public List<Card.ActionType> movePattern;
    public Entity[] minions;
    public int RewardAmount;
    public bool isRewardCard;
    [SerializeField] public Card RewardCard;

    public Entity[] unlockedEntities;
    public Treasure[] unlockedTreasures;
    public HealingItem[] unlockedHealingItems;
}
