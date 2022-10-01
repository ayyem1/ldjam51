using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "ScriptableObjects/Card", order = 1)]
public class Card : ScriptableObject
{
    public string Title;
    public string Description;
    public Sprite Icon;

    public float AttackDamage;
    public float DefenseIncrease;
    public Buff[] Buffs;
}
