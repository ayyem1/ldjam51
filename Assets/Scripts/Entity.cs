using UnityEngine;

[CreateAssetMenu(fileName = "NewEntity", menuName = "ScriptableObjects/Entity", order = 1)]

public class Entity : ScriptableObject
{
    public string Name;
    public string Dialog;
    public float Hp;

    // Moves
    public float AttackDamage;
    public float Defense;
    public Buff[] Buffs;
    // TODO: Move Pattern
}
