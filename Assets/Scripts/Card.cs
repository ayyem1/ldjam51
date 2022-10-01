using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "ScriptableObjects/Create New Card", order = 1)]
public class Card : ScriptableObject
{
    [System.Serializable]
    public struct Buff
    {
        public bool ShouldUseOnEnemy; // If false, this will be used on the player.
        public float AttackModification;
        public float DefenseModification;
    }

    public string Title;
    public string Description;
    public Sprite Icon;

    public float AttackDamage;
    public float DefenseIncrease;
    public Buff[] Buffs;
}
